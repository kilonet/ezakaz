using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using EZakaz.Dao;
using EZakaz.DaoImpl;
using EZakaz.Domain;
using ICSharpCode.SharpZipLib.Zip;
using NDesk.Options;
using NHibernate;
using NHibernate.Criterion;

namespace EZakaz.AccessToSql
{
    class Program
    {
        private static ICategoryDao categoryDao = new CategoryDao();
        
        public static void Main(string[] args)
        {
//            args = new string[] {"-f=csv"};

            string format = "";
            string output_path = "";
            string host = "";
            string user = "";
            string pwd = "";
            string price_name = "price.txt";

            if (args.Length == 0)
            {
                Console.WriteLine("-f format: csv, ftp, \"\" ");
                Console.WriteLine("-o archive name");
                Console.WriteLine("-h host");
                Console.WriteLine("-u user");
                Console.WriteLine("-p password");
                Console.WriteLine("-n file name inside archive");
                Console.ReadKey();
                return;               
            }

            foreach (string arg in args)
            {
                if (arg.StartsWith("-f"))
                {
                    format = arg.Split(new[] {'='})[1];
                } 
                else if (arg.StartsWith("-o"))
                {
                    output_path = arg.Split(new[] {'='})[1];
                }
                else if (arg.StartsWith("-h"))
                {
                    host = arg.Split(new[] { '=' })[1];
                }
                else if (arg.StartsWith("-u"))
                {
                    user = arg.Split(new[] { '=' })[1];
                }
                else if (arg.StartsWith("-p"))
                {
                    pwd = arg.Split(new[] { '=' })[1];
                }
                else if (arg.StartsWith("-n"))
                {
                    price_name = arg.Split(new[] { '=' })[1];
                }
            }
            
            if (format == "csv")
            {
                GetCSV(output_path, false, null);
            }
            else if (format == "ftp")
            {
                using(MemoryStream ms = new MemoryStream())
                {
                    GetCSV(null, true, ms);

                    MemoryStream zippedStream = new MemoryStream();

                    ZipOutputStream zs = new ZipOutputStream(zippedStream);
                    ZipEntry ze = new ZipEntry(price_name);
                    zs.PutNextEntry(ze);
                    byte[] buffer = new byte[4096];
                    int sourceBytes;
                    ms.Seek(0, SeekOrigin.Begin);
                    do
                    {
                        sourceBytes = ms.Read(buffer, 0, buffer.Length);
                        zs.Write(buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);
                    
                    zs.Finish();

//                    FileStream fZip = File.Create("stream.zip");
//                    zippedStream.Seek(0, SeekOrigin.Begin);
//                    do
//                    {
//                        sourceBytes = zippedStream.Read(buffer, 0, buffer.Length);
//                        fZip.Write(buffer, 0, sourceBytes);
//                    } while (sourceBytes > 0);
//                    fZip.Close();
                    
                    

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + "/" + output_path);
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    // This example assumes the FTP site uses anonymous logon.
                    request.Credentials = new NetworkCredential(user, pwd);

                    // Copy the contents of the file to the request stream.
                    zippedStream.Seek(0, SeekOrigin.Begin);
                    StreamReader sourceStream = new StreamReader(zippedStream);
                    byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                    
                    request.ContentLength = fileContents.Length;

                    Stream requestStream = request.GetRequestStream();

                    zippedStream.Seek(0, SeekOrigin.Begin);
                    do
                    {
                        sourceBytes = zippedStream.Read(buffer, 0, buffer.Length);
                        requestStream.Write(buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);

//                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();
                    
                    
                    sourceStream.Close();
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Console.WriteLine("Загрузка завершена, статус {0}", response.StatusDescription);

                    response.Close();
                    zippedStream.Close();zs.Close();
                }
            }
            else
            {
                SendToDb();
            }

            Console.WriteLine("Операция успешно завершена");
            Thread.Sleep(3000);
        }

        private static void SendToDb()
        {
            using(ISession session = NHibernateSessionManager.Instance.GetSession())
            {
                session.CreateSQLQuery("delete from Item").ExecuteUpdate();
                session.CreateSQLQuery("delete from Category").ExecuteUpdate();

                string provider = ConfigurationManager.AppSettings["provider"];
                string conStr = ConfigurationManager.AppSettings["conStr"];
                DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(provider);
                DbConnection dbConnection = dbProviderFactory.CreateConnection();
                dbConnection.ConnectionString = conStr;
                dbConnection.Open();
                DbCommand dbCommand = dbProviderFactory.CreateCommand();
                dbCommand.Connection = dbConnection;

                string[] queries = new string[] { "DelTempPrice", "ПрайсДобавляемMAX", "ПрайсОбновлениеMAX" };

                foreach (string query in queries)
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = query;
                    dbCommand.ExecuteNonQuery(); 
                }
                    
                dbConnection.Close();

                foreach (Category category in GetCategories())
                {
                    session.Save(category);
                    Console.WriteLine(string.Format("item {0}", category.Id));
                }
                session.Flush();
                foreach (Item item in GetItems())
                {
                        

                    ItemInfo info =
                        session.CreateCriteria(typeof(ItemInfo))
                            .Add(Restrictions.Eq("ProductId", item.ProductId))
                            .UniqueResult<ItemInfo>();
                    if (info == null)
                    {
                        info = new ItemInfo();
                        info.ProductId = item.ProductId;
                               
                    }
                    item.ItemInfo = info;
                    session.Save(info);
                    session.Save(item);
                    Console.WriteLine(string.Format("item {0}", item.Id));
                        
                }
                session.Flush();
                        
            }
        }

        private static IEnumerable<Item> GetItems()
        {
            return GetItems("");
        }

        public static string crop(string s, int len)
        {
            return s.Substring(0, Math.Min(s.Length, len));
        }

        public static  void GetCSV(string output_path, bool is_stream, Stream stream)
        {
            List<string> lines = new List<string>();
            lines.Add("ProductId;Name;Manufacter;Pack;Rest;Date;Price1;Price2;Price3");
            foreach (var item in GetItems("csv"))
            {
                var cols = new List<string>();
                cols.Add(item.ProductId.ToString());
                cols.Add(crop(item.Name, 255));
                cols.Add(crop(item.Manufacter, 255));
                cols.Add(crop(item.Pack, 15));
                cols.Add(item.Rest.ToString());
                cols.Add(item.Date.HasValue ? item.Date.Value.ToString("dd-MM-YYYY") : "");
                cols.Add(item.Price1.ToString("n2"));
                cols.Add(item.Price2.ToString("n2"));
                cols.Add(item.Price3.ToString("n2"));
                lines.Add(string.Join(";", cols.ToArray()));
            }
//            if (string.IsNullOrEmpty(output_path))
//            {
//                output_path = string.Format("price{0:ddMMyy-Hmmss}.txt", DateTime.Now);
//            }
            
            
            var contents = string.Join(Environment.NewLine, lines.ToArray());
            var encoding = Encoding.GetEncoding(1251);
            if (is_stream)
            {
                StreamWriter sw = new StreamWriter(stream, encoding);
                sw.Write(contents);
            }
            else
            {
                var path = Path.Combine(output_path, string.Format("price{0:ddMMyy-Hmmss}.txt", DateTime.Now));
                File.WriteAllText(path, contents, encoding);
            }
            
        }


        private static List<Item> GetItems(string format)
        {
            List<Item> items = new List<Item>();
            DbDataReader dbDataReader = GetDbReader(CommandType.StoredProcedure, "ПрайсЭкспортБезДублей");
            while (dbDataReader.Read())
            {
                Item item = new Item();

                //item.Category = new Category(categories[(int)dbDataReader["Min-КодТипа"]]); 
                if (format != "csv")
                    item.Category = categoryDao.FindByNumber((int) dbDataReader["Min-КодТипа"]);
                item.Date = dbDataReader["Min-СрокГодн"] != DBNull.Value
                                ? (DateTime?)dbDataReader["Min-СрокГодн"]
                                : null;
                item.ProductId = (int)dbDataReader["Min-КодТовара"];
                item.Manufacter = (string)dbDataReader["Min-КраткоЗаводИ"];
                item.Name = (string)dbDataReader["НаимПрайс"];
                item.Pack = dbDataReader["Min-Упаковка"] != DBNull.Value
                                ? (string)dbDataReader["Min-Упаковка"]
                                : string.Empty;
                item.Price1 = (decimal)dbDataReader["Min-Цена1"];
                item.Price2 = (decimal)dbDataReader["Min-Цена2"];
                item.Price3 = (decimal)dbDataReader["Min-Цена3"];
				
                //item.ReceiptId = dbDataReader["Min-КодСтрокПрих"] != DBNull.Value
                //    ? (int?)dbDataReader["Min-КодСтрокПрих"]
                //    : null;

            	object o = null;
				try
				{
					o = dbDataReader["Sum-Sum_Расход"];
					if (dbDataReader["Sum-Sum_Расход"] != DBNull.Value)
					{
						item.Rest = (int?)(double)dbDataReader["Sum-Sum_Расход"];
					}
					else
					{
						item.Rest = null;
					}
					//item.Rest = dbDataReader["Sum-Sum_Расход"] != DBNull.Value
					//                    ? (int?)dbDataReader["Sum-Sum_Расход"]
					//                    : null;
				}
				catch (Exception)
				{
					Debug.Write(o.GetType());
					
					if (dbDataReader["Sum-Sum_Расход"] != DBNull.Value)
					{
						double d = (double)dbDataReader["Sum-Sum_Расход"];
						item.Rest = (int?)d;
					}
					else
					{
						item.Rest = null;
					}
					throw;
				}

                items.Add(item);
            }
            return items;
        }

        private static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            DbDataReader dataReader = GetDbReader(CommandType.TableDirect, "Типы");
            while(dataReader.Read())
            {
                Category category = new Category(
                    (string) dataReader["НазваниеТипа"],
                    (int) dataReader["КодТипа"]
                    );
                categories.Add(category);
            }
            return categories;
        }

        private static DbDataReader GetDbReader(CommandType commandType, string commandText)
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string conStr = ConfigurationManager.AppSettings["conStr"];

            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(provider);
            DbConnection dbConnection = dbProviderFactory.CreateConnection();
            dbConnection.ConnectionString = conStr;
            dbConnection.Open();
            DbCommand dbCommand = dbProviderFactory.CreateCommand();
            dbCommand.Connection = dbConnection;
            dbCommand.CommandType = commandType;
            dbCommand.CommandText = commandText;
            return dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}

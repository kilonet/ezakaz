using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;
using EZakaz.DaoImpl;
using EZakaz.Domain;
using EZakaz.Server.Core.Security;
using NHibernate;

namespace EZakaz.CopyUsersFromAccessToSite
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ISession session = NHibernateSessionManager.Instance.GetSession())
            {
                string provider = ConfigurationManager.AppSettings["provider"];
                string conStr = ConfigurationManager.AppSettings["conStr"];

                DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(provider);
                DbConnection dbConnection = dbProviderFactory.CreateConnection();
                dbConnection.ConnectionString = conStr;
                dbConnection.Open();
                DbCommand dbCommand = dbProviderFactory.CreateCommand();
                dbCommand.Connection = dbConnection;
                dbCommand.CommandType = CommandType.TableDirect;
                dbCommand.CommandText = "Поставщики";
                DbDataReader dbDataReader = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while(dbDataReader.Read())
                {
                    if (dbDataReader["Вид"] != DBNull.Value && (byte)dbDataReader["Вид"] != 1) continue;
                    PriceType priceType = PriceType.Price1;
                    if (dbDataReader["ТипОплаты"] != DBNull.Value)
                        if ((byte)dbDataReader["ТипОплаты"] == 1)
                        {
                            priceType = PriceType.Price1;
                        }
                        else if ((byte)dbDataReader["ТипОплаты"] == 2)
                        {
                            priceType = PriceType.Price2;
                        }
                        else
                        {
                            priceType = PriceType.Price3;
                        }
                    UserManagment.RegisterUser(
                        Transliterate((string) dbDataReader["ПоставщикКратко"]),
                        "123",//UserManagment.GenPassword(),
                        (string) dbDataReader["Поставщик"],
                        "",
                        dbDataReader["Адрес"] == DBNull.Value ? "" : (string) dbDataReader["Адрес"],
                        dbDataReader["Телефон"] == DBNull.Value ? "" : (string)dbDataReader["Телефон"],
                        dbDataReader["Директор"] == DBNull.Value ? "" : (string)dbDataReader["Директор"],
                        Role.Client,
                        true,
                        priceType, 
                        false,
                        (int)dbDataReader["КодПоставщика"]);
                }
                session.Flush();
                Console.ReadKey();
            }
        }

        static Dictionary<string, string> dictionary = new Dictionary<string, string>();
        static Program()
        {
            dictionary.Add("а", "a");
            dictionary.Add("б", "b");
            dictionary.Add("в", "v");
            dictionary.Add("г", "g");
            dictionary.Add("д", "d");
            dictionary.Add("е", "e");
            dictionary.Add("ё", "yo");
            dictionary.Add("ж", "zh");
            dictionary.Add("з", "z");
            dictionary.Add("и", "i");
            dictionary.Add("й", "j");
            dictionary.Add("к", "k");
            dictionary.Add("л", "l");
            dictionary.Add("м", "m");
            dictionary.Add("н", "n");
            dictionary.Add("о", "o");
            dictionary.Add("п", "p");
            dictionary.Add("р", "r");
            dictionary.Add("с", "s");
            dictionary.Add("т", "t");
            dictionary.Add("у", "u");
            dictionary.Add("ф", "f");
            dictionary.Add("х", "h");
            dictionary.Add("ц", "c");
            dictionary.Add("ч", "ch");
            dictionary.Add("ш", "sh");
            dictionary.Add("щ", "shh");
            dictionary.Add("ъ", "");
            dictionary.Add("ы", "y");
            dictionary.Add("ь", "");
            dictionary.Add("э", "e");
            dictionary.Add("ю", "yu");
            dictionary.Add("я", "ya");
        }

        private static string Transliterate(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string small = s.ToLower().Replace(' ', '_');
            for (int i = 0; i < small.Length; i++)
            {
                if (dictionary.ContainsKey(small[i] + ""))
                {
                    stringBuilder.Append(dictionary[small[i] + ""]);
                }
                else
                {
                    stringBuilder.Append(small[i]);
                }
            }
            return stringBuilder.ToString();
        }

    }
}

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
                dbCommand.CommandText = "����������";
                DbDataReader dbDataReader = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while(dbDataReader.Read())
                {
                    if (dbDataReader["���"] != DBNull.Value && (byte)dbDataReader["���"] != 1) continue;
                    PriceType priceType = PriceType.Price1;
                    if (dbDataReader["���������"] != DBNull.Value)
                        if ((byte)dbDataReader["���������"] == 1)
                        {
                            priceType = PriceType.Price1;
                        }
                        else if ((byte)dbDataReader["���������"] == 2)
                        {
                            priceType = PriceType.Price2;
                        }
                        else
                        {
                            priceType = PriceType.Price3;
                        }
                    UserManagment.RegisterUser(
                        Transliterate((string) dbDataReader["���������������"]),
                        "123",//UserManagment.GenPassword(),
                        (string) dbDataReader["���������"],
                        "",
                        dbDataReader["�����"] == DBNull.Value ? "" : (string) dbDataReader["�����"],
                        dbDataReader["�������"] == DBNull.Value ? "" : (string)dbDataReader["�������"],
                        dbDataReader["��������"] == DBNull.Value ? "" : (string)dbDataReader["��������"],
                        Role.Client,
                        true,
                        priceType, 
                        false,
                        (int)dbDataReader["�������������"]);
                }
                session.Flush();
                Console.ReadKey();
            }
        }

        static Dictionary<string, string> dictionary = new Dictionary<string, string>();
        static Program()
        {
            dictionary.Add("�", "a");
            dictionary.Add("�", "b");
            dictionary.Add("�", "v");
            dictionary.Add("�", "g");
            dictionary.Add("�", "d");
            dictionary.Add("�", "e");
            dictionary.Add("�", "yo");
            dictionary.Add("�", "zh");
            dictionary.Add("�", "z");
            dictionary.Add("�", "i");
            dictionary.Add("�", "j");
            dictionary.Add("�", "k");
            dictionary.Add("�", "l");
            dictionary.Add("�", "m");
            dictionary.Add("�", "n");
            dictionary.Add("�", "o");
            dictionary.Add("�", "p");
            dictionary.Add("�", "r");
            dictionary.Add("�", "s");
            dictionary.Add("�", "t");
            dictionary.Add("�", "u");
            dictionary.Add("�", "f");
            dictionary.Add("�", "h");
            dictionary.Add("�", "c");
            dictionary.Add("�", "ch");
            dictionary.Add("�", "sh");
            dictionary.Add("�", "shh");
            dictionary.Add("�", "");
            dictionary.Add("�", "y");
            dictionary.Add("�", "");
            dictionary.Add("�", "e");
            dictionary.Add("�", "yu");
            dictionary.Add("�", "ya");
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

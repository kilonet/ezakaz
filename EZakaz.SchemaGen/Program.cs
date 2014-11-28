using System;
using System.IO;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace EZakaz.SchemaGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration configuration = new Configuration();
            configuration.Configure();
			SchemaExport schemaExport = new SchemaExport(configuration);
			//schemaExport.Create(true, false);
        	using(TextWriter stringWriter = new StreamWriter("create.sql"))
        	{
				schemaExport.Execute(false, false, false, true, null, stringWriter);	
        	}
        	//Console.ReadKey();
        }
    }
}

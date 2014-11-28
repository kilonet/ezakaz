using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using EZakaz.RichClient.localhost;

namespace EZakaz.RichClient
{
	class Program
	{
		public static void Main()
		{
            //BaseWebService service1 = new BaseWebService();
            //Console.WriteLine(service1.HelloWorld());

            //Stream fileStream = new FileStream("price.bin", FileMode.Create);
            //IFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(fileStream, service1.GetItems());
            //fileStream.Close();
            Application.Run(new MainForm());
            
		}

        private void Deserialize()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Stream fileStream = new FileStream("price.bin", FileMode.Open);
            ItemDto[] items = (ItemDto[]) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
        }


	}
}

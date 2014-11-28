using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using EZakaz.Office.RichClient.EZakaz.WS;
using Application=Access.Application;
using Form=System.Windows.Forms.Form;

namespace EZakaz.Office.RichClient
{
    public partial class MainForm : Form
    {
        BaseWebService webService = new BaseWebService();
        private OrderDto currentOrder;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int n = 1;
            foreach (OrderDto orderDto in webService.GetOrdersList())
            {
                ListViewItem listViewItem = new ListViewItem(
                    new string[]
                        {
                            n++.ToString(), orderDto.ClientName,
                            orderDto.DateSent.ToShortDateString() + " " + orderDto.DateSent.ToShortTimeString()
                        });
                listViewItem.Tag = orderDto;
                lvOrders.Items.Add(listViewItem);
            } 
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvOrders.SelectedItems.Count != 1) return;
            CurrentOrder = lvOrders.SelectedItems[0].Tag as OrderDto;
            if (currentOrder == null) return;
            lvOrderItems.Items.Clear();
            int n = 1;
            foreach (OrderItemDto orderItemDto in webService.GetOrderItems(currentOrder.Id))
            {
                ListViewItem listViewItem = new ListViewItem(new string[]
                                                            {
                                                                n++.ToString(),
                                                                orderItemDto.Name,
                                                                orderItemDto.Count.ToString(),
                                                                orderItemDto.Price.ToString("C", CultureInfo.CreateSpecificCulture("ru-RU")),
                                                                (orderItemDto.Price*orderItemDto.Count).ToString("C", CultureInfo.CreateSpecificCulture("ru-RU")) 

                                                             });
                listViewItem.Tag = orderItemDto;
                lvOrderItems.Items.Add(listViewItem);
            }
        }

        private OrderDto CurrentOrder
        {
            set
            {
                currentOrder = value;
                lblOrder.Text = value.ToString();
            }
        }

        private void btnSendToAccess_Click(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcessesByName("MSACCESS");
            if (process.Length == 0)
            {
                MessageBox.Show("Access не запущен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (process.Length > 1)
            {
                string message = "Запущено несколько копий MS Access"
                                 + Environment.NewLine
                                 + "Чтобы избежать проблем, закройте лишниее копии и попробуйте снова.";
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string path = "c:\\Export\\Zakaz\\Zakaz.csv";

            StreamWriter sw;
            try
            {
                sw = new StreamWriter(new FileStream(path, FileMode.Create), Encoding.Default);
            }
            catch(IOException ex)
            {
                string message = "Произошла ошибка при обращении к файлу с заказом:" + Environment.NewLine
                        + ex.Message + Environment.NewLine
                        + "Закройте все программы, которые могут его использовать и попробуйте снова";
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            sw.WriteLine("НомерСтроки;НаимТовара;Количество;Цена;Сумма;КодКлиента;КодТовара;КодСтрокПрихода;Дата;НаимКлиента;Примечание");
            int n = 0;
            foreach (ListViewItem item in lvOrderItems.Items)
            {
                OrderItemDto orderItemDto = item.Tag as OrderItemDto;
                sw.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}",
                    ++n,
                    orderItemDto.Name,
                    orderItemDto.Count,
                    orderItemDto.Price,
                    orderItemDto.Price * orderItemDto.Count,
                    currentOrder.ClientId,
                    orderItemDto.ProductId,
                    orderItemDto.ReceiptId,
                    DateTime.Now,
                    currentOrder.ClientName,
                    ""));
            }
        sw.Close();
        
            Application application = Marshal.GetActiveObject("Access.Application") as Application;
        
            // Run the macros.
            RunMacro(application, new Object[] { "ExportZakaz" });
        }

        private void RunMacro(object oApp, object[] oRunArgs)
        {
            oApp.GetType().InvokeMember("Run",
                System.Reflection.BindingFlags.Default |
                System.Reflection.BindingFlags.InvokeMethod,
                null, oApp, oRunArgs);
        }
    }
}
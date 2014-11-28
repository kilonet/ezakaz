using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using EZakaz.RichClient.localhost;
using Equin.ApplicationFramework;
using EZakaz.RichClient.Model;

namespace EZakaz.RichClient
{
    public partial class MainForm : Form
    {
        BaseWebService webService = new BaseWebService();
        private BindingListView<ItemDto> items;
        private bool orderListDirty = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                UserInfo.Login = loginForm.Login;
            }
            PriceDto price = webService.GetPrice(UserInfo.Login);
            items = new BindingListView<ItemDto>(price.Items);
            gvPrice.DataSource = items;
            
            cmbCategories.DisplayMember = "Label";
            cmbCategories.ValueMember = "Value";
            List<LabelValueItem> labelValueItems = new List<LabelValueItem>(price.Categories.Length + 1);
            labelValueItems.Add(new LabelValueItem("", "Все категории"));
            foreach (string category in price.Categories)
            {
                labelValueItems.Add(new LabelValueItem(category, category));
            }
            cmbCategories.DataSource = labelValueItems;
            
        }

        void AddNewOrder()
        {
            List<ItemDto> itemDtos = new List<ItemDto>();
            foreach (ObjectView<ItemDto> item in items)
            {
                ItemDto itemDto = item.Object;
                if (itemDto.Count > 0)
                {
                    itemDtos.Add(itemDto);
                }
            }
            SaveOrder(new Order(itemDtos));
            orderListDirty = true;
        }

        private void SaveOrder(Order order)
        {
            if (order.Items.Count == 0) return;
            List<Order> orders = GetOrdersFromFile();
            orders.Add(order);
            SaveOrders(orders);
            orderListDirty = true;
        }

        private void SaveOrders(List<Order> orders)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (Stream fileStream = new FileStream("orders.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, orders);
            }
        }

        List<Order> GetOrdersFromFile()
        {
            if (!File.Exists("orders.bin")) return new List<Order>();
            using(Stream fileStream = new FileStream("orders.bin", FileMode.Open))
            {
                if (fileStream.Length == 0) return new List<Order>();
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Order>)formatter.Deserialize(fileStream);
            }
        }

        void DoSearch()
        {
            items.ApplyFilter(delegate(ItemDto itemDto)
                                  {
                                      return itemDto.Category.Contains((string)cmbCategories.SelectedValue ?? "") &&
                                             itemDto.Name.Contains(txtSearch.Text);
                                  });            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DoSearch();

        }

        private void cmbCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewOrder();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (orderListDirty)
            {
                Orders = GetOrdersFromFile();
                orderListDirty = false;
            }
        }

        private List<Order> Orders
        {
            set
            {
                lvOrders.Items.Clear();
                foreach (Order order in value)
                {
                    ListViewItem listViewItem = new ListViewItem(
                        new string[]
                        {
                            order.Date.ToShortDateString() + " " + order.Date.ToShortTimeString(),
                            order.IsSent ? "отправлен" : "не отправлен"
                        });
                    listViewItem.Tag = order;
                    lvOrders.Items.Add(listViewItem);
                } 
            }
        }

        private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvOrders.SelectedItems.Count != 1) return;
            CurrentOrder = (Order)lvOrders.SelectedItems[0].Tag;
        }

        private Order CurrentOrder
        {
            set
            {
                if (value == null) return;
                lvItems.Items.Clear();
                int n = 1;
                foreach (ItemDto item in value.Items)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                                                            {
                                                                item.Name,
                                                                item.Count.ToString(),
                                                                item.Price.ToString("C", CultureInfo.CreateSpecificCulture("ru-RU")),
                                                                (item.Price*item.Count).ToString("C", CultureInfo.CreateSpecificCulture("ru-RU")) 

                                                             });
                    listViewItem.Tag = item;
                    lvItems.Items.Add(listViewItem);
                }
            }

            get
            {
                if (lvOrders.SelectedItems.Count == 1)
                    return lvOrders.SelectedItems[0].Tag as Order;
                return null;
            }
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            AddNewOrder();
            MessageBox.Show("Заказ успешно сохранён", "Система электронных заказов", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Order currentOrder = CurrentOrder;
            if (currentOrder == null)
            {
                MessageBox.Show("Заказ не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<OrderItemDto> orderItemDtos = new List<OrderItemDto>(currentOrder.Items.Count);
            foreach (ItemDto item in currentOrder.Items)
            {
                orderItemDtos.Add(new OrderItemDto(item.Id, item.Name, item.Price, item.ReceiptId, item.ProductId, item.Count));
            }
            webService.AddNewOrder(orderItemDtos.ToArray(), UserInfo.Login);

            List<Order> orders = GetOrdersFromFile();
            orders.Find(delegate(Order order) { return order.Date == currentOrder.Date; }).IsSent = true;
            SaveOrders(orders);
            Orders = GetOrdersFromFile();
            orderListDirty = false;

            MessageBox.Show("Заказ успешно отправлен", "Система электронных заказов", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    class LabelValueItem
    {
        private string value;
        private string label;

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public LabelValueItem(string value, string label)
        {
            this.value = value;
            this.label = label;
        }

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
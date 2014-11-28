using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Security;
using Iesi.Collections;
using Iesi.Collections.Generic;

namespace EZakaz.Server.Core.Services
{
    public class TestService
    {
        private IOrderDao orderDao;
        private IUserDao userDao;
        private IOrderItemDao orderItemDao;
        private IItemDao itemDao;

        string[] names = new string[] {"Универсал", "Спектр", "Зона", "Здоровье+", "Айболит", "Рассвет", "Заря", "Жизнь без врачей", "Подорожник", "Институт здоровья"};
        string[] emails = new string[] {"admin@mail.ru", "bill@microsoft.com", "triad@acr.org"};
        string[] adreses = new string[] {"ул. Жукова, д. ", "пл. Мира, д.", "ул. Садовая, д.", "ул. Кирова, д."};
        string[] phones = new string[]{"77-12-12", "57-75-57", "77-34-56"};
        string[] contacts = new string[] { "Олег Погодин", "Ольга Фадеева", "Юрий Соломин", "Тагир Рахимов", "Дмитрий Добужинский" };

        Random rand = new Random();

        public void CreateTestData()
        {
            //CreateTestUsers();
            IList<User> users = userDao.FindAll();
            for (int i = 0; i < 20; i++)
            {
                CreateTestOrdersForUser(users[i], 1);
            }

        }

        public void CreateTestUsers()
        {
            CreteTestUserWithRole(Role.Admin);
            for(int i = 0; i < 10; i++)
            {
                CreteTestUserWithRole(Role.Client);
            }
            for (int i = 0; i < 5; i++)
            {
                CreteTestUserWithRole(Role.Staff);
            }
        }

        public void CreteTestUserWithRole(Role role)
        {
            Random random = new Random();
            string name = names[random.Next(names.Length - 1)];
            string adres = adreses[random.Next(adreses.Length - 1)];
            string email = emails[random.Next(emails.Length - 1)];
            string phone = phones[random.Next(phones.Length - 1)];
            string contact = contacts[random.Next(contacts.Length - 1)];

            int userNumber = userDao.GetTotalRecordCount() + 1;
            HashedSet<Role> roles = new HashedSet<Role>();
            roles.Add(role);
            UserManagment.RegisterUser(role.ToString() + userNumber, "123", name + " " + random.Next(99), email, adres, phone, contact, role, false, PriceType.Price1, true, 0);
        }

        private void CreateTestOrdersForUser(User user, int numberOrders)
        {
            if (!user.IsClient) return;
            Random random = new Random();
            int totalItems = itemDao.GetTotalRecordCount();
            
            for(int iOrder = 0; iOrder < numberOrders; iOrder++)
            {
                Order order = new Order();
                order.User = user;
                order.DateSent = DateTime.Now;
                order.State = OrderState.Sent;
                orderDao.Save(order);

                for(int iItem = 0; iItem < random.Next(0, 100); iItem++)
                {
                    Item item = itemDao.FindById(random.Next(1, totalItems));
                    if (item != null)
                    {
                        OrderItem orderItem = new OrderItem(random.Next(5, 123), item, PriceType.Price3, order);
                        orderItemDao.Save(orderItem);
                        order.Items.Add(orderItem);

                    }
                }

                orderDao.Save(order);
            }
        }

        public void MarkSomeOrdersRead()
        {
            foreach (Order order in orderDao.FindAll())
            {
                order.IsRead = rand.Next(99) > 70;
                orderDao.Save(order);
            }
        }


        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }

        public IUserDao UserDao
        {
            set { userDao = value; }
        }

        public IOrderItemDao OrderItemDao
        {
            set { orderItemDao = value; }
        }


        public IItemDao ItemDao
        {
            set { itemDao = value; }
        }
    }
}

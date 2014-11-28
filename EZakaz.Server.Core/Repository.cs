using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.DaoImpl;
using EZakaz.Domain;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Services;
using EZakaz.Server.Core.Web;

namespace EZakaz.Server.Core
{
    public class Repository : Container
    {
        private static readonly Repository instance = new Repository();

        public static Repository Default
        {
            get
            {
                return instance;
            }
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        Repository()
        {
            container.AddComponent<OrderService>();
            container.AddComponent<TestService>();
            container.AddComponent<MailService>();

            container.AddComponent<IOrderItemDao, OrderItemDao>();
            container.AddComponent<IUserDao, UserDao>();
            container.AddComponent<IItemDao, ItemDao>();
            container.AddComponent<ICategoryDao, CategoryDao>();
            container.AddComponent<IOrderDao, OrderDao>();
            container.AddComponent<IItemInfoDao, ItemInfoDao>();

            container.AddComponent<IUserContext, UserContext>();

            container.AddComponent<PrintOrderPresenter>();
            container.AddComponent<NewsPresenter>();
            container.AddComponent<UserPresenter>();
            container.AddComponent<TestPresenter>();
            container.AddComponent<UsersPresenter>();
            container.AddComponent<RegisterUserPresenter>();
            container.AddComponent<LoginPresenter>();
            container.AddComponent<ItemsPresenter>();
            container.AddComponent<NewOrderPresenter>();
            container.AddComponent<EditOrderPresenter>();
            container.AddComponent<OrdersPresenter>();
            container.AddComponent<MyProfilePresenter>();
            container.AddComponent<CreateUserPresenter>();
            container.AddComponent<ChangePasswordPresenter>();
            container.AddComponent<RecoverPasswordPresenter>();
            container.AddComponent<FeedbackPresenter>();
            container.AddComponent<ItemDetailsPresenter>();
            container.AddComponent<EditItemInfoPresenter>();
            container.AddComponent<DefaultPresenter>();
            container.AddComponent<MainPresenter>();

            container.AddComponent<EZakazRoleProvider>();
        }
    }
}

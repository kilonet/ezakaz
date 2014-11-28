using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web.Security;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core.Services;
using Iesi.Collections.Generic;
using Array = EZakaz.Common.Array;

namespace EZakaz.Server.Core.Security
{
    public class UserManagment
    {
        private static IUserDao userDao = Repository.Default.Resolve<IUserDao>();
        private static MailService mailService = Repository.Default.Resolve<MailService>();


        public static byte[] CalculatePasswordHash(string password)
        {
            return
                HashAlgorithm.Create().ComputeHash(Encoding.Unicode.GetBytes(password));
        }

        public static User RegisterUser(string login, string password, string name, string email, string address,
            string phone, string contactName, Role role, bool isActive, PriceType priceType, bool isNew, int accessId)
        {
            if (userDao.FindByLogin(login) == null)
            {
                User user = new User(login, CalculatePasswordHash(password), name, email, address, phone, contactName,
                                     role, isActive, priceType, isNew, accessId);
                userDao.Save(user);
                return user;
            }
            return null;
        }

        public static bool ValidateUser(string login, string password)
        {
            User user = userDao.FindByLogin(login);
            if (user != null)
            {
                if (Array.Equals(user.PasswordHash, CalculatePasswordHash(password)))
                    return true && user.IsActive;
            }
            return false;
        }

        public static int UsersCount()
        {
            return userDao.GetTotalRecordCount();
        }

        internal static void ResetPassword(User user)
        {
            string password = GenPassword();
            user.PasswordHash = CalculatePasswordHash(password);
            mailService.SendMail(user.Email, "Восстановление пароля", string.Format("Ваш новый пароль: {0}", password));
        }

        public static string GenPassword()
        {
            return Membership.GeneratePassword(6, 0);
        }

        public static int AdminCount()
        {
            return userDao.GetAdminCount();
        }
    }
}

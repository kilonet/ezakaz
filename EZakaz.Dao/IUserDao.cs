using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Domain;

namespace EZakaz.Dao
{
    public  interface IUserDao: IDao<User, int>
    {
        User FindByLogin(string login);
        User FindByEmail(string email);

        int GetAdminCount();

        IList<User> FindAllAdmins();
    }
}

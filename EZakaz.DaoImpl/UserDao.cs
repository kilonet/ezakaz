using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Dao;
using EZakaz.Domain;
using NHibernate.Criterion;

namespace EZakaz.DaoImpl
{
    public class UserDao: AbstractNHibernateDao<User, int>, IUserDao
    {
        #region IUserDao Members

        public IList<User> FindAllAdmins()
        {
            return CreateCriteria()
                .Add(Expression.Eq("Role", Role.Admin))
                .List<User>();
        }

        public User FindByLogin(string login)
        {
            return CreateCriteria()
                .Add(Expression.Eq("Login", login))
                .UniqueResult<User>();
        }
        
        public User FindByEmail(string email)
        {
            return CreateCriteria()
                .Add(Expression.Eq("Email", email))
                .UniqueResult<User>();
        }


        public int GetAdminCount()
        {
            return
                CreateCriteria()
                .Add(Expression
                .Eq("Role", Role.Admin))
                .SetProjection(Projections.RowCount())
                .UniqueResult<int>();
        }

        #endregion
    }
}

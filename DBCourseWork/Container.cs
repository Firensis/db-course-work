using DBCourseWork.DB;
using DBCourseWork.DB.SqlBuilders;
using DBCourseWork.DB.Views;
using DBCourseWork.DB.UserSystem;
using DBCourseWork.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.UserSystem.Permissions;

namespace DBCourseWork
{
    internal class Container
    {
        protected FormSystem formSystem;
        protected Connection connection;
        protected UserFactory factory;
        protected ViewsSet viewsSet;
        protected InsertSqlBuilder insertBuilder;
        protected UpdateSqlBuilder updateBuilder;
        protected PermissionsFactory permissionsFactory;

        public FormSystem GetFormSystem()
        {
            if (formSystem == null)
            {
                formSystem = CreateFormSystem();
            }

            return formSystem;
        }

        protected virtual FormSystem CreateFormSystem()
        {
            return new FormSystem();
        }

        public Connection GetConnection()
        {
            if (connection == null)
            {
                connection = CreateConnection();
            }

            return connection;
        }

        protected virtual Connection CreateConnection()
        {
            return new Connection();
        }

        public UserFactory GetUserFactory()
        {
            if (factory == null)
            {
                factory = CreateUserFactory();
            }

            return factory;
        }
        
        protected virtual UserFactory CreateUserFactory()
        {
            return new UserFactory(GetConnection());
        }

        public User GetCurrentUser() => connection.CurrentUser;

        public ViewsSet GetViewsSet()
        {
            if (viewsSet == null)
            {
                viewsSet = CreateViewsSet();
            }

            return viewsSet;
        }

        protected virtual ViewsSet CreateViewsSet()
        {
            return new ViewsSet();
        }

        public InsertSqlBuilder GetInsertSqlBuilder()
        {
            if (insertBuilder == null)
            {
                insertBuilder = CreateInsertSqlBuilder();
            }

            return insertBuilder;
        }

        protected virtual InsertSqlBuilder CreateInsertSqlBuilder()
        {
            return new InsertSqlBuilder();
        }

        public UpdateSqlBuilder GetUpdateSqlBuilder()
        {
            if (updateBuilder == null)
            {
                updateBuilder = CreateUpdateSqlBuilder();
            }

            return updateBuilder;
        }

        protected virtual UpdateSqlBuilder CreateUpdateSqlBuilder()
        {
            return new UpdateSqlBuilder();
        }

        public PermissionsFactory GetPermissionsFactory()
        {
            if (permissionsFactory == null)
            {
                permissionsFactory = CreatePermissionsFactory();
            }

            return permissionsFactory;
        }
        
        protected virtual PermissionsFactory CreatePermissionsFactory()
        {
            return new PermissionsFactory();
        }

        public UserManager GetUserManager()
        {
            return CreateUserManager();
        }

        protected virtual UserManager CreateUserManager()
        {
            return new UserManager();
        }
    }
}

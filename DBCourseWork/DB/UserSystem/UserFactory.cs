using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.UserSystem.Permissions;
using DBCourseWork.DB.UserSystem.Role;

namespace DBCourseWork.DB.UserSystem
{
    class UserFactory
    {
        protected Connection connection;
        protected string[] roles = new string[]{
            "postgres",
            "hr",
            "high_worker",
            "worker",
            "supervisor"
        };

        public UserFactory(Connection connection)
        {
            this.connection = connection;
        }

        public User CreateCurrentUser(string id)
        {
            IRole role = GetCurrentRole();

            return new User(id, role);
        }

        protected IRole GetCurrentRole()
        {
            QueryExecutor executor = connection.GetQueryExecutor();

            foreach (string roleName in roles)
            {
                if (executor.HasRole(roleName))
                {
                    return CreateRoleFrom(roleName);
                }
            }

            throw new Exception("Пользователь не принадлежит ни к одной из известных групп!");
        }

        protected IRole CreateRoleFrom(string roleName)
        {
            switch (roleName)
            {
                case "hr":
                    return new HR();
                case "worker":
                    return new Worker();
                case "high_worker":
                    return new HighWorker();
                case "supervisor":
                    return new Supervisor();
                case "postgres":
                    return new Superuser();
            }

            throw new Exception($"{roleName} is undefined role name!");
        }
    }
}

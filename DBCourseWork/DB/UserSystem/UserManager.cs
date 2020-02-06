using DBCourseWork.DB.Exceptions;
using DBCourseWork.DB.UserSystem.Exceptions;
using DBCourseWork.DB.UserSystem.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.UserSystem
{
    public class UserManager
    {
        protected QueryExecutor executor;

        public UserManager()
        {
            executor = Program.Container.GetConnection().GetQueryExecutor();
        }

        public List<string> GetUsersList()
        {
            return executor.GetUsersList();
        }

        public void AddUser(string name, string password, IRole role)
        {
            try
            {
                executor.CreateUser(name, password, role);
            }
            catch (ExecuteNonSelectException e)
            {
                throw new AddUserException(e.Message);
            }
        }

        public void DeleteUser(string name)
        {
            executor.DropUser(name);
        }
    }
}

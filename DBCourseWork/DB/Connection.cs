using DBCourseWork.DB.Exceptions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.UserSystem;

namespace DBCourseWork.DB
{
    class Connection
    {
        public bool IsOpened { get; protected set; } = false;
        protected const string connectionStringTemplate =
            "Server=localhost;Port=5432;User Id={0};Password={1};Database=autoservice;";
        protected NpgsqlConnection connection;
        public User CurrentUser { get; protected set; }

        public void Open(string username, string password)
        {
            if (IsOpened)
            {
                connection.Close();
            }

            TryOpenNew(username, password);
        }

        protected void TryOpenNew(string user, string password)
        {
            if (password.Length == 0 || user.Length == 0)
            {
                throw new AuthorizeException("При авторизации возникла ошибка: необходимо ввести логин и пароль!");
            }

            try
            {
                OpenNewConnection(user, password);
            }
            catch (PostgresException exc)
            {
                if (exc.Routine == "auth_failed")
                {
                    throw new AuthorizeException("При авторизации произошла ошибка: проверьте правильность введённых данных!");
                }
                else
                {
                    throw exc;
                }
            }
        }

        protected void OpenNewConnection(string userId, string password)
        {
            string connectionString = GetConnectionString(userId, password);
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
            InitCurrentUser(userId);
            IsOpened = true;
        }

        protected string GetConnectionString(string user, string password)
        {
            return string.Format(connectionStringTemplate, user, password);
        }

        protected void InitCurrentUser(string userId)
        {
            CurrentUser = Program.Container.GetUserFactory().CreateCurrentUser(userId);
        }

        public QueryExecutor GetQueryExecutor()
        {
            return new QueryExecutor(connection);
        }
    }
}

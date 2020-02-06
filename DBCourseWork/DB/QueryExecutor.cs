using DBCourseWork.DB.Exceptions;
using DBCourseWork.DB.UserSystem.Role;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB
{
    public class QueryExecutor
    {
        protected NpgsqlConnection connection;

        public QueryExecutor(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        public bool HasRole(string role)
        {
            string sql = $"select pg_has_role(current_user, '{role}', 'MEMBER');";
            NpgsqlCommand command = GetCommand(sql);
            bool hasRole = (bool)command.ExecuteScalar();

            return hasRole;
        }

        public List<string> GetUsersList(bool exceptSuperuser = true)
        {
            string sql = "SELECT rolname FROM pg_roles WHERE rolcanlogin = TRUE";

            if (exceptSuperuser)
            {
                sql += " AND rolname != 'postgres'";
            }

            var reader = ExecuteSelect(sql);

            List<string> result = new List<string>();

            while (reader.Read())
            {
                result.Add(reader.GetFieldValue<string>(0));
            }

            reader.Close();

            return result;
        }

        public void CreateUser(string name, string password, IRole role)
        {
            string sql = $@"
                CREATE USER ""{name}"" PASSWORD '{password}' {role.AdditionalCreateAttributes};
                GRANT ""{role.Name}"" TO ""{name}"";
            ";
            
            ExecuteNonSelect(sql);
        }

        public void DropUser(string name)
        {
            string sql = $"DROP USER \"{name}\"";

            ExecuteNonSelect(sql);
        }

        public object[][] ExecuteSelectFetchAll(string sql)
        {
            var reader = ExecuteSelect(sql);
            List<object[]> items = new List<object[]>();
            int cols = reader.FieldCount;

            while (reader.Read())
            {
                object[] values = new object[cols];
                reader.GetValues(values);
                items.Add(values);
            }

            reader.Close();
            return items.ToArray();
        }

        public NpgsqlDataReader ExecuteSelect(string sql)
        {
            try
            {
                NpgsqlCommand command = GetCommand(sql);
                return command.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new ExecuteSelectException(e.Message);
            }
        }

        protected NpgsqlCommand GetCommand(string sql)
        {
            return new NpgsqlCommand(sql, connection);
        }

        public void ExecuteNonSelect(string sql)
        {
            try
            {
                NpgsqlCommand command = GetCommand(sql);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ExecuteNonSelectException(e.Message);
            }
        }
    }
}

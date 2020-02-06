using DBCourseWork.DB.UserSystem;
using DBCourseWork.DB.UserSystem.Permissions;
using DBCourseWork.DB.UserSystem.Role;
using DBCourseWork.DB.Views.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.Views
{
    abstract public class BaseView
    {
        protected QueryExecutor queryExecutor;
        protected object[][] data;
        public virtual string Title { get => Name; }
        abstract public string Name { get; }

        public BaseView()
        {
            queryExecutor = Program.Container.GetConnection().GetQueryExecutor();
        }

        public virtual ViewPermissions GetPermissionsOf(IRole role)
        {
            return role.GetPermissionsTo(Name);
        }

        public virtual ViewPermissions GetPermissionsOf(User user)
        {
            return GetPermissionsOf(user.Role);
        }

        abstract public string[] GetTableHeader();

        abstract protected string GetSelectSql(Filter filter = null);

        public object[][] GetData(Filter filter = null)
        {
            if (filter != null || data == null)
            {
                LoadData(filter);
            }

            return data;
        }
        
        protected void LoadData(string sql)
        {
            BeforeLoadData();
            var reader = queryExecutor.ExecuteSelect(sql);
            List<object[]> items = new List<object[]>();
            int cols = reader.FieldCount;

            while (reader.Read())
            {
                object[] values = new object[cols];
                reader.GetValues(values);
                items.Add(CreateRow(values));
            }

            reader.Close();
            data = items.ToArray();
        }

        public void LoadData(Filter filter = null)
        {
            LoadData(GetSelectSql(filter));
        }

        protected virtual void BeforeLoadData()
        {
        }

        protected virtual object[] CreateRow(object[] values)
        {
            return values;
        }

        abstract public Filter[] GetAviableFilters();
    }
}

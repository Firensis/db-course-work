using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.UserSystem.Permissions;

namespace DBCourseWork.DB.UserSystem.Role
{
    abstract class AbstractRole : IRole
    {
        protected Dictionary<string, ViewPermissions> permissions;
        protected PermissionsFactory permissionsFactory;

        abstract public string Name { get; }
        abstract public string Title { get; }
        public virtual string AdditionalCreateAttributes => "";

        public AbstractRole()
        {
            permissions = new Dictionary<string, ViewPermissions>();
            permissionsFactory = Program.Container.GetPermissionsFactory();
        }

        public ViewPermissions GetPermissionsTo(string tableName)
        {
            if (!permissions.ContainsKey(tableName))
            {
                permissions[tableName] = new ViewPermissions(); 
            }

            return permissions[tableName];
        }
    }
}

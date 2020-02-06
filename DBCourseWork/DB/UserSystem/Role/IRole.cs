using DBCourseWork.DB.UserSystem.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.UserSystem.Role
{
    public interface IRole
    {
        string Name { get; }
        string Title { get; }
        string AdditionalCreateAttributes { get; }
        ViewPermissions GetPermissionsTo(string tableName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.UserSystem.Permissions
{
    class PermissionsFactory
    {
        public ViewPermissions CreateFull()
        {
            return new ViewPermissions
            {
                Select = true,
                Insert = true,
                Update = true,
                Delete = true
            };
        }

        public ViewPermissions CreateSelect()
        {
            return new ViewPermissions
            {
                Select = true
            };
        }

        public ViewPermissions CreateEmpty()
        {
            return new ViewPermissions();
        }
    }
}

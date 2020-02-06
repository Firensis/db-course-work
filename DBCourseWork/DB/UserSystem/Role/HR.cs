using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.UserSystem.Permissions;

namespace DBCourseWork.DB.UserSystem.Role
{
    class HR : AbstractRole
    {
        public override string Name => "hr";

        public override string Title => "HR";
        public override string AdditionalCreateAttributes => "CREATEROLE";

        public HR() : base()
        {
            permissions["Сотрудник"] = permissionsFactory.CreateFull();
        }
    }
}

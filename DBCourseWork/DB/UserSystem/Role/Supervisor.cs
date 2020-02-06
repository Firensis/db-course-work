using DBCourseWork.DB.UserSystem.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.UserSystem.Role
{
    class Supervisor : AbstractRole
    {
        public override string Name => "supervisor";

        public override string Title => "Диспетчер";

        public Supervisor() : base()
        {
            permissions["Владелец"] = permissionsFactory.CreateSelect();
            permissions["Автомобиль"] = permissionsFactory.CreateSelect();
            permissions["Неисправность"] = permissionsFactory.CreateSelect();
            permissions["Сотрудник"] = permissionsFactory.CreateSelect();
            permissions["problem_full_info"] = permissionsFactory.CreateSelect();
            permissions["fixed_cars"] = permissionsFactory.CreateSelect();
        }
    }
}

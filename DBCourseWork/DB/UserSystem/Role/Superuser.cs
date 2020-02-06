using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.UserSystem.Permissions;

namespace DBCourseWork.DB.UserSystem.Role
{
    class Superuser : AbstractRole
    {
        public override string Name => "postgres";

        public override string Title => "Суперпользователь";

        public Superuser() : base()
        {
            permissions["Автомобиль"] = permissionsFactory.CreateFull();
            permissions["Владелец"] = permissionsFactory.CreateFull();
            permissions["Неисправность"] = permissionsFactory.CreateFull();
            permissions["Сотрудник"] = permissionsFactory.CreateFull();
            permissions["problem_full_info"] = permissionsFactory.CreateFull();
            permissions["fixed_cars"] = permissionsFactory.CreateFull();
        }
    }
}

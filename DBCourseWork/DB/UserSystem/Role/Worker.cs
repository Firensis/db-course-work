using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.UserSystem.Permissions;

namespace DBCourseWork.DB.UserSystem.Role
{
    class Worker : AbstractRole
    {
        public override string Name => "worker";

        public override string Title => "Сотрудник";

        public Worker() : base()
        {
            permissions["Неисправность"] = permissionsFactory.CreateFull();
            permissions["Автомобиль"] = permissionsFactory.CreateSelect();
        }
    }
}

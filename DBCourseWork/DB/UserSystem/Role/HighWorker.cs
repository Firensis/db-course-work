using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.UserSystem.Permissions;

namespace DBCourseWork.DB.UserSystem.Role
{
    class HighWorker : AbstractRole
    {
        public override string Name => "high_worker";

        public override string Title => "Старший сотрудник";

        public HighWorker() : base()
        {
            permissions["Автомобиль"] = permissionsFactory.CreateFull();
            permissions["Владелец"] = permissionsFactory.CreateFull();
            permissions["Неисправность"] = permissionsFactory.CreateFull();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.UserSystem.Permissions
{
    public class ViewPermissions
    {
        public bool Select { get; set; } = false;
        public bool Insert { get; set; } = false;
        public bool Update { get; set; } = false;
        public bool Delete { get; set; } = false;
    }
}

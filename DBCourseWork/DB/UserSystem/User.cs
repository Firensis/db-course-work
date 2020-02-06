using DBCourseWork.DB.UserSystem.Permissions;
using DBCourseWork.DB.UserSystem.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.UserSystem
{
    public class User
    {
        public string UserId { get; protected set; }
        public IRole Role { get; protected set; }

        public User(string id, IRole role)
        {
            UserId = id;
            Role = role;
        }
    }
}

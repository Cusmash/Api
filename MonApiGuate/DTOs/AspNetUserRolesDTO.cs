using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.DTOs
{
    public class AspNetUserRolesDTO
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRolesDTO Role { get; set; }
        public virtual AspNetUsersDTO User { get; set; }
    }
}

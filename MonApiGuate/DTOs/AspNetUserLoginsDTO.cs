using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.DTOs
{
    public class AspNetUserLoginsDTO
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsersDTO User { get; set; }
    }
}

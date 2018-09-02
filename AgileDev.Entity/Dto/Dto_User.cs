using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.Entity.Dto
{
    public class Dto_User
    {
        public int UserId { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string RealName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}

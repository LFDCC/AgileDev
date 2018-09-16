using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        
        public string UserName { get; set; }
        
        public string RealName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}

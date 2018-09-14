using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.Application.User.Dto
{
    public class User_Record_Sql_Dto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string RealName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime? CreateTime { get; set; }

        public int RecordId { get; set; }

        public string Title { get; set; }

        public string Remark { get; set; }
    }
}

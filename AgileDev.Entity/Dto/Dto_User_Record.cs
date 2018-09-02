using AgileDev.Entity.Model;
using System;
using System.Collections.Generic;

namespace AgileDev.Entity.Dto
{
    public class Dto_User_Record
    {
        public int UserId { get; set; }


        public string UserName { get; set; }


        public string Password { get; set; }


        public string RealName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime? CreateTime { get; set; }

        public virtual IEnumerable<T_Record> T_Records { get; set; }
    }
}

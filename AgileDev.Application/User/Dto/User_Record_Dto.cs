using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgileDev.Entity;

namespace AgileDev.Application.User.Dto
{
    public class User_Record_Dto
    {
        public T_User user { get; set; }
        public T_Record record { get; set; }
    }
}

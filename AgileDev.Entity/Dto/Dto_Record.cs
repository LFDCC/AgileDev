using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.Entity.Dto
{
    public class Dto_Record
    {
        public int RecordId { get; set; }
        
        public string Title { get; set; }
        
        public string Remark { get; set; }

        public int UserId { get; set; }
    }
}

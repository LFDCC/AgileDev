namespace AgileDev.Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_Record
    {
        [Key]
        public int RecordId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public int UserId { get; set; }

        public static implicit operator List<object>(T_Record v)
        {
            throw new NotImplementedException();
        }
    }
}

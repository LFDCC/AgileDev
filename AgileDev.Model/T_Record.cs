namespace AgileDev.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Record
    {
        [Key]
        public int RecordId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public int UserId { get; set; }
    }
}

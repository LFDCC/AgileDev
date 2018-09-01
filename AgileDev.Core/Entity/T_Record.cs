namespace AgileDev.Core.Entity
{
    using Interface.ICore;
    using System.ComponentModel.DataAnnotations;

    public partial class T_Record : IEntity
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
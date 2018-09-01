namespace AgileDev.Core.Entity
{
    using Interface.ICore;
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class T_User : IEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string RealName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
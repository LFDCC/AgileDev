namespace AgileDev.DataBase
{
    using Model;
    using System.Data.Entity;

    public partial class AgileDevContext : DbContext
    {
        public AgileDevContext()
            : base("name=AgileDevContext")
        {
        }

        public virtual DbSet<T_Record> T_Record { get; set; }
        public virtual DbSet<T_User> T_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Record>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<T_User>()
                .Property(e => e.RealName)
                .IsUnicode(false);
        }
    }
}
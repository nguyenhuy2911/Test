namespace test_reflaction
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class My_TestDataContext : DbContext
    {
        public My_TestDataContext()
            : base("name=My_TestDataContext")
        {
        }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<NumerTable> NumerTables { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<NumerTable>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}

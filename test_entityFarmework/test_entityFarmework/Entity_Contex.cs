namespace test_entityFarmework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Entity_Contex : DbContext
    {
        
        public Entity_Contex()
            : base("name=Entity_Contex")
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

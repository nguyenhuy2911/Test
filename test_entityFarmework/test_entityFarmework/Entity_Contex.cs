namespace test_entityFarmework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Entity_Contex : DbContext
    {

        public Entity_Contex() : base("name=Entity_Contex")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Entity_Contex>());
            this.Configuration.LazyLoadingEnabled = true;
        }

        public  DbSet<Image> Images { get; set; }
        public  DbSet<NumerTable> NumerTables { get; set; }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Product_Category> Product_Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}

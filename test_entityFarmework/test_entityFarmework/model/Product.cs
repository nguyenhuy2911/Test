namespace test_entityFarmework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public int? GroupId { get; set; }

        public bool? Active { get; set; }

        public bool? Publish { get; set; }
        public virtual ICollection<Product_Category> Product_Categories { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_entityFarmework
{
    [Table("Product_Category")]
    public class Product_Category
    {
        [Key]
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Category_Id { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
    }
}

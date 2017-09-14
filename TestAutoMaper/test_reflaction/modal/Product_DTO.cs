using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_reflaction.modal
{
   public class Product_DTO
    {
        public int Id { get; set; }

    
        public string Name { get; set; }

        public int? Price { get; set; }
     
        public string Description { get; set; }

        public int? GroupId { get; set; }

        public bool? Active { get; set; }

        public bool? Publish { get; set; }
    }
}

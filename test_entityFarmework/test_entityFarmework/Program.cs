using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_entityFarmework.repository;

namespace test_entityFarmework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("update");
            Console.ReadLine();
            var product = new Product()
            {
                Id = 2,
                Name = "test 9"
            };

            var productRipository = new ProductRepository();
            productRipository.Update(product);
   
        }

        
    }
}

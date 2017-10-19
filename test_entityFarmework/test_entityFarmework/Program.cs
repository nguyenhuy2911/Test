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
            var _continue = "";
            do
            {
                var productRipository = new ProductRepository();
                var products = productRipository.GetEagerAll2();
                //var categorys = products.Product_Categories;
                //var category = categorys.First().Category;
                //var cateRepository = new CategoryRepository();
                //var cates = cateRepository.GetAll();
                Console.Write("do you want to continue: ");
                _continue = Console.ReadLine();
            }
            while (_continue == "y");
            Console.ReadLine();
        }

        private static void update2()
        {
            Console.WriteLine("update");
            Console.ReadLine();
            var param = new Update_Product_Store_Param()
            {
                Id = 2,
                Name = "rrrrrrrrrrrr"
            };
            var productRipository = new ProductRepository();
            int result = productRipository.UpdateByStore(param);
            string message = result == 1 ? "success" : "fail";
            Console.WriteLine(message);
        }

        private static void update()
        {
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

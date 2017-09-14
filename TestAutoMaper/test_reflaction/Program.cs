using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_reflaction.Mapping;
using test_reflaction.modal;

namespace test_reflaction
{
    class Program
    {
        static void Main(string[] args)
        {
         //   AutoMapperConfiguration.Configure();
            Product product = new Product()
            {
                Active = false,
                Description = "aaaaaaaaaaaaaaaaa",
                GroupId = 0,
                Id = 1,
                Name = "bbbbbbbbbbbbbbbbbbb",
                Price = 20000,
                Publish = true
            };
            var ret = Mapper.Map<Product, Product_DTO>(product);
            Console.ReadLine();
        }
    }
}

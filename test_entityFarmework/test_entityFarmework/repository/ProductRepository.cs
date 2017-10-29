
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_entityFarmework.repository
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public void Update(Product entity)
        {


            var exitEntity = dbset.SingleOrDefault(b => b.Id == entity.Id);
            var dbEntityEntry = DataContext.Entry(exitEntity);
            foreach (var property in exitEntity.GetType().GetProperties())
            {
                var current = entity.GetType().GetProperty(property.Name).GetValue(entity);
                var original = exitEntity.GetType().GetProperty(property.Name).GetValue(exitEntity);
                if (current != null && current != original)
                {
                    dbEntityEntry.Property(property.Name).CurrentValue = current;
                    dbEntityEntry.Property(property.Name).IsModified = true;
                }

            }
            DataContext.SaveChanges();
        }

        public int UpdateByStore(Update_Product_Store_Param paramObj)
        {
            return DataContext.UpdateData_By_Stored("Update_Product", paramObj);
        }

        public Product GetById(int id)
        {
            return dbset.Find(id);
        }

        public List<Product> GetAll()
        {
            return dbset.ToList();
        }

        public List<Product> GetEagerAll()
        {
            return dbset.Include(p => p.Product_Categories.Select(x => x.Category))
                        .Where(p => p.Product_Categories.Where(x => x.Category.Name == "sf").Count() > 0)
                        .ToList();
        }

        public List<Product> GetEagerAll2()
        {
            return dbset.OrderBy(p => p.Id)
                        .Skip(11).Take(10)
                        .Include(p => p.Product_Categories.Select(x => x.Category))                                               
                        .ToList();
        }
        public Product ExplicitLoad()
        {
            var product = dbset.FirstOrDefault();
            DataContext.Entry(product).Collection(p => p.Product_Categories).Load();
            return product;
        }

        public List<Product> GetInclude()
        {
            return dbset.Include(p=>p.Images.Where(o => o.Type_Id == p.Id.ToString())).ToList();
        }

    }
}

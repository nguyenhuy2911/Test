
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
    }
}


using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_entityFarmework.repository
{
    public class CategoryRepository : RepositoryBase<Category>
    {
      

        public int UpdateByStore(Update_Product_Store_Param paramObj)
        {
            return DataContext.UpdateData_By_Stored("Update_Product", paramObj);
        }

        public Category GetById(int id)
        {
            return dbset.Find(id);
        }

        public List<Category> GetAll()
        {
            return dbset.ToList();
        }

        public List<Category> GetEagerAll()
        {
            return dbset.Include(p => p.Product_Categories).ToList();
        }
    }
}

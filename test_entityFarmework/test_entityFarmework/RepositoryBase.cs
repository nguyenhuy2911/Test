using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_entityFarmework
{
    public class RepositoryBase<T> where T:class
    {
        private Entity_Contex _datacontext;
        public  IDbSet<T> dbset { get; set; }
        protected RepositoryBase()
        {
            dbset = DataContext.Set<T>();
        }
        protected Entity_Contex DataContext
        {
            get { return _datacontext ?? (_datacontext = new Entity_Contex()); }
        }
    }
}

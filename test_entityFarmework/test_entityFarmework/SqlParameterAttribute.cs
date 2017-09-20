using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_entityFarmework
{
    public class SqlParameterAttribute : Attribute
    {
        public string ParameterName { get; set; }
        public object Value { get; set; }
        public DbType DbType { get; set; }
        public bool IsOutput { get; set; }
    }
}

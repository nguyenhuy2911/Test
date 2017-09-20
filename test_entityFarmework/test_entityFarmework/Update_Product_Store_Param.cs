
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlClient;
namespace test_entityFarmework
{
    public class Update_Product_Store_Param
    {
        [SqlParameterAttribute(ParameterName = "@id", DbType = System.Data.DbType.Int16)]
        public int Id { get; set; }

        [SqlParameterAttribute(ParameterName = "@name", DbType = System.Data.DbType.String)]
        public string Name { get; set; }

        [SqlParameterAttribute(ParameterName = "@result", DbType = System.Data.DbType.Int16, IsOutput = true)]
        public int Result { get; set; }
    }

    public class Update_Product_Store_Result
    {
    }
}

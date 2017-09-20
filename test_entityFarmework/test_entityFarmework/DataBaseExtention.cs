using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test_entityFarmework
{
    public static class DatabaseExtention
    {
        private static string CamelCaseToUnderscore(string str)
        {
            return Regex.Replace(str, @"(?<!_)([A-Z])", "_$1").TrimStart('_').ToLower();
        }
        private static bool ColumnExists(this IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private static object GetDBValue(object value, PropertyInfo field)
        {
            if (field.PropertyType == typeof(int))
                return value.ReturnZeroIfNull();
            if (field.PropertyType == typeof(string))
                return value.ReturnEmptyIfNull();
            if (field.PropertyType == typeof(bool))
                return value.ReturnNullIfDbNull();

            return value.ReturnNullIfDbNull();
        }

        public static List<T> GetListData_By_Stored<T>(this DbContext context, string storedName, params object[] parameters)
        {

            List<T> Rows = new List<T>();
            using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            var dictionary = typeof(T).GetProperties()
                                                      .ToDictionary(
                                                            field => CamelCaseToUnderscore(field.Name),
                                                            field => field.Name
                                                       );
                            while (dr.Read())
                            {
                                T tempObj = (T)Activator.CreateInstance(typeof(T));
                                foreach (var key in dictionary.Keys)
                                {
                                    var fieldName = dictionary[key];
                                    PropertyInfo propertyInfo = tempObj.GetType().GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance);
                                    if (null != propertyInfo && propertyInfo.CanWrite && dr.ColumnExists(fieldName))
                                        propertyInfo.SetValue(tempObj, GetDBValue(dr[fieldName], propertyInfo), null);
                                }
                                Rows.Add(tempObj);
                            }
                        }
                        dr.Close();
                    }
                }
            }
            return Rows;
        }

        public static int UpdateData_By_Stored<TParameters>(this DbContext context, string storedName, TParameters parametersObj)
        {
            var data = 0;
            var parameters = new List<SqlParameter>();
            try
            {
                // Prameters
                var parametersObjProp = parametersObj.GetType().GetProperties();
                foreach (var paramProp in parametersObjProp)
                {
                    var paramProp_CustomAttribute = paramProp?.GetCustomAttribute<SqlParameterAttribute>(true);
                    if (paramProp_CustomAttribute != null)
                    {
                        SqlParameter sqlParam = new SqlParameter(paramProp_CustomAttribute.ParameterName, parametersObj.GetPropValue(paramProp.Name));
                        sqlParam.DbType = paramProp_CustomAttribute.DbType;
                        if (paramProp_CustomAttribute.IsOutput)
                            sqlParam.Direction = ParameterDirection.Output;
                        parameters.Add(sqlParam);
                    }
                }

                using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(storedName, con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var param in parameters)
                            cmd.Parameters.Add(param);
                        con.Open();
                        int updateSuccess = cmd.ExecuteNonQuery();
                        data = updateSuccess;
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
            return data;
            //DataSet ds = new DataSet("ListTable");
            //  SqlDataAdapter da = new SqlDataAdapter();
            // da.SelectCommand = cmd;
            //   da.Fill(ds);
        }

        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);

                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

        public static object ReturnZeroIfNull(this object value)
        {
            if (value == DBNull.Value)
                return 0;
            if (value == null)
                return 0;
            return value;
        }
        public static object ReturnEmptyIfNull(this object value)
        {
            if (value == DBNull.Value)
                return string.Empty;
            if (value == null)
                return string.Empty;
            return value;
        }
        public static object ReturnFalseIfNull(this object value)
        {
            if (value == DBNull.Value)
                return false;
            if (value == null)
                return false;
            return value;
        }
        public static object ReturnNullIfDbNull(this object value)
        {
            if (value == DBNull.Value)
                return '\0';
            if (value == null)
                return '\0';
            return value;
        }
    }

}

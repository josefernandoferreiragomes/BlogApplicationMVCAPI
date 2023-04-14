using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BlogApplication.DB.Data;
using BlogApplication.DB.Interfaces;

namespace BlogApplication.DB.DBExecuter
{
    public class ProductsDatabaseExecuter : IProductsDatabaseExecuter
    {
        SqlConnection sqlCon = null;
        String SqlconString = ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString;
        public List<ProductDB> StoredProcedureCall(ProductPageRequest request)
        {
            List<ProductDB> products = new List<ProductDB>();
            using (sqlCon = new SqlConnection(SqlconString))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("SpGetPageOfProducts", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@RowsPerPage", SqlDbType.Int).Value = request.RowsPerPage;
                    sql_cmnd.Parameters.AddWithValue("@PageNumber", SqlDbType.Int).Value = request.PageNumber;
                    sql_cmnd.Parameters.AddWithValue("@NameFilter", SqlDbType.NVarChar).Value = request.TextFilter;
                    SqlDataReader reader = sql_cmnd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductDB product = new ProductDB();
                        product.Id = (int)reader["Id"];
                        product.Description = (string)reader["Description"];
                        product.Price = (decimal)reader["Price"];
                        products.Add(product);
                    }
                }
                catch (Exception ex)
                {
                    //log
                    throw ex;
                }
                finally {
                    sqlCon.Close(); 
                }
                
            }

            return products;
        }
    }
}

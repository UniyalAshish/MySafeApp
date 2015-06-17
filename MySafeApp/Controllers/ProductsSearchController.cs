using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace MySafeApp.Controllers
{
    public class ProductsSearchController : ApiController
    {
        public IEnumerable<Products> Get()
        {
            List<Products> ProductList = new List<Products>();

            string connstr = "Integrated Security=SSPI;Persist Security Info=False;User ID=dhc\\z063223;Initial Catalog=DemoDB;Data Source=GG75ZR1\\SQLSERVER2008";

            //get products from DB
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = connstr;
                conn.Open();
                SqlDataAdapter daProducts = new SqlDataAdapter("Select * From Products where company ='Target'", conn);
                DataSet dsDemo = new DataSet("Products");
                daProducts.FillSchema(dsDemo, SchemaType.Source, "Products");
                daProducts.Fill(dsDemo, "Products");

                DataTable tblProducts;
                tblProducts = dsDemo.Tables["Products"];

                foreach (DataRow drCurrent in tblProducts.Rows)
                {
                    Products Product = new Products();
                    Product.ProdId = drCurrent["ProdId"].ToString();
                    Product.Name = drCurrent["Name"].ToString();
                    Product.Category = drCurrent["Category"].ToString();
                    Product.Price = drCurrent["Price"].ToString();
                    ProductList.Add(Product);
                }

                conn.Close();

                // using the code here...
            }

            return ProductList;
        }
        public IEnumerable<Products> Get(string Id)
        {
            List<Products> ProductList = new List<Products>();

            string connstr = "Integrated Security=SSPI;Persist Security Info=False;User ID=dhc\\z063223;Initial Catalog=DemoDB;Data Source=GG75ZR1\\SQLSERVER2008";

            //get products from DB
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = connstr;
                conn.Open();
                SqlDataAdapter daProducts = new SqlDataAdapter("Select * From Products where company ='Target' and name like '%"+Id+"%'", conn);
                DataSet dsDemo = new DataSet("Products");
                daProducts.FillSchema(dsDemo, SchemaType.Source, "Products");
                daProducts.Fill(dsDemo, "Products");

                DataTable tblProducts;
                tblProducts = dsDemo.Tables["Products"];

                foreach (DataRow drCurrent in tblProducts.Rows)
                {
                    Products Product = new Products();
                    Product.ProdId = drCurrent["ProdId"].ToString();
                    Product.Name = drCurrent["Name"].ToString();
                    Product.Category = drCurrent["Category"].ToString();
                    Product.Price = drCurrent["Price"].ToString();
                    ProductList.Add(Product);
                }

                conn.Close();

                // using the code here...
            }

            return ProductList;
        }
    }
}

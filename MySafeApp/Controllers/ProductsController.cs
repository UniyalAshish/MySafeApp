//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace MySafeApp.Controllers
//{
//    public class ProductsController : ApiController
//    {
//    }
//}
using MySafeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;


namespace MySafeApp.Controllers
{
    public class Products
    {
        public string ProdId;
        public string Name;
        public string Category;
        public string Price;
    }

    public class ProductsController : ApiController
    {


        //Product[] products = new Product[] 
        //{ 
        //    new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
        //    new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
        //    new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        //};

        public IEnumerable<Products> GetAllProducts()
        {
            List<Products> ProductList = new List<Products>();

            string connstr ="Integrated Security=SSPI;Persist Security Info=False;User ID=dhc\\z063223;Initial Catalog=DemoDB;Data Source=GG75ZR1\\SQLSERVER2008";
            
            //get products from DB
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = connstr;
                conn.Open();
                SqlDataAdapter daProducts = new SqlDataAdapter("Select * From Products", conn);
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

        public IHttpActionResult GetProduct(string id)
        {
            //move to data layer
            List<Products> ProductList = new List<Products>();

            string connstr = "Integrated Security=SSPI;Persist Security Info=False;User ID=dhc\\z063223;Initial Catalog=DemoDB;Data Source=GG75ZR1\\SQLSERVER2008";

            //get products from DB
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = connstr;
                conn.Open();
                SqlDataAdapter daProducts = new SqlDataAdapter("Select * From Products where ProdId = ", conn);
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
            //

            var product = ProductList.FirstOrDefault((p) => p.ProdId == id.ToString());
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
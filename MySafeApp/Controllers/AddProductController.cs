using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MySafeApp.Controllers
{
    //public class Person
    //{
    //    public string Name { get; set; }
    //    public DateTime Birthday { get; set; }
    //    public string[] Hobbies { get; set; }
    //}
    //public class AddProductController : ApiController
    //{

    //    // POST api/EmployeeAPI
    //    public IEnumerable<Employee> Post(Employee value)
    //    {
    //        EmpList.Add(value);

    //        return EmpList;
    //    }
    //}

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Data.Sql;
    using System.Data;
    using System.Data.SqlClient;


    public class product
    {
        public string name { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public string Company { get; set; }
    }

    public class AddProductController : ApiController
    {
        [HttpPost]
        public string Post(product obj)
        {
            string connstr = "Integrated Security=SSPI;Persist Security Info=False;User ID=dhc\\z063223;Initial Catalog=DemoDB;Data Source=GG75ZR1\\SQLSERVER2008";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connstr;
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandType = CommandType.Text;

                com.CommandText = "Insert into Products (Name,Category,Price,Company) values ('" + obj.name + "','" + obj.category + "','" + obj.price.ToString() + "','" + obj.Company + "')";
                com.ExecuteNonQuery();
                conn.Close();
                return obj.name + obj.category;
            }
        }
    }
}
    

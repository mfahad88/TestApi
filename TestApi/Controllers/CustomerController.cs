using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi.Models;
using TestApi.Utils;

namespace TestApi.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        public List<CustomerModel> Get()
        {
            List<CustomerModel> list = new List<CustomerModel>();
            string sql = "Select * FROM dbo.Customer";
            SqlConnection conn=null;
            try
            {
                conn = ApplicationManager.getDb();
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CustomerModel model = new CustomerModel();
                    model.Id = int.Parse(reader["Id"].ToString());
                    model.FirstName = reader["FirstName"].ToString();
                    model.LastName = reader["LastName"].ToString();
                    model.City = reader["City"].ToString();
                    model.Country = reader["Country"].ToString();
                    model.Phone = reader["Phone"].ToString();
                    list.Add(model);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
    }
}

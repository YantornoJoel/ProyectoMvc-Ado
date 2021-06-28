using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.FilterAuth;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication1.Controllers
{
    [AuthorizeUserRol(roles: "student")]
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            //try
            //{
            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            //    {
            //        DataSource = "Connection", InitialCatalog = "Luciano"
            //    };
            //    using (SqlConnection connection= new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString))
            //    {
            //        Console.WriteLine("Luciano");
            //        string query = "Select * from Pagos";
            //        using (SqlCommand cmd = new SqlCommand(query, connection))
            //        {
            //            connection.Open();
            //            using(SqlDataReader reader = cmd.ExecuteReader())
            //            {
            //                while(reader.Read())
            //                    {
            //                    Console.WriteLine("{0} {1}", reader.GetString(1), reader.GetString(2));
            //                }
            //            }
            //        }
            //    }
            //}
            return View();
        }
    }
}
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
           
            return View();
        }
    }
}
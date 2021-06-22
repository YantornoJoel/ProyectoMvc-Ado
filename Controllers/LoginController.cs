using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly BL.UserBL userBL = new BL.UserBL();
        private readonly ET.User userModel = new ET.User();
        // GET: Login
        public ActionResult Index()
        {

            return View(userModel);
        }
        [HttpPost]
        public ActionResult Index(ET.User model)
        {

            var validate = userBL.Login(model.nombre, model.password);
            Console.WriteLine(validate);

            return RedirectToAction("Index", "Admin");
        }
    }
}
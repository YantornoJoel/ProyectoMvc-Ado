using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult UnauthorizedOperation(String operacion, String modulo, String msjeErrorExcepcion)
        {

            //VISTA DE ERROR- FALTA TERMINAR
            ViewBag.operacion = operacion;
            ViewBag.modulo = modulo;
            ViewBag.msjeErrorExcepcion = msjeErrorExcepcion;
            return View();
        }

    }

}
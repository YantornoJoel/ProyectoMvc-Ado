using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Controllers;

namespace WebApplication1.FilterAuth
{
    public class VerificaSession : ActionFilterAttribute
    {
        //ousuario mismo objeto que en el acceso a login
        private usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //se sobrecarga el metodo, se envia filterContext
                base.OnActionExecuting(filterContext);

                //si es null se envia a login
                oUsuario = (usuario)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Index");
                    }



                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Home/index");
            }


        }
    }
}
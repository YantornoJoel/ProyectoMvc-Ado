using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.FilterSession
{
    public class VerifySession : ActionFilterAttribute
    {
        private usuario user;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                user = (usuario)HttpContext.Current.Session["User"];

                if(user == null)
                {
                    if(filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Index");

                    }
                }

            }
            catch(Exception)
            {
                filterContext.Result = new RedirectResult("/Login/Index");

            }
            //{
            //}

        }
    }
}
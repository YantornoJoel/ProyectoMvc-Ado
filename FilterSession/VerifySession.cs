﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;
//using WebApplication1.Models;

namespace WebApplication1.FilterSession
{
    public class VerifySession : ActionFilterAttribute
    {
       /* private ET.User userA, userS;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                userA = (ET.User)HttpContext.Current.Session["Admin"];
                userS = (ET.User)HttpContext.Current.Session["Student"];

                if (userA == null && userS == null)
                {
                    if (filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Index");

                    }
                }

            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("/Login/Index" + ex.Message);

            }
            //{
            //}

        } */
    }
}
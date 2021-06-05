using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.FilterAuth
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizeUserRol: AuthorizeAttribute
    {
        private usuario user;
        private MiSistemaEntities db = new MiSistemaEntities();
        private string roles;
        
        public AuthorizeUserRol(string roles)
        {
            this.roles = roles;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    base.OnAuthorization(filterContext);
        //}
        {

            try
            {

                user = (usuario)HttpContext.Current.Session["User"];
                var rolName = (from r in db.rol
                               where r.id == user.idRol
                               && r.nombre == roles
                               select r.nombre).FirstOrDefault();

                if (rolName != roles)
                {
                    filterContext.Result = new RedirectResult("~/Views/ErrorEx/Index");
                }
            
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Views/ErrorEx/Index " + ex.Message);
            }


        }




            //var encryptCookie = context.HttpContext.Request.Cookies.Get(".ASPXAUTH");
            //var decryptCookie = FormsAuthentication.Decrypt(encryptCookie.Value);


        
    }
}
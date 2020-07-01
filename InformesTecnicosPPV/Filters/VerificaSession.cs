using InformesTecnicosPPV.Controllers;
using InformesTecnicosPPV.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace InformesTecnicosPPV.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private Usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (Usuario)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }

                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

        }
    }
}
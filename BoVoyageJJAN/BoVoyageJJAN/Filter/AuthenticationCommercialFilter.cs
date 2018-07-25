using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Filter
{
    public class AuthenticationCommercialFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["COMMERCIAL_BO"] == null)
            {
                filterContext.Result = new RedirectResult("\\BackOffice\\AuthenticationCommercial\\Login");
            }
        }
    }
}
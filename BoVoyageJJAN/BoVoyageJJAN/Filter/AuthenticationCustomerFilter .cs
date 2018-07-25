using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Filter
{
    public class AuthenticationCustomerFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["CUSTOMER_BO"] == null)
            {
                filterContext.Result = new RedirectResult("\\BackOffice\\AuthenticationCustomer\\Login");
            }
        }
    }
}
using BoVoyageJJAN.Controllers;
using BoVoyageJJAN.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    
    public class DashBoardController : BaseController
    {
        // GET: BackOffice/DashBoard
        public ActionResult Index()
        {
            
            return View();
        }
    }
}
using BoVoyageJJAN.Controllers;
using BoVoyageJJAN.Data;
using BoVoyageJJAN.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    [AuthenticationCommercialFilter]
    public class BaseBoController : BaseController
    {
    }
}
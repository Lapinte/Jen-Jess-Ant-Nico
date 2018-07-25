using BoVoyageJJAN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Controllers
{
    public class BaseController : Controller
    {
        protected JjanDbContext db = new JjanDbContext();

        protected void DisplayMessage(string message, MessageType type)
        {
            TempData["Message"] = message;
            switch (type)
            {
                case MessageType.SUCCESS:
                    TempData["MessageType"] = "success";
                    break;
                case MessageType.WARNING:
                    TempData["MessageType"] = "warning";
                    break;
                case MessageType.ERROR:
                    TempData["MessageType"] = "danger";
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }

    public enum MessageType
    {
        SUCCESS,
        WARNING,
        ERROR
    }
}
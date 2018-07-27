using BoVoyageJJAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Areas.BackOffice.Models
{
    public class DashBoardViewModel
    {
        public IEnumerable<Reservation> Reservations { get; set; }

        public IEnumerable<Trip> Trips { get; set; }
    }
}
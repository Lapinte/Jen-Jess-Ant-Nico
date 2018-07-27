using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class TopFiveViewModel
    {
        public IEnumerable<Trip> TopFiveCheap { get; set; }

        public IEnumerable<Trip> TopFiveRush { get; set; }

        public IEnumerable<Trip> TopFiveCountry { get; set; }

    }
}
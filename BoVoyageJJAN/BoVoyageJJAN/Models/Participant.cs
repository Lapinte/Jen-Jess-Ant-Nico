using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class Participant : Person
    {
        [Display(Name = "Réservation")]
        public int ReservationID { get; set; }

        [ForeignKey("ReservationID")]
        public Reservation Reservation { get; set; }

        
    }
}
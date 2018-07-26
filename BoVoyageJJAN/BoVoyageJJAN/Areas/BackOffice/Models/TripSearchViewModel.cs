using BoVoyageJJAN.Models;
using BoVoyageJJAN.Utils.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Areas.BackOffice.Models
{
    public class TripSearchViewModel
    {
        [Display(Name = "Destination")]
        [StringLength(50, ErrorMessage = "Destination trop longue")]
        public string Destination { get; set; }

        [Display(Name = "Prix maximum")]
        public decimal MaxPrice { get; set; }

        [Display(Name = "Prix minimum")]
        public decimal MinPrice { get; set; }

        [Display(Name = "Départ après le")]
        [DataType(DataType.Date)]
        public DateTime MinDate { get; set; }

        [Display(Name = "Retour avant le ")]
        [DataType(DataType.Date)]
        public DateTime MaxDate { get; set; }

        public IEnumerable<Trip> Trips { get; set; }
    }
}
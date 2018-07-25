using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class Reservation
    {
        [Required(ErrorMessage = "le champ {0} est requis")]
        [Display(Name = "Carte de crédit")]
        [DataType(DataType.CreditCard)]
        public string CreditCardNumber { get; set; }


        [Required(ErrorMessage = "le champ {0} est requis")]
        [Display(Name = "Prix Total")]
        [DataType(DataType.Currency)]
        public float TotalPrice { get; set; }

        [Required(ErrorMessage = "le champ {0} est requis")]
        [Display(Name = "Assurance")]
        public bool Insurance { get; set; }

        [Required(ErrorMessage = "le champ {0} est requis")]
        [Display(Name = "Nombre de participants")]
        public int ParticipantNumber { get; set; }

        [Required(ErrorMessage = "le champ {0} est requis")]
        [Display(Name = "Nombre de participants de moins de 12 ans")]
        public int ParticipantUnderTwelveNumber { get; set; }

        [Required(ErrorMessage = "le champ {0} est requis")]
        [Display(Name = "Date de création")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Client")]
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer customer { get; set; }

        [Display(Name = "Voyage")]
        public int TripID { get; set; }

        [ForeignKey("TripID")]
        public Trip trip { get; set; }

        public ICollection<Participant> Participants { get; set; }



       

    }
}
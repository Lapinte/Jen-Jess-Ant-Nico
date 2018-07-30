using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BoVoyageJJAN.Models
{
    public class Reservation : BaseModel
    {
        public Reservation()
        {
            CreatedAt = DateTime.Now;
        }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Carte de crédit")]
        [DataType(DataType.CreditCard)]
        [StringLength(25, ErrorMessage = "Numéro invalide")]
        public string CreditCardNumber { get; set; }


        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Prix Total")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Assurance")]
        public bool Insurance { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Nombre de participants")]
        [Range(1,9, ErrorMessage ="Le nombre de participants doit être compris entre 1 et 9")]
        public int ParticipantNumber { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Nombre de participants de moins de 12 ans")]
        [Range(0,9, ErrorMessage = "Le nombre d'enfants doit être compris entre 0 et 9")]
        public int ParticipantUnderTwelveNumber { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Date de création")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Range(0,3)]
        [Display(Name ="Statut de la réservation")]
        public int Statut { get; set; }

        [Display(Name = "Client")]
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [Display(Name = "Voyage")]
        public int TripID { get; set; }

        [ForeignKey("TripID")]
        public Trip Trip { get; set; }

        public ICollection<Participant> Participants { get; set; }



       

    }
}
using BoVoyageJJAN.Utils.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class Trip : BaseModel
    {
        [Required(ErrorMessage = "La date d'aller est requise")]
        [Display(Name = "Date d'aller")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "La date de retour est requise")]
        [Display(Name = "Date de retour")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        [DateGreaterThan("DepartureDate")]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "Le nombre de places est requis")]
        [Display(Name ="Nombre de places")]
        public int PlaceNumber { get; set; }

        [Required(ErrorMessage = "Le tarif est requis")]
        [Display(Name = "Tarif")]
        public decimal Price { get; set; }

        [Display(Name = "Destination")]
        public int DestinationID { get; set; }

        [ForeignKey("DestinationID")]
        public Destination Destination { get; set; }

        [Display(Name = "Agence")]
        public int AgencyID { get; set; }

        [ForeignKey("AgencyID")]
        public Agency Agency { get; set; }
    }
}
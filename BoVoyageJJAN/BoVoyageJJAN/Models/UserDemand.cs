using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class UserDemand : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Nom")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "L'adresse mail n'est pas au bon format")]

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Email")]
        [StringLength(255, ErrorMessage = "Mail trop long")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Demande")]
        [DataType(DataType.MultilineText)]
        public string Demand { get; set; }
    }
}
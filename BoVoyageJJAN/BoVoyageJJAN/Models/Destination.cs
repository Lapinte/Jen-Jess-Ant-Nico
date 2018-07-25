using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Models
{
    public class Destination : BaseModel
    {
        [Required(ErrorMessage = "Le Continent est requis")]
        [Display(Name = "Continent")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Continent { get; set; }

        [Required(ErrorMessage = "Le Pays est requis")]
        [Display(Name = "Pays")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Le Region est requis")]
        [Display(Name = "Région")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Region { get; set; }

        [AllowHtml]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
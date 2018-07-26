using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public abstract class Person : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Nom")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Adresse")]
        [StringLength(255, ErrorMessage = "Adresse trop longue")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Téléphone")]
        [RegularExpression("(0|\\+33|0033)[1-9][0-9]{8}", ErrorMessage = "Entrer un numéro au format 0xxxxxxxxx")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Civilité")]
        public int CivilityID { get; set; }

        [ForeignKey("CivilityID")]
        public Civility Civility { get; set; }

    }
}
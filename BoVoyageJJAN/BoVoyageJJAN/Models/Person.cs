using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public abstract class Person
    {
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Nom")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Téléphone")]
        [RegularExpression("(0|\\+33|0033)[1-9][0-9]{8}", ErrorMessage = "Entrer un numéro au format 0xxxxxxxxx")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Civilité")]
        public int CivilityID { get; set; }

        [ForeignKey("CivilityID")]
        [Display(Name = "Civilité")]
        public Civility Civility { get; set; }

        [NotMapped]
        public int Age
        {

            get
            {
                return DateTime.Now.Year - BirthDate.Year -
                         (DateTime.Now.Month < BirthDate.Month ? 1 :
                         (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day) ? 1 : 0);
            }
        }
    }
}
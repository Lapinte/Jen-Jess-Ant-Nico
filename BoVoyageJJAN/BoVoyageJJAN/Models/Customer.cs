using BoVoyageJJAN.Utils.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class Customer : Person
    {
        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "L'adresse mail n'est pas au bon format")]
        [ExistingMailCustomer(ErrorMessage = "Le mail existe déjà")]
        [StringLength(255, ErrorMessage = "Mail trop long")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "{0} incorrect")]
        public string Password { get; set; }

        [Display(Name = "Confirmer le mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Erreur sur la confirmation du mot de passe")]
        [NotMapped]
        public string ConfirmedPassword { get; set; }
    }
}
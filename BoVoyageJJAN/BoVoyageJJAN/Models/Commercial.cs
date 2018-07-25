using BoVoyageJJAN.Utils.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class Commercial : BaseModel
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [Display(Name = "Nom")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre {2} et {1} caractères")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Le prénom est requis")]
        [Display(Name = "Prénom")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le prénom doit contenir entre {2} et {1} caractères")]
        public string Firstname { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
ErrorMessage = "L'adresse mail n'est pas au bon format")]

        [Required(ErrorMessage = "L'Email est requis")]
        [Display(Name = "Email")]
        [StringLength(255, ErrorMessage = "Mail trop long")]
        [ExistingMailCommercial(ErrorMessage = "Le mail existe déjà")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
           ErrorMessage = "{0} incorrect")]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Erreur sur la confirmation du mot de passe")]
        [NotMapped]
        public string ConfirmedPassword { get; set; }
    }
}
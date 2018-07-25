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
        [Required(ErrorMessage = "Le Nom est obligatoire")]
        [Display(Name = "Nom")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le Nom doit contenir entre {2} et {1} caractères")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le Prénom est obligatoire")]
        [Display(Name = "Prénom")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le Nom doit contenir entre {2} et {1} caractères")]
        public string FirstName { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
ErrorMessage = "L'adresse mail n'est pas au bon format")]

        [Required(ErrorMessage = "L'Email est obligatoire")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
           ErrorMessage = "{0} incorrect.")]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Erreur sur la {0}.")]
        [NotMapped]
        public string ConfirmedPassword { get; set; }
    }
}
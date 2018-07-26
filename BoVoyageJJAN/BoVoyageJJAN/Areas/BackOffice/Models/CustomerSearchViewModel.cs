using BoVoyageJJAN.Models;
using BoVoyageJJAN.Utils.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Areas.BackOffice.Models
{
    public class CustomerSearchViewModel
    {
        
        [Display(Name = "Email")]
        [StringLength(255, ErrorMessage = "Mail trop long")]
        public string Mail { get; set; }

        [Display(Name = "Nom")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Lastname { get; set; }

        [Display(Name = "Prénom")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Firstname { get; set; }

        [Display(Name = "Nait après le")]
        [DataType(DataType.Date)]
        public DateTime? BirthDateMin { get; set; }

        [Display(Name = "Nait avant le")]
        [DataType(DataType.Date)]
        public DateTime? BirthDateMax { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
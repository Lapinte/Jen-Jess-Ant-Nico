using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class Agency : BaseModel
    {
        [Required(ErrorMessage = "Le nom de l'agence est requis")]
        [Display(Name = "Nom de l'agence")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre {2} et {1} caractères")]
        public string Name { get; set; }
    }
}
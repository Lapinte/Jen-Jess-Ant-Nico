using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class Agency : BaseModel
    {
        [Required(ErrorMessage = "Le Nom de l'Agence est obligatoire")]
        [Display(Name = "Nom de l'Agence")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le Nom doit contenir entre {2} et {1} caractères")]
        public string Name { get; set; }
    }
}
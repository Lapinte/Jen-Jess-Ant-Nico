using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class Civility : BaseModel
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(15, ErrorMessage = "Trop long")]
        [Display(Name = "Civilité")]
        public string Label { get; set; }
    }
}
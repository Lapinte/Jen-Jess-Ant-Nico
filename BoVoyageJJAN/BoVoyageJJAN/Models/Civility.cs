using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class Civility
    {
        [Required(ErrorMessage = "Nom obligatoire")]
        [StringLength(15, ErrorMessage = "Trop long")]
        public string Label { get; set; }
    }
}
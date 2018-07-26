﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Models
{
    public class DestinationFile : BaseModel
    {
        [Required(ErrorMessage = "Champ {0} obligatoire")]
        [StringLength(254)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Champ {0} obligatoire")]
        [StringLength(100)]
        public string ContentType { get; set; }

        [Required(ErrorMessage = "Champ {0} obligatoire")]
        public byte Content { get; set; }


        public int DestinationID { get; set; }
        [ForeignKey("DestinationID")]
        public Destination Destination { get; set; }
    }
}
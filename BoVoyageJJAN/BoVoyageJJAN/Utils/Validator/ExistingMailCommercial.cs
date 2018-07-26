using BoVoyageJJAN.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Utils.Validator
{
    public class ExistingMailCommercial : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            using (JjanDbContext db = new JjanDbContext())
            {
                return !db.Commercials.Any(x => x.Mail == value.ToString());
            }
        }
    }
}
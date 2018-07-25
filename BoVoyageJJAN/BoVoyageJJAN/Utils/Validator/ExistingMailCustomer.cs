using BoVoyageJJAN.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Utils.Validator
{
    public class ExistingMailCustomer : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            using (JjanDbContext db = new JjanDbContext())
            {
                return !db.Customers.Any(x => x.Mail == value.ToString());
            }
        }
    }
}
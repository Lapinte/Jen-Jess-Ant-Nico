using BoVoyageJJAN.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BoVoyageJJAN.Migrations
{
    public class Configuration : DbMigrationsConfiguration<JjanDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false ;
        }

        protected override void Seed(JjanDbContext context)
        {
            /* context.Civilities.AddOrUpdate(
                 new Models.Civility { Label = "Monsieur" },
                 new Models.Civility { Label = "Madame" },
                 new Models.Civility { Label = "Mademoiselle" });
*/
                 
        }
    }
}
using Antelope.Infrastructure.EntityFramework;
using Antelope.Models.HSE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Antelope.Models.Socle
{
    public class AntelopeContextInitializer : DropCreateDatabaseAlways<AntelopeEntities>
    {

        protected override void Seed(AntelopeEntities Context)
        {
            


        }
    }
}
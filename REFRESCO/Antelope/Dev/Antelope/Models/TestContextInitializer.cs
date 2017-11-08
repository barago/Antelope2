using Antelope.Models.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Antelope.Models
{
    public class TestContextInitializer : DropCreateDatabaseIfModelChanges<TestContext>
    {
        protected override void Seed(TestContext context)
        {

            Category category1 = new Category() { Name = "Catégorie1" };
            Review review1 = new Review() { Content = "blablablbalbalba", Topic = "Sujet", Email = "jucok@gmx.fr", IsAnonymous = false, Category = category1 };

        }

    }
}
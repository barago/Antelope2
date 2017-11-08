using Antelope.Models.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Antelope.Models
{
    public class TestContext : DbContext
    {
            public DbSet<Review> Reviews { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public TestContext()
    {
        Configuration.ProxyCreationEnabled = false;
    }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Social_Hub.Models
{
    public class InventoryDataContext:DbContext
    {
        public InventoryDataContext()
        {
            Database.SetInitializer<InventoryDataContext>(new DropCreateDatabaseIfModelChanges<InventoryDataContext>());
        }
        virtual public DbSet<Post> Posts { get; set; }
        virtual public DbSet<Comment> Comments { get; set; }

    }
}
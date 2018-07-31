using NETBootcamp.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NETBootcamp.API.Context
{
    public class NETBootcampAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NETBootcampAPIContext() : base("name=NETBootcampAPIContext")
        {
        }

        public System.Data.Entity.DbSet<Project> Projects { get; set; }

        public System.Data.Entity.DbSet<Task> Tasks { get; set; }
    }
}

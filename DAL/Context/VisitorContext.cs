using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalWebAPI.DAL.Entities;

namespace TraversalWebAPI.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-HN2G937\\SQLSERVER;Initial Catalog=CoreTraversalAPI;user id=sa; password=153624;integrated security=false;");
           
    }
        public DbSet<Visitor> Visitors { get; set; }
    }
}

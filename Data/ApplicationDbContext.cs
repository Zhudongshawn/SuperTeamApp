using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperTeamApp.Models;

namespace SuperTeamApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      public DbSet<Foodprice> Foodprices { get; set; }
       // public DbSet<Happy> Happies { get; set; }
    }
}

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
        public DbSet<Foodprice> Foodprices { set; get; }
        public DbSet<Inquiryoffice> Inquiryoffices { get; set; }

    }
}

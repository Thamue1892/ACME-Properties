using System;
using System.Collections.Generic;
using System.Text;
using ACMEProperties.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ACMEProperties.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<WebImages> WebImages { get; set; }
    }
}

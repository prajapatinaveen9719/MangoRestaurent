using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoServices.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MangoServices.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
    
using carservice.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carservice.config
{
    public class MyApplicationContext : DbContext
    {

        public DbSet<Worker> Workers => Set<Worker>();
        public DbSet<User> Users => Set<User>();

        public MyApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HONOR-GAVRILIN;Database=ZERNOVA;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



        }
    }
}

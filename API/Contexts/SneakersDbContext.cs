using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts
{
    public class SneakersDbContext : DbContext
    {
        public DbSet<Sneaker> Sneakers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public SneakersDbContext(DbContextOptions<SneakersDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionString");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}

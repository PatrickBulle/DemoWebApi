using DemoWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.ContextDB
{
    public class MonAppliDbContext : DbContext
    {
        public DbSet<Bovin> DbBovins { get; set; }
        public DbSet<Cheptel> DbCheptels { get; set; }
        public DbSet<Detenteur> DbDetenteurs{ get; set; }
        public DbSet<Race> DbRaces { get; set; }
        public MonAppliDbContext(DbContextOptions<MonAppliDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bovin>().HasKey(cp => new { cp.CodePays, cp.NumeroNational });
            modelBuilder.Entity<Race>().HasKey(cp => new { cp.CodeRaceBovin });
            modelBuilder.Entity<Cheptel>().HasKey(cp => new { cp.CodePays, cp.Numero });
            modelBuilder.Entity<Detenteur>().HasKey(cp => new { cp.Numero });

            modelBuilder.Entity<Race>().Property(p => p.CodeSupression).HasDefaultValue("0");
            modelBuilder.Entity<Race>().Property(p => p.DateCreation).HasDefaultValueSql("CURRENT_DATE");
            modelBuilder.Entity<Race>().Property(p => p.DateMiseAJour).HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Bovin>().Property(p => p.CodeSupression).HasDefaultValue("0");
            modelBuilder.Entity<Bovin>().Property(p => p.DateCreation).HasDefaultValueSql("CURRENT_DATE");
            modelBuilder.Entity<Bovin>().Property(p => p.DateMiseAJour).HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Cheptel>().Property(p => p.CodeSupression).HasDefaultValue("0");
            modelBuilder.Entity<Cheptel>().Property(p => p.DateCreation).HasDefaultValueSql("CURRENT_DATE");
            modelBuilder.Entity<Cheptel>().Property(p => p.DateMiseAJour).HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Detenteur>().Property(p => p.CodeSupression).HasDefaultValue("0");
            modelBuilder.Entity<Detenteur>().Property(p => p.DateCreation).HasDefaultValueSql("CURRENT_DATE");
            modelBuilder.Entity<Detenteur>().Property(p => p.DateMiseAJour).HasDefaultValueSql("CURRENT_TIMESTAMP");

        }
    }

}

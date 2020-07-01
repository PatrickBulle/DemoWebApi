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
        #region Propriétés
        public DbSet<Bovin> DbBovins { get; set; }
        public DbSet<Cheptel> DbCheptels { get; set; }
        public DbSet<Detenteur> DbDetenteurs{ get; set; }
        public DbSet<Race> DbRaces { get; set; }
        public MonAppliDbContext(DbContextOptions<MonAppliDbContext> options) : base(options) { }
        #endregion

        #region Redéfinition de la méthode OnModelCreating pour la gestion des clés primaires composées
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bovin>().HasKey(cp => new { cp.CodePays, cp.NumeroNational });
            modelBuilder.Entity<Race>().HasKey(cp => new { cp.CodeRaceBovin });
            modelBuilder.Entity<Cheptel>().HasKey(cp => new { cp.CodePays, cp.Numero });
            modelBuilder.Entity<Detenteur>().HasKey(cp => new { cp.Numero });
        }
        #endregion

        #region Gestion dcre, dmaj et cosu
        public void PrepareCreation(Domaine entite)
        {
            if (entite != null)
            {
                entite.DateCreation = DateTime.Today;
                entite.CodeSupression = "0";
                PrepareModification(entite);
            }
        }

        public void PrepareModification(Domaine entite, bool forcerReactivationEnregistrement = false)
        {
            if (entite != null)
            {
                entite.DateMiseAJour = DateTime.Now;
                if (forcerReactivationEnregistrement)
                {
                    entite.CodeSupression = "0";
                }
            }
        }

        public void PrepareSuppression(Domaine entite)
        {
            if (entite != null)
            {
                entite.CodeSupression = "1";
                PrepareModification(entite);
            }
        }
        #endregion
    }

}

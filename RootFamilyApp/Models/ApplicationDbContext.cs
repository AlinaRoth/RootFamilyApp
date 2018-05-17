using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using RootFamilyApp.Models;
using Syncfusion.JavaScript;

namespace RootFamilyApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<FamilyTree> FamilyTrees { get; set; }

        public DbSet<TreeHeader> TreeHeaders { get; set; }
        public DbSet<TreeSource> TreeSources { get; set; }
        public DbSet<TreeRepository> TreeRepositories { get; set; }
        public DbSet<TreeSubmitter> TreeSubmitters { get; set; }
        public DbSet<TreeNote> TreeNotes { get; set; }

        public DbSet<Family> Families { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<IndividualName> IndividualNames { get; set; }
        public DbSet<IndividualEvent> IndividualEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<Individual>()
                .HasMany(p => p.ParentInFamilies);

            modelBuilder.Entity<Individual>()
                .HasMany(p => p.ChildInFamilies);
        }
    }
}
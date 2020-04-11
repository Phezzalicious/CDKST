using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MyData.Data.Models;
using MyRepo;
using MyRepo.DependencyInjection;

namespace MyData.Data
{
    public class CDKSTContext : DbContext
    {
        public CDKSTContext(DbContextOptions<CDKSTContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }        

        public DbSet<Competency> Competencies { get; set;}
        public DbSet<AtomicCompetency> AtomicCompetencies {get; set;}
        public DbSet<CompositeCompetency> CompositeCompetencies {get; set;}
        public DbSet<ConstituentCompetency> ConstituentCompetencies {get; set;}
        public DbSet<Disposition> Dispositions { get; set; }
        public DbSet<CompetencyDisposition> CompetencyDispositions {get; set;}
        public DbSet<KnowledgeElement> KnowledgeElements { get; set;}
        public DbSet<SkillLevel> SkillLevels {get; set;}
        public DbSet<KSPair> KSPairs {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Skill;
using MyData.Data.Models.Knowledge;
using MyData.Data.Models.Disposition;
using MyData.Data.Models.Competency;
using MyData.Data.Models.Task;

namespace MyData.Data
{



    public class CDKSTContext : DbContext
    {
        public CDKSTContext(DbContextOptions<CDKSTContext> options)
            : base(options)
        {
        }


        public DbSet<MyData.Data.Models.Skill.SkillLevel> SkillLevel { get; set; }


        public DbSet<MyData.Data.Models.Knowledge.KnowledgeElement> KnowledgeElement { get; set; }


        public DbSet<MyData.Data.Models.Disposition.DispositionInstance> DispositionInstance { get; set; }

        public DbSet<MyData.Data.Models.Competency.Composite> Composite { get; set; }

        public DbSet<MyData.Data.Models.Competency.Atomic> Atomic { get; set; }

        public DbSet<MyData.Data.Models.Task.Task> Task { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(Seeding.SeedDispositionInstance(modelBuilder));
           base.OnModelCreating(Seeding.SeedSkillLevel(modelBuilder));
           base.OnModelCreating(Seeding.SeedKnowledgeElement(modelBuilder));
           // base.OnModelCreating(Seeding.SeedAtomic(modelBuilder));
           // base.OnModelCreating(Seeding.SeedComposites(modelBuilder));
        }


    }
}
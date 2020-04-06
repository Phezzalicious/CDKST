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
            modelBuilder.Entity<DispositionInstance>(entity =>
            {
                entity.HasData(
                    new DispositionInstance
                    {
                        ID =1,

                        term_identifier = "Proactive",
                        cartesian_index = 1,
                        descriptor = "With Initiative (Nwokeji, Stachel, & Holmes, 2019) / Self-Starter (Clear, 2017) Shows independence. Ability to assess and start activities independently without needing to be told what to do. Willing to take the lead, not waiting for others to start activities or wait for instructions."
                    },
                        new DispositionInstance
                        {
                            ID =2,
                            term_identifier = "Self-Directed",
                            cartesian_index = 2,
                            descriptor = "Self-motivated (Clear, 2017) / Self-Directed (Nwokeji et al., 2019) Demonstrates determination to sustain efforts to continue tasks. Direction from others is not required to continue a task toward its desired ends."

                        },
                        new DispositionInstance
                        {
                            ID =3,
                            term_identifier = "Passionate",
                            cartesian_index = 3,
                            descriptor = "With Passion (Nwokeji et al., 2019), (Clear, 2017) / Conviction (Gray, 2015) Strongly committed to and enthusiastic about the realization of the task or goal. Makes the compelling case for the success and benefits of task, project, team or means of achieving goals."
 
                        },
                           new DispositionInstance
                        {
                            ID = 4,
                            term_identifier = "Purpose-Driven",
                            cartesian_index = 4,
                            descriptor = "Purposefully engaged / Purposefulness (Nwokeji et al., 2019), (Clear, 2017) Goal-directed, intentionally acting and committed to achieve organizational and project goals. Reflects an attitude towards the organizational goals served by decisions, work or work products. e.g., Business acumen."


                        },
                           new DispositionInstance
                        {
                            ID =5,
                            term_identifier = "Professional",
                            cartesian_index = 5,
                            descriptor = "With Professionalism / Work ethic (Nwokeji et al., 2019) Reflecting qualities connected with trained and skilled people: Acting honestly, with integrity, commitment, determination and dedication to what is required to achieve a task."
                        },
                           new DispositionInstance
                        {
                            ID =6,
                            term_identifier = "Responsible",
                            cartesian_index = 6,
                            descriptor = "With Judgement / Discretion (Nwokeji et al., 2019) / Responsible (Clear, 2017) / Rectitude (Grey, 2015) Reflect on conditions and concerns, then acting according to what is appropriate to the situation. Making responsible assessments and taking actions using professional knowledge, experience, understanding and common sense. E.g., Responsibility, Professional astuteness (Grey, 2015)."

                        },
                           new DispositionInstance
                        {
                            ID =7,
                            term_identifier = "Adaptable",
                            cartesian_index = 7,
                            descriptor = "Adaptable (Nwokeji et al., 2019) / Flexible (Clear, 2017) / Agile (Weber, 2017) Ability or willingness to adjust approach in response to changing conditions or needs."

                        },
                           new DispositionInstance
                        {
                            ID =8,
                            term_identifier = "Collaborative",
                            cartesian_index = 8,
                            descriptor = "Collaborative (Weber, 2017) / Team Player (Clear, 2017) / Influencing (Nwokeji et al., 2019) Willingness to work with others; engaging appropriate involvement of other persons and organizations helpful to the task. Striving to be respectful and productive in achieving a common goal."
                        },
                           new DispositionInstance
                        {
                            ID =9,
                            term_identifier = "Responsive",
                            cartesian_index = 9,
                            descriptor = "Responsive (Weber, 2017) / Respectful (Clear, 2017) Reacting quickly and positively. Respecting the timing needs for communication and actions needed to achieve the goals of the work."

                        },
                           new DispositionInstance
                        {
                            ID =10,
                            term_identifier = "Meticulous",
                            cartesian_index = 10,
                            descriptor = "Attentive to Detail (Weber, 2017), (Nwokeji et al., 2019) Achieves thoroughness and accuracy when accomplishing a task through concern for relevant details."
                        }

                );
            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
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
    public class Seeding
    {
        public static ModelBuilder SeedSkillLevel(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<SkillLevel>(entity =>
            {
                entity.HasData(
                  new SkillLevel
                  {
                      ID = 1,
                      term_identifier = "Rembering",
                      cartesian_index = 1,
                      descriptor = "Exhibit memory of previously learned materials by recalling facts, terms, basic concepts, and answers."

                  },
                  new SkillLevel
                  {
                      ID = 2,
                      term_identifier = "Understanding",
                      cartesian_index = 2,
                      descriptor = "Demonstrate understanding of facts and ideas by organizing, comparing, translating, interpreting, giving descriptions, and stating main ideas."

                  },
                     new SkillLevel
                     {
                         ID = 3,
                         term_identifier = "Applying",
                         cartesian_index = 3,
                         descriptor = "Solve problems to new situations by applying acquired knowledge, facts, techniques and rules in a different way."

                     },
                     new SkillLevel
                     {
                         ID = 4,
                         term_identifier = "Analyzing",
                         cartesian_index = 4,
                         descriptor = "Examine and break information into parts by identifying motives or causes. Make inferences and find evidence to support generalizations."

                     },
                     new SkillLevel
                     {
                         ID = 5,
                         term_identifier = "Evaluating",
                         cartesian_index = 5,
                         descriptor = "Present and defend opinions by making judgments about information, validity of ideas, or quality of work based on a set of criteria."
                     },
                     new SkillLevel
                     {
                         ID = 6,
                         term_identifier = "Creating",
                         cartesian_index = 6,
                         descriptor = "Compile information together in a different way by combining elements in a new pattern or proposing alternative solutions."
                     }


                  );

            });
        }



        public static ModelBuilder SeedKnowledgeElement(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<KnowledgeElement>(entity =>
            {
                entity.HasData(
                  new KnowledgeElement
                  {
                      ID = 1,
                      term_identifier = "Coke",
                      cartesian_index = 1,
                      semiotic_index = 1,
                      descriptor = "Coca-Cola Revives and Sustains",
                      etymology = "Ursus maritimus"

                  },
                       new KnowledgeElement
                       {
                           ID = 2,
                           term_identifier = "Pepsi",
                           cartesian_index = 2,
                           semiotic_index = 2,
                           descriptor = "That's What I Like' – Variety",
                           etymology = "Marketing where Coke Doesnt"

                       },
                       new KnowledgeElement
                       {
                           ID = 3,
                           term_identifier = "Mountain Dew",
                           cartesian_index = 3,
                           semiotic_index = 3,
                           descriptor = "Do the Dew",
                           etymology = "Spy vs Spy"

                       },
                       new KnowledgeElement
                       {
                           ID = 4,
                           term_identifier = "Bawls",
                           cartesian_index = 4,
                           semiotic_index = 4,
                           descriptor = "The Best Soda you Havent Heard OF",
                           etymology = "Guarana"

                       },
                       new KnowledgeElement
                       {
                           ID = 5,
                           term_identifier = "RC Cola",
                           cartesian_index = 5,
                           semiotic_index = 5,
                           descriptor = "I wish this was a coke!",
                           etymology = "It was just a mirage!"

                       }
                  );

            });
        }
        public static ModelBuilder SeedDispositionInstance(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<DispositionInstance>(entity =>
            {
                entity.HasData(
                    new DispositionInstance
                    {
                        ID = 1,

                        term_identifier = "Proactive",
                        cartesian_index = 1,
                        descriptor = "With Initiative (Nwokeji, Stachel, & Holmes, 2019) / Self-Starter (Clear, 2017) Shows independence. Ability to assess and start activities independently without needing to be told what to do. Willing to take the lead, not waiting for others to start activities or wait for instructions."
                    },
                        new DispositionInstance
                        {
                            ID = 2,
                            term_identifier = "Self-Directed",
                            cartesian_index = 2,
                            descriptor = "Self-motivated (Clear, 2017) / Self-Directed (Nwokeji et al., 2019) Demonstrates determination to sustain efforts to continue tasks. Direction from others is not required to continue a task toward its desired ends."

                        },
                        new DispositionInstance
                        {
                            ID = 3,
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
                               ID = 5,
                               term_identifier = "Professional",
                               cartesian_index = 5,
                               descriptor = "With Professionalism / Work ethic (Nwokeji et al., 2019) Reflecting qualities connected with trained and skilled people: Acting honestly, with integrity, commitment, determination and dedication to what is required to achieve a task."
                           },
                           new DispositionInstance
                           {
                               ID = 6,
                               term_identifier = "Responsible",
                               cartesian_index = 6,
                               descriptor = "With Judgement / Discretion (Nwokeji et al., 2019) / Responsible (Clear, 2017) / Rectitude (Grey, 2015) Reflect on conditions and concerns, then acting according to what is appropriate to the situation. Making responsible assessments and taking actions using professional knowledge, experience, understanding and common sense. E.g., Responsibility, Professional astuteness (Grey, 2015)."

                           },
                           new DispositionInstance
                           {
                               ID = 7,
                               term_identifier = "Adaptable",
                               cartesian_index = 7,
                               descriptor = "Adaptable (Nwokeji et al., 2019) / Flexible (Clear, 2017) / Agile (Weber, 2017) Ability or willingness to adjust approach in response to changing conditions or needs."

                           },
                           new DispositionInstance
                           {
                               ID = 8,
                               term_identifier = "Collaborative",
                               cartesian_index = 8,
                               descriptor = "Collaborative (Weber, 2017) / Team Player (Clear, 2017) / Influencing (Nwokeji et al., 2019) Willingness to work with others; engaging appropriate involvement of other persons and organizations helpful to the task. Striving to be respectful and productive in achieving a common goal."
                           },
                           new DispositionInstance
                           {
                               ID = 9,
                               term_identifier = "Responsive",
                               cartesian_index = 9,
                               descriptor = "Responsive (Weber, 2017) / Respectful (Clear, 2017) Reacting quickly and positively. Respecting the timing needs for communication and actions needed to achieve the goals of the work."

                           },
                           new DispositionInstance
                           {
                               ID = 10,
                               term_identifier = "Meticulous",
                               cartesian_index = 10,
                               descriptor = "Attentive to Detail (Weber, 2017), (Nwokeji et al., 2019) Achieves thoroughness and accuracy when accomplishing a task through concern for relevant details."
                           }

                );
            });


        }


    }
}
// public static ModelBuilder SeedAtomic(ModelBuilder modelBuilder)
// {        
//     return modelBuilder.Entity<Atomic>(entity =>
//     {
//         entity.HasData(
//             new Atomic
//             {
//                 /*
//                 public int ID{get;set;}
//                 public string term_identifier{get;set;}
//                 public string prose_task_statement{get;set;}
//                 public ICollection<DispositionInstance> Dispositions{get;set;}
//                 public Dictionary<KnowledgeElement,SkillLevel> kspairs { get; set;} 
//                 */
//             }
//         );
//     });
// }
//  public static ModelBuilder SeedComposite(ModelBuilder modelBuilder)
// {        
//     return modelBuilder.Entity<Composite>(entity =>
//     {
//         entity.HasData(
//             new Composite
//             {
//                 /*
//                 public int ID{get;set;}
//                 public string term_identifier{get;set;}
//                 public string prose_task_statement{get;set;}
//                 public ICollection<DispositionInstance> Dispositions{get;set;}
//                 public ICollection<Atomic> atomics{get;set;}
//                 public ICollection<Composite> composites{get;set;}
//                 */

//             }

//         );
//     });
// }
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyData.Data.Models;
namespace MyData.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CDKSTContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CDKSTContext>>()))
            {

                context.Database.EnsureCreated();

                List<KnowledgeElement> knowledgeElements = null;
                List<SkillLevel> skillLevels = null;
                List<Disposition> dispositions = null;
          

                /* KNOWLEDGE ELEMENTS SEED */

                // Look for any KnowledgeElements.
                Task<KnowledgeElement> ke = context.KnowledgeElements.FirstOrDefaultAsync(k => k.Id == 1);

                if (ke.Result == null)
                {
                    knowledgeElements = new List<KnowledgeElement>(){
                        new KnowledgeElement{
                            Id = 1,
                            Name = "Control Structures",
                            Description = "selection, repetition, sequence",
                            CartesianIndex = 1,
                            SemioticIndex = 1,
                            Etymology = "Programming"
                        },
                        new KnowledgeElement{
                            Id = 2,
                            Name = "Design Patterns",
                            Description = "A general, reusable solution to a commonly occurring problem within a given context in software design",
                            CartesianIndex = 1,
                            SemioticIndex = 1,
                            Etymology = "Software Engineering"
                        },
                        new KnowledgeElement{
                            Id = 3,
                            Name = "Data Normalization",
                            Description = "The process of structuring a relational database in accordance with normal forms in order to reduce data redundancy and improve data integrity.",
                            CartesianIndex = 1,
                            SemioticIndex = 1,
                            Etymology = "Database"
                        },
                        new KnowledgeElement
                        {
                            Id = 4,
                            Name = "Coke",
                            CartesianIndex = 6,
                            SemioticIndex = 6,
                            Description = "Coca-Cola Revives and Sustains",
                            Etymology = "Ursus maritimus"

                        },
                            new KnowledgeElement
                            {
                                Id = 5,
                                Name = "Pepsi",
                                CartesianIndex = 2,
                                SemioticIndex = 2,
                                Description = "That's What I Like' – Variety",
                                Etymology = "Marketing where Coke Doesnt"

                            },
                            new KnowledgeElement
                            {
                                Id = 6,
                                Name = "Mountain Dew",
                                CartesianIndex = 3,
                                SemioticIndex = 3,
                                Description = "Do the Dew",
                                Etymology = "Spy vs Spy"

                            },
                            new KnowledgeElement
                            {
                                Id = 7,
                                Name = "Bawls",
                                CartesianIndex = 4,
                                SemioticIndex = 4,
                                Description = "The Best Soda you Havent Heard OF",
                                Etymology = "Guarana"

                            },
                            new KnowledgeElement
                            {
                                Id = 8,
                                Name = "RC Cola",
                                CartesianIndex = 5,
                                SemioticIndex = 5,
                                Description = "I wish this was a coke!",
                                Etymology = "It was just a mirage!"

                            }
                    };                

                    context.KnowledgeElements.AddRange(knowledgeElements);
                    context.SaveChanges();
                }


                /* SKILL LEVELS SEED */

                // Look for any SkillLevels.
                Task<SkillLevel> sl = context.SkillLevels.FirstOrDefaultAsync(s => s.Id == 1);

                if (sl.Result == null)
                {
                    skillLevels = new List<SkillLevel>(){
                        new SkillLevel{
                            Id = 1,
                            Name = "Remember",
                            Description = "Retrieve relevant knowledge from long-term memory.",
                            CartesianIndex = 1
                        },
                        new SkillLevel{
                            Id = 2,
                            Name = "Understand",
                            Description = "Construct meaning from instructional messages, including oral, written and graphic communication.",
                            CartesianIndex = 2
                        },
                        new SkillLevel{
                            Id = 3,
                            Name = "Apply",
                            Description = "Carry out or use a procedure in a given situation.",
                            CartesianIndex = 3
                        },          
                        new SkillLevel{
                            Id = 4,
                            Name = "Analyze",
                            Description = "Breaking materials or concepts into parts, determining how the parts relate to one another or how they interrelate, or how the parts relate to an overall structure or purpose.",
                            CartesianIndex = 4
                        },
                        new SkillLevel{
                            Id = 5,
                            Name = "Evaluate",
                            Description = "Make judgments based on criteria and standards.",
                            CartesianIndex = 5
                        },
                        new SkillLevel{
                            Id = 6,
                            Name = "Create",
                            Description = "Put elements together to form a coherent whole; reorganize into a new pattern or structure.",
                            CartesianIndex = 6
                        }
                    };

                    context.SkillLevels.AddRange(skillLevels);
                    context.SaveChanges();
                }

                /* DISPOSITIONS SEED */

                // Look for any SkillLevels.
                Task<Disposition> disp = context.Dispositions.FirstOrDefaultAsync(d => d.Id == 1);

                if (disp.Result == null)
                {
                    dispositions = new List<Disposition>(){
                        new Disposition 
                        {
                            Id = 1,
                            Name = "Proactive",
                            Category = "Habits",
                            Discipline = "Information Systems",
                            Description = @"With Initiative (Nwokeji, Stachel, & " +
                                            "Holmes, 2019) / Self-Starter (Clear, 2017) " +
                                            "Shows independence. Ability to assess and " +
                                            "start activities independently without needing " +
                                            "to be told what to do. Willing to take the lead, " +
                                            "not waiting for others to start activities or wait " +
                                            "for instructions."

                        },
                        new Disposition 
                        {
                            Id = 2,
                            Name = "Purpose-Driven",
                            Category = "Qualities",
                            Discipline = "Information Systems",
                            Description = @"Purposefully engaged / Purposefulness " +
                                            "(Nwokeji et al., 2019), (Clear, 2017) " +
                                            "Goal-directed, intentionally acting and " +
                                            "committed to achieve organizational and " +
                                            "project goals. Reflects an attitude towards " +
                                            "the organizational goals served by decisions, " +
                                            "work or work products. e.g., Business acumen."

                        },
                        new Disposition 
                        {
                            Id = 3,
                            Name = "Self-Directed",
                            Category = "Qualities",
                            Discipline = "Information Systems",
                            Description = @"Self-motivated (Clear, 2017) / Self-Directed " +
                                            "(Nwokeji et al., 2019) Demonstrates determination " +
                                            "to sustain efforts to continue tasks. Direction " +
                                            "from others is not required to continue a task " +
                                            "toward its desired ends."
                        }, 
                        new Disposition
                        {
                            Id = 4,
                            Name = "Passionate",
                            Category = "Qualities",
                            Discipline = "Information Systems",
                            Description = "With Passion (Nwokeji et al., 2019), (Clear, 2017) / Conviction (Gray, 2015) Strongly committed to and enthusiastic about the realization of the task or goal. Makes the compelling case for the success and benefits of task, project, team or means of achieving goals."

                        },
                          
                           new Disposition
                           {
                               Id = 5,
                               Name = "Professional",
                               Category = "Qualities",
                               Discipline = "Information Systems",
                               Description = "With Professionalism / Work ethic (Nwokeji et al., 2019) Reflecting qualities connected with trained and skilled people: Acting honestly, with integrity, commitment, determination and dedication to what is required to achieve a task."
                           },
                           new Disposition
                           {
                               Id = 6,
                               Name = "Responsible",
                               Category = "Qualities",
                               Discipline = "Information Systems",
                               Description = "With Judgement / Discretion (Nwokeji et al., 2019) / Responsible (Clear, 2017) / Rectitude (Grey, 2015) Reflect on conditions and concerns, then acting according to what is appropriate to the situation. Making responsible assessments and taking actions using professional knowledge, experience, understanding and common sense. E.g., Responsibility, Professional astuteness (Grey, 2015)."

                           },
                           new Disposition
                           {
                               Id = 7,
                               Name = "Adaptable",
                               Category = "Qualities",
                               Discipline = "Information Systems",
                               Description = "Adaptable (Nwokeji et al., 2019) / Flexible (Clear, 2017) / Agile (Weber, 2017) Ability or willingness to adjust approach in response to changing conditions or needs."

                           },
                           new Disposition
                           {
                               Id = 8,
                               Name = "Collaborative",
                               Category = "Qualities",
                               Discipline = "Information Systems",
                               Description = "Collaborative (Weber, 2017) / Team Player (Clear, 2017) / Influencing (Nwokeji et al., 2019) Willingness to work with others; engaging appropriate involvement of other persons and organizations helpful to the task. Striving to be respectful and productive in achieving a common goal."
                           },
                           new Disposition
                           {
                               Id = 9,
                               Name = "Responsive",
                               Category = "Habits",
                               Discipline = "Information Systems",
                               Description = "Responsive (Weber, 2017) / Respectful (Clear, 2017) Reacting quickly and positively. Respecting the timing needs for communication and actions needed to achieve the goals of the work."

                           },
                           new Disposition
                           {
                               Id = 10,
                               Name = "Meticulous",
                               Category = "Habits",
                               Discipline = "Information Systems",
                               Description = "Attentive to Detail (Weber, 2017), (Nwokeji et al., 2019) Achieves thoroughness and accuracy when accomplishing a task through concern for relevant details."
                           }
                    };                

                    context.Dispositions.AddRange(dispositions);
                    context.SaveChanges();                    
                }     

                /* ATOMIC COMPETENCIES SEED */

                // Look for any SkillLevels.
                Task<Competency> comp = context.Competencies.FirstOrDefaultAsync(d => d.Id == 1);

                if (comp.Result == null){
                    //LIST 1 DISPOSITIONS FOR A COMP
                    List<CompetencyDisposition> cdList1 =  new List<CompetencyDisposition>{
                        new CompetencyDisposition{
                            Id =  1,
                            Disposition = dispositions[0]
                        },
                        new CompetencyDisposition{
                            Id = 2,
                            Disposition = dispositions[1]
                        }
                    };
                    //LIST 2 DISPOSITIONS FOR A COMP
                     List<CompetencyDisposition> cdList2 =  new List<CompetencyDisposition>{
                        new CompetencyDisposition{
                            Id =  3,
                            Disposition = dispositions[2]
                        },
                        new CompetencyDisposition{
                            Id = 4,
                            Disposition = dispositions[3]
                        },
                        new CompetencyDisposition{
                            Id = 5,
                            Disposition = dispositions[4]
                        }
                    };
                    //LIST 3 DISPOSITIONS FOR A COMP
                     List<CompetencyDisposition> cdList3 =  new List<CompetencyDisposition>{
                        new CompetencyDisposition{
                            Id =  6,
                            Disposition = dispositions[5]
                        },
                        new CompetencyDisposition{
                            Id = 7,
                            Disposition = dispositions[6]
                        },
                        new CompetencyDisposition{
                            Id = 8,
                            Disposition = dispositions[7]
                        }
                    };
                    //LIST 4 DISPOSITIONS FOR A COMP
                     List<CompetencyDisposition> cdList4 =  new List<CompetencyDisposition>{
                        new CompetencyDisposition{
                            Id =  9,
                            Disposition = dispositions[0]
                        },
                        new CompetencyDisposition{
                            Id = 10,
                            Disposition = dispositions[8]
                        },
                        new CompetencyDisposition{
                            Id = 11,
                            Disposition = dispositions[7]
                        }
                    };
                    //LIST 5 DISPOSITIONS FOR A COMP
                     List<CompetencyDisposition> cdList5 =  new List<CompetencyDisposition>{
                        new CompetencyDisposition{
                            Id =  12,
                            Disposition = dispositions[2]
                        },
                        new CompetencyDisposition{
                            Id = 13,
                            Disposition = dispositions[9]
                        },
                        new CompetencyDisposition{
                            Id = 14,
                            Disposition = dispositions[8]
                        }
                    };
                    //LIST 1 KSPAIRS
                    List<KSPair> kSPairs1 = new List<KSPair>{
                        new KSPair{
                            Id =1,
                            KnowledgeElement = knowledgeElements[0],
                            SkillLevel = skillLevels[5],
                        },
                        new KSPair{
                            Id =2,
                            KnowledgeElement = knowledgeElements[1],
                            SkillLevel = skillLevels[4]
                        }
                    };

                   //LIST 2 KSPAIRS
                    List<KSPair> kSPairs2 = new List<KSPair>{
                           
                        new KSPair{
                            Id =3,
                            KnowledgeElement = knowledgeElements[0],
                            SkillLevel = skillLevels[5],
                        },
                        new KSPair{
                            Id =4,
                            KnowledgeElement = knowledgeElements[1],
                            SkillLevel = skillLevels[4]
                        }
                    };
                    //LIST 3 KSPAIRS
                    List<KSPair> kSPairs3 = new List<KSPair>{
                         
                        new KSPair{
                              Id =5,
                            KnowledgeElement = knowledgeElements[6],
                            SkillLevel = skillLevels[2],
                        },
                        new KSPair{
                              Id =6,
                            KnowledgeElement = knowledgeElements[0],
                            SkillLevel = skillLevels[3]
                        },
                         new KSPair{
                               Id =7,
                            KnowledgeElement = knowledgeElements[2],
                            SkillLevel = skillLevels[3]
                        }
                    };
                    //LIST 4 KSPAIRS
                    List<KSPair> kSPairs4 = new List<KSPair>{
                           
                        new KSPair{
                              Id =8,
                            KnowledgeElement = knowledgeElements[6],
                            SkillLevel = skillLevels[1],
                        },
                        new KSPair{
                            Id =9,
                            KnowledgeElement = knowledgeElements[7],
                            SkillLevel = skillLevels[2]
                        },
                          new KSPair{
                              Id =10,
                            KnowledgeElement = knowledgeElements[5],
                            SkillLevel = skillLevels[5],
                        },
                        new KSPair{
                            Id =11,
                            KnowledgeElement = knowledgeElements[4],
                            SkillLevel = skillLevels[5]
                        }
                    };
                    

                 
                   AtomicCompetency atom1 = new AtomicCompetency{ 
                        Id = 1,
                        Name = "Ichiban",
                        Description = "The Best",
                        CompetencyDispostions = cdList2,
                        KSPairs = kSPairs1
                    };
                       context.Competencies.Add(atom1);
                    context.SaveChanges(); 
                   AtomicCompetency atom2 = new AtomicCompetency{
                        Id = 2,
                        Name = "Niban",
                        Description = "The First Loser",
                        CompetencyDispostions = cdList1,
                        KSPairs = kSPairs2
                    };
                        context.Competencies.Add(atom2);
                    context.SaveChanges(); 
                   AtomicCompetency atom3 = new AtomicCompetency{
                        Id = 3,
                        Name = "Sanban",
                        Description = "The Bronze Medal",
                        CompetencyDispostions = cdList3,
                        KSPairs = kSPairs3
                    };
                    context.Competencies.Add(atom3);
                    context.SaveChanges(); 
                   AtomicCompetency atom4 = new AtomicCompetency{
                        Id = 4,
                        Name = "Yonban",
                        Description = "Complete Trash",
                        CompetencyDispostions = cdList4,
                        KSPairs = kSPairs4
                    };
             
     
                    context.Competencies.Add(atom4);
                    context.SaveChanges(); 
            
                }
            }
        }
    }
}
            
                
    


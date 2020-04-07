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
            /*
                {
    "model": "skill.skillverbsynonym",
    "pk": "a57b905f-1a12-4699-a233-77c7238a2389",
    "fields": {
        "text": "Solid!",
        "language": "English"
    }
},
{
    "model": "skill.skillverbsynonym",
    "pk": "78113dc0-3a88-4297-9e2c-c6a9c9116836",
    "fields": {
        "text": "Gas",
        "language": "English"
    }
},
{
    "model": "skill.skilllevel",
    "pk": "8e6a3bbb-1bd9-49c2-8062-35f827e59ca3",
    "fields": {
        "term_identifier": "Rembering",
        "cartesian_index": 1,
        "descriptor": "Exhibit memory of previously learned materials by recalling facts, terms, basic concepts, and answers.",
        "synonyms": [
            "a57b905f-1a12-4699-a233-77c7238a2389"
        ]
    }
},
{
    "model": "skill.skilllevel",
    "pk": "68969544-771d-4e03-ae20-eec24318784e",
    "fields": {
        "term_identifier": "Understanding",
        "cartesian_index": 2,
        "descriptor": "Demonstrate understanding of facts and ideas by organizing, comparing, translating, interpreting, giving descriptions, and stating main ideas.",
        "synonyms": [
            "78113dc0-3a88-4297-9e2c-c6a9c9116836"
        ]
    }
},
{
    "model": "skill.skilllevel",
    "pk": "7b4fbe83-3c5e-48a4-957e-1846fa16a74f",
    "fields": {
        "term_identifier": "Applying",
        "cartesian_index": 3,
        "descriptor": "Solve problems to new situations by applying acquired knowledge, facts, techniques and rules in a different way.",
        "synonyms": [
            "78113dc0-3a88-4297-9e2c-c6a9c9116836"
        ]
    }
},
{
    "model": "skill.skilllevel",
    "pk": "b372a418-cae7-48c3-bae7-f903bad06d27",
    "fields": {
        "term_identifier": "Analyzing",
        "cartesian_index": 4,
        "descriptor": "Examine and break information into parts by identifying motives or causes. Make inferences and find evidence to support generalizations.",
        "synonyms": [
            "78113dc0-3a88-4297-9e2c-c6a9c9116836"
        ]
    }
},
{
    "model": "skill.skilllevel",
    "pk": "b3aab73b-4060-4260-9343-9abbe4c13b18",
    "fields": {
        "term_identifier": "Evaluating",
        "cartesian_index": 5,
        "descriptor": "Present and defend opinions by making judgments about information, validity of ideas, or quality of work based on a set of criteria.",
        "synonyms": [
            "78113dc0-3a88-4297-9e2c-c6a9c9116836"
        ]
    }
},
{
    "model": "skill.skilllevel",
    "pk": "cee45b12-4082-4600-bae6-46ed5a6efb66",
    "fields": {
        "term_identifier": "Creating",
        "cartesian_index": 6,
        "descriptor": "Compile information together in a different way by combining elements in a new pattern or proposing alternative solutions.",
        "synonyms": [
            "78113dc0-3a88-4297-9e2c-c6a9c9116836"
        ]
    }
},*/
            return modelBuilder.Entity<SkillLevel>(entity =>
            {
                  entity.HasData(
                    new SkillLevel   
                    {
                        ID = 1,

                        term_identifier = "Proactive",
                        cartesian_index = 1,
                        descriptor = "With Initiative (Nwokeji, Stachel, & Holmes, 2019) / Self-Starter (Clear, 2017) Shows independence. Ability to assess and start activities independently without needing to be told what to do. Willing to take the lead, not waiting for others to start activities or wait for instructions."
                    }
                    );

            });
        }



public static ModelBuilder SeedKnowledgeElement(ModelBuilder modelBuilder)
        {
            /*
            {
    "model": "knowledge.knowledgesynonym",
    "pk": "20f7a9e3-f9a7-4111-96e5-cc87cb851f92",
    "fields": {
        "text": "Clouds",
        "language": "English"
    }
},
{
    "model": "knowledge.knowledgesynonym",
    "pk": "f96a0eaf-3d1c-4d0a-b9fa-a8c002cfcbb2",
    "fields": {
        "text": "Temperature",
        "language": "English"
    }
},
{
    "model": "knowledge.knowledgeelement",
    "pk": "e7ed495c-1502-4966-92f8-ad344451f260",
    "fields": {
        "term_identifier": "Life",
        "cartesian_index": 6,
        "semiotic_index": 8,
        "descriptor": "Can this planet support life?",
        "etymology": "test",
        "synonyms": [
            "20f7a9e3-f9a7-4111-96e5-cc87cb851f92"
        ],
        "skills":"68969544-771d-4e03-ae20-eec24318784e"
    }
},
{
    "model": "knowledge.knowledgeelement",
    "pk": "33f7c0e2-4271-4e6f-b042-aee4790394dc",
    "fields": {
        "term_identifier": "Rocks",
        "cartesian_index": 5,
        "semiotic_index": 5,
        "descriptor": "Rocky planet?",
        "etymology": "kn o",
        "synonyms": [
            "f96a0eaf-3d1c-4d0a-b9fa-a8c002cfcbb2"
        ],
        "skills": "b3aab73b-4060-4260-9343-9abbe4c13b18"
        
    }
},
{
    "model": "knowledge.knowledgeelement",
    "pk": "e7ed495c-1502-4966-92f8-ad344451f260",
    "fields": {
        "term_identifier": "Life",
        "cartesian_index": 6,
        "semiotic_index": 8,
        "descriptor": "Can this planet support life?",
        "etymology": "test",
        "synonyms": [
            "20f7a9e3-f9a7-4111-96e5-cc87cb851f92"
        ],
        "skills":"68969544-771d-4e03-ae20-eec24318784e"
    }
},
{
    "model": "knowledge.knowledgeelement",
    "pk": "5b2ebca6-4ffb-49fb-8985-eb73567d233f",
    "fields": {
        "term_identifier": "Pepsi",
        "cartesian_index": 4,
        "semiotic_index": 4,
        "descriptor": "Cool Refreshing Taste",
        "etymology": "Better than Coke",
        "synonyms": [
            "f96a0eaf-3d1c-4d0a-b9fa-a8c002cfcbb2"
        ],
        "skills": "b3aab73b-4060-4260-9343-9abbe4c13b18"
        
    }
},
{
    "model": "knowledge.knowledgeelement",
    "pk": "5db91aa2-f658-41c0-9ea2-ff851d767c61",
    "fields": {
        "term_identifier": "Mtn Dew",
        "cartesian_index": 3,
        "semiotic_index": 3,
        "descriptor": "Do the Dew",
        "etymology": "Citrus",
        "synonyms": [
            "f96a0eaf-3d1c-4d0a-b9fa-a8c002cfcbb2"
        ],
        "skills": "b3aab73b-4060-4260-9343-9abbe4c13b18"
        
    }
},
{
            
            */

            return modelBuilder.Entity<SkillLevel>(entity =>
            {
                  entity.HasData(
                    new SkillLevel   
                    {
                        ID = 1,

                        term_identifier = "Proactive",
                        cartesian_index = 1,
                        descriptor = "With Initiative (Nwokeji, Stachel, & Holmes, 2019) / Self-Starter (Clear, 2017) Shows independence. Ability to assess and start activities independently without needing to be told what to do. Willing to take the lead, not waiting for others to start activities or wait for instructions."
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














/*
[




    "model": "competencies.atomiccompetency",
    "pk": "a893592b-7fc0-489f-9904-cd642ec91ae8",
    "fields": {
        "term_identifier": "First One",
        "prose_task_statement": "This is the first Competency",
        "disposition": [ "e8a7bc3c-92f1-4330-9a4e-c91d51c3aeed","4afa6240-7d61-4e62-9581-2f1467f363ae","da52bdaf-e8aa-4377-8f18-57c04fd96569", "b33e20e9-f807-4668-86aa-5dda9a773d2b"],
        "KnowledgeElement": ["5db91aa2-f658-41c0-9ea2-ff851d767c61","e7ed495c-1502-4966-92f8-ad344451f260"]
    }

},
{
    "model": "competencies.atomiccompetency",
    "pk": "f4eaebca-a1f9-49ef-ba28-34896afe7cf8",
    "fields": {
        "term_identifier": "Second One",
        "prose_task_statement": "This is the Second Competency",
        "disposition":[ "b33e20e9-f807-4668-86aa-5dda9a773d2b", "e8a7bc3c-92f1-4330-9a4e-c91d51c3aeed"],
        "KnowledgeElement": ["33f7c0e2-4271-4e6f-b042-aee4790394dc","5db91aa2-f658-41c0-9ea2-ff851d767c61","5b2ebca6-4ffb-49fb-8985-eb73567d233f"]
    }
},
{
    "model": "competencies.atomiccompetency",
    "pk": "42ec6b41-4537-4aa6-99f7-cc9e5bfc844f",
    "fields": {
        "term_identifier": "Third One",
        "prose_task_statement": "This is the Third Competency",
        "disposition": ["b33e20e9-f807-4668-86aa-5dda9a773d2b","4afa6240-7d61-4e62-9581-2f1467f363ae","e8a7bc3c-92f1-4330-9a4e-c91d51c3aeed"],
        "KnowledgeElement": ["5db91aa2-f658-41c0-9ea2-ff851d767c61","e7ed495c-1502-4966-92f8-ad344451f260"]
    }

},
{
    "model": "competencies.atomiccompetency",
    "pk": "3cab50ae-b98a-4495-a3e7-6feb2bc6e531",
    "fields": {
        "term_identifier": "Fourth One",
        "prose_task_statement": "This is the Fourth Competency",
        "disposition": ["cbf268f4-5664-4947-a8ad-1087fbacf52e","4afa6240-7d61-4e62-9581-2f1467f363ae", "63a8c743-29ba-4809-8839-1003e83a8033"],
        "KnowledgeElement": ["33f7c0e2-4271-4e6f-b042-aee4790394dc","5db91aa2-f658-41c0-9ea2-ff851d767c61","5b2ebca6-4ffb-49fb-8985-eb73567d233f"]
    }

},
{
    "model": "competencies.atomiccompetency",
    "pk": "91a46d9b-c824-4cb2-96b0-e70763573299",
    "fields": {
        "term_identifier": "Fifth One",
        "prose_task_statement": "This is the Fifth Competency",
        "disposition": ["63a8c743-29ba-4809-8839-1003e83a8033","cbf268f4-5664-4947-a8ad-1087fbacf52e"],
        "KnowledgeElement": ["5db91aa2-f658-41c0-9ea2-ff851d767c61","e7ed495c-1502-4966-92f8-ad344451f260","33f7c0e2-4271-4e6f-b042-aee4790394dc"]
    }

}
]



*/
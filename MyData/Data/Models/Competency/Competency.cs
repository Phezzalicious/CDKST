using System;
using System.Collections.Generic;
using MyData.Data.Models.Knowledge;
using MyData.Data.Models.Disposition;
using MyData.Data.Models.Skill;

namespace MyData.Data.Models.Competency
{
    public class Competency
    {
        public int ID { get; set; }
        public string term_identifier { get; set; }
        public string prose_task_statement { get; set; }
        public IEnumerable<DispositionInstance> Dispositions { get; set; }
    }
       public class KnowledgeSkill
    {
        public int ID{get;set;}
        public KnowledgeElement knowledge { get; set; }
        public SkillLevel skill { get; set; }
    }
    public class Atomic : Competency
    {
        public IEnumerable<KnowledgeSkill> kspairs { get; set; }
    }
    public class Composite : Competency
    {
        public IEnumerable<Competency> competencies { get; set; }
    }
}





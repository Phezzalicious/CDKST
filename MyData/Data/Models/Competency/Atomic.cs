using System;
using System.Collections.Generic;
using MyData.Data.Models.Knowledge;
using MyData.Data.Models.Skill;

namespace MyData.Data.Models.Competency
{
    public class Atomic:Competency
    {
    
        public Dictionary<KnowledgeElement,SkillLevel> kspairs { get; set; }  




    }
}





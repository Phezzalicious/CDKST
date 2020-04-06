using System;
using System.Collections.Generic;
using MyData.Data.Models.Skill;
using MyData.Data.Models.Knowledge;

namespace MyData.Data.Models.Competency
{
    public class KnowledgeSkill
    {
       public int ID{get;set;}
       public KnowledgeElement knowledge;
       public SkillLevel knowledgeLevel;
    }
}
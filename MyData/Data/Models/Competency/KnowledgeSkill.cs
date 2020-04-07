using System;
using System.Collections.Generic;
using MyData.Data.Models.Knowledge;
using MyData.Data.Models.Skill;

namespace MyData.Data.Models.Competency
{
    public class KnowledgeSkill
    {
    public int ID{get;set;}
     public KnowledgeElement knowledgeElement{get;set;}
     public SkillLevel skillLevel{get;set;}




    }
}
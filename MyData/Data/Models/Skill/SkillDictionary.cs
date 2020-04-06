using System.Collections.Generic;

namespace MyData.Data.Models.Skill
{
    public class SkillDictionary
    {
        public int ID{get;set;}
        public string category{get;set;}
        public string discipline{get;set;}
        public string description{get;set;}
        public ICollection<SkillLevel> skillLevels{get;set;}




    }
}
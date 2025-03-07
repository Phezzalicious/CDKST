using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyData.Data.Models
{
    public class KSPair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public KnowledgeElement KnowledgeElement {get; set;}        
        public SkillLevel SkillLevel {get; set;}
        public int AtomicCompetencyId{get; set;}    
        public AtomicCompetency AtomicCompetency{get; set;}
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyData.Data.Models
{
    public class ConstituentCompetency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public Competency MemberCompetency{get; set;}

        [ForeignKey("Competency")]
        public int CompetencyId{get; set;}    
        public Competency Competency{get; set;}        
    }
}
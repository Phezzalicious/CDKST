using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyData.Data.Models
{
    public class CompetencyDisposition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public Disposition Disposition{get; set;}

        public int CompetencyId{get; set;}    
        public Competency Competency{get; set;}
    }
}
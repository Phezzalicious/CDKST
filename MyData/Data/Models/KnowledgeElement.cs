using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyData.Data.Models
{
    public class KnowledgeElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        public string Name {get; set;}
        [DataType(DataType.Text)]
        public string Description {get; set;}

        [Display(Name = "Cartesian Index")]
        public int CartesianIndex {get; set;}
        
        [Display(Name = "Semiotic Index")]        
        public int SemioticIndex {get; set;}
        public string Etymology {get; set;}
    }
}
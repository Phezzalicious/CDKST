using System;
using System.Collections.Generic;
using MyData.Data.Models.Knowledge;
using MyData.Data.Models.Disposition;

namespace MyData.Data.Models.Competency
{
    public class Competency
    {
        public int ID{get;set;}
        public string term_identifier{get;set;}
        public string prose_task_statement{get;set;}
        public ICollection<DispositionInstance> Dispositions{get;set;}
     




    }
}





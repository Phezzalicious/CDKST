using System;
using System.Collections.Generic;
using MyData.Data.Models.Knowledge;
using MyData.Data.Models.Disposition;

namespace MyData.Data.Models.Competency
{
    public class Composite: Competency
    {
       
        public ICollection<Atomic> atomics{get;set;}


        public ICollection<Composite> composites{get;set;}
    

    }
}





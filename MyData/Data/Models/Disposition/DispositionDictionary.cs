using System;
using System.Collections.Generic;

namespace MyData.Data.Models.Disposition
{
    public class DispositionDictionary
    {
        public int ID{get;set;}
        public string category{get;set;}
        public string discipline{get;set;}
        public string description{get;set;}
    
   
        public ICollection<DispositionInstance> dispositionInstances{get;set;}



    }
}
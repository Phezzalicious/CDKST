using System;
using System.Collections.Generic;

namespace MyData.Data.Models.Knowledge
{
    public class KnowledgeElement
    {
        public int ID{get;set;}
        public string term_identifier{get;set;}
        public int cartesian_index{get;set;}
        public int semiotic_index{get;set;}
        public string descriptor{get;set;}
        public string etymology{get;set;}
        public ICollection<KnowledgeSynonym> synonym{get;set;}



    }
}
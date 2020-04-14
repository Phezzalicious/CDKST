using System.Collections.Generic;
using MyData.Data.Models;



///Overloaded methods to get a new id that doesnt conflict with whatever list I pass it

namespace CDKST.Pages.Wizard{
      class IDMachine
    {
        private int newID = 1;
        private bool needID = true;
        public int getNewID(List<Competency> entities)
        {
           
            while (needID)
            {
                foreach (var item in entities)
                {
                    needID = false;
                    if (newID == item.Id)
                    {
                        newID++;
                        needID = true;
                    }
                }
            }
            return newID;
        }
        public int getNewID(List<CompetencyDisposition> entities)
        {
            
            while (needID)
            {
                foreach (var item in entities)
                {
                    needID = false;
                    if (newID == item.Id)
                    {
                        newID++;
                        needID = true;
                    }
                }
            }
            return newID;
        }
        public int getNewID(List<KSPair> entities)
        {
      
            while (needID)
            {
                foreach (var item in entities)
                {
                    needID = false;
                    if (newID == item.Id)
                    {
                        newID++;
                        needID = true;
                    }
                }
            }
            return newID;
        }
    }
}
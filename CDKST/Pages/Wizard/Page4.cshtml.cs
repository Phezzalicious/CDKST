using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using MyData.Data.Models;
using MyRepo;
using CDKST.ViewModels;

namespace CDKST.Pages.Wizard
{
    public class Page4Model : PageModel
    {
         public const string SerializedCompetencyJSONKey = "_CompetencySerliazed";

        [BindProperty]
        [Display(Name="Competency Name")]
        public string CompetencyName {get; set;}

        [BindProperty]
        [Display(Name="Competency Description")]        
        public string CompetencyDescription {get; set;}
        [BindProperty]
        [Display(Name="Dispositions")]        
        public int[] DispositionIndicies {get; set;}
        [BindProperty]
        [Display(Name="KSPairsIndicies")]        
        public int[] KSPairsIndicies {get; set;}
        
        
    
        [BindProperty]
        public List<KnowledgeSelectorModel> KnowledgeDisplayList  {get; set;}
         [BindProperty]    
        public IEnumerable<SkillLevel>  Slist {get; set;}
  


        public CompetencyBuilderViewModel Cbvm {get; set;}

        private readonly ILogger<Page1Model> _logger;
        private readonly IUnitOfWork _UOW;        

        public Page4Model(ILogger<Page1Model> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;
        }


        public async Task OnGetAsync()
        //I am having the user pick knowledge elements and determining their skill levels. 
        //I will need all the knowledges and skills from the database to use on the .cshtml side
        {
            _logger.Log(LogLevel.Information, "Page 4 onGet");
            //wheres my session at
            await HttpContext.Session.LoadAsync();            
            //read serialized object from session variable
            var serializedin = HttpContext.Session.GetString(SerializedCompetencyJSONKey);
            //save it to Cbvm
            Cbvm = JsonSerializer.Deserialize<CompetencyBuilderViewModel>(serializedin);
            //fill my variables with the session contents
            CompetencyName = Cbvm.CompetencyName;
            CompetencyDescription = Cbvm.CompetencyDescription;
            DispositionIndicies = Cbvm.DispositionIndicies;
            //Make the Units of work (RepositoryAsyncs) I need. Know, Skill
            var repositoryK = _UOW.GetRepositoryAsync<KnowledgeElement>();
            var repositoryS = _UOW.GetRepositoryAsync<SkillLevel>();
            //Grab all the knowledges
            IEnumerable<KnowledgeElement> klist = await repositoryK.GetListAsync();
            //grab all the skills
            IEnumerable<SkillLevel> slist = await repositoryS.GetListAsync();

            //Makes my list of viewmodel objects to save the kspairs ----- Utility Method at Bottom of File
            KnowledgeDisplayList = GetKnowledgeDisplayList(klist.ToList());

            //Save these so I can display them in the form dropdown
            Slist=slist;
           
           
            // _logger.LogInformation($"COMPNAME: {CompetencyName}");
            // _logger.LogInformation($"COMPDESCR: {CompetencyDescription}");
            // _logger.LogInformation($"DISPINDICE: {DispositionIndicies[0]}");
            // _logger.LogInformation($"KDISPLIST: {KnowledgeDisplayList.Count()}");




        }
         public async Task<IActionResult>  OnPostAsync(){

            _logger.LogInformation("IN ON POST ASYNC Page 4");
            //_logger.LogInformation("KNOWLEDGEDISPLAYLIST: "+ KnowledgeDisplayList.Count());

            //Where My Session At? 
            await HttpContext.Session.LoadAsync();

           //temporary list of integers to hold my unkown amount kspairindices
            List<int> temp = new List<int>();
            foreach(KnowledgeSelectorModel ksm in KnowledgeDisplayList)
            {
                //  _logger.LogInformation("In my FOREACH");
                if(ksm.Selected){
                    //populate my list, even indices will be my knowledgeElement Ids and Odd will be the correlated Skill Ids
                    temp.Add(ksm.Id);
                    temp.Add(ksm.SkillLevel);

                    // _logger.LogInformation($"Added: {ksm.Id.ToString()} to the indicies");
                    // _logger.LogInformation(ksm.Name);
                }
            }  

            //Save the carefully constructed result to my KSPairIndicies, casting it fro ma list to an array    
            KSPairsIndicies =  temp.ToArray();       
        
            //_logger.LogInformation("temp : " + temp[0]);
            //_logger.LogInformation("KS : " + KSPairsIndicies[0]);
          
            //is my session variable null?
            if(string.IsNullOrEmpty(HttpContext.Session.GetString(SerializedCompetencyJSONKey)))
            {
                //if so, make a new one 
                Cbvm = new CompetencyBuilderViewModel();

                //fill it with what i want
                Cbvm.CompetencyName = CompetencyName;
                Cbvm.CompetencyDescription = CompetencyDescription;
                Cbvm.DispositionIndicies = DispositionIndicies; 
                Cbvm.KSPairsIndicies = KSPairsIndicies;  

                //pack it up 
                var serialized = JsonSerializer.Serialize(Cbvm);

                //send it out
                HttpContext.Session.SetString(SerializedCompetencyJSONKey, serialized);

            }else {
                //open my object
                var serializedin = HttpContext.Session.GetString(SerializedCompetencyJSONKey);
                Cbvm = JsonSerializer.Deserialize<CompetencyBuilderViewModel>(serializedin);

                //fill it with what i want
                Cbvm.CompetencyName = CompetencyName;
                Cbvm.CompetencyDescription = CompetencyDescription;
                Cbvm.DispositionIndicies = DispositionIndicies;  
                Cbvm.KSPairsIndicies = KSPairsIndicies;
                // _logger.LogInformation($"IN POST PAGE 4, Session out: {CompetencyName}");
                // _logger.LogInformation($"IN POST PAGE 4, Session out: {Cbvm.CompetencyName}");
                // _logger.LogInformation($"IN POST PAGE 4, Session out: {CompetencyDescription}");
                // _logger.LogInformation($"IN POST PAGE 4, Session out: {Cbvm.CompetencyDescription}");
                // _logger.LogInformation($"IN POST PAGE 4, Session out: {DispositionIndicies[0]}");
                // _logger.LogInformation($"IN POST PAGE 4, Session out: {Cbvm.DispositionIndicies}");                
                //_logger.LogInformation($"IN POST PAGE 4, Session out: {Cbvm.KSPairsIndicies[0]}");

                //pack it up 
                var serializedout = JsonSerializer.Serialize(Cbvm);
                //_logger.LogInformation($"IN POST PAGE 4, Serialized out: {serializedout.ToString()}");

                //send it out
                HttpContext.Session.SetString(SerializedCompetencyJSONKey, serializedout);                
            }

            _logger.LogInformation($"I AM ABOUT TO REDIRECT TO PAGE 6");
            return RedirectToPage("/Wizard/Page6");

        }
        private List<KnowledgeSelectorModel> GetKnowledgeDisplayList(List<KnowledgeElement> list){
            List<KnowledgeSelectorModel> outlist = new List<KnowledgeSelectorModel>();

            foreach(KnowledgeElement k in list){
                KnowledgeSelectorModel ksm = new KnowledgeSelectorModel();
                ksm.Id = k.Id;
                ksm.Name = k.Name;
                ksm.Description = k.Description;
                ksm.CartesianIndex = k.CartesianIndex;
                ksm.SemioticIndex = k.SemioticIndex;
                ksm.Etymology = k.Etymology;
                ksm.Selected = false;
                //I dont know what it will do if i dont assign it here. I think its fair to say if you picked the knowledge element you need at least skill level 1.
                ksm.SkillLevel = 0;
                outlist.Add(ksm);
            }

            return outlist;
        } 

    }
}




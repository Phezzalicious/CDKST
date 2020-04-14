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
        {
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
            var repositoryK = _UOW.GetRepositoryAsync<KnowledgeElement>();
            var repositoryS = _UOW.GetRepositoryAsync<SkillLevel>();
            IEnumerable<KnowledgeElement> klist = await repositoryK.GetListAsync();
            IEnumerable<SkillLevel> slist = await repositoryS.GetListAsync();
            KnowledgeDisplayList = GetKnowledgeDisplayList(klist.ToList());
            Slist=slist;
           
            _logger.Log(LogLevel.Information, "Page 4 onGet");
            _logger.LogInformation($"COMPNAME: {CompetencyName}");
            _logger.LogInformation($"COMPDESCR: {CompetencyDescription}");
            _logger.LogInformation($"DISPINDICE: {DispositionIndicies[0]}");
            _logger.LogInformation($"KDISPLIST: {KnowledgeDisplayList.Count()}");




        }
         public async Task<IActionResult>  OnPostAsync(){

            _logger.LogInformation("IN ON POST ASYNC");
            _logger.LogInformation("KNOWLEDGEDISPLAYLIST: "+ KnowledgeDisplayList.Count());

            await HttpContext.Session.LoadAsync();
            //store my indicies, first dimension is each knowledge selector model and second dimension is knowledge - skill id
             List<int> temp = new List<int>();
            foreach(KnowledgeSelectorModel ksm in KnowledgeDisplayList)
            {
                 _logger.LogInformation("In my FOREACH");
                if(ksm.Selected){
                    temp.Add(ksm.Id);
                    temp.Add(ksm.SkillLevel);
                    _logger.LogInformation($"Added: {ksm.Id.ToString()} to the indicies");
                    _logger.LogInformation(ksm.Name);
                }
            }      
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
                _logger.LogInformation($"IN POST PAGE 4, Session out: {CompetencyName}");
                _logger.LogInformation($"IN POST PAGE 4, Session out: {Cbvm.CompetencyName}");
                Cbvm.CompetencyDescription = CompetencyDescription;
                _logger.LogInformation($"IN POST PAGE 4, Session out: {CompetencyDescription}");
                _logger.LogInformation($"IN POST PAGE 4, Session out: {Cbvm.CompetencyDescription}");
                Cbvm.DispositionIndicies = DispositionIndicies;  
                _logger.LogInformation($"IN POST PAGE 4, Session out: {DispositionIndicies[0]}");
                _logger.LogInformation($"IN POST PAGE 4, Session out: {Cbvm.DispositionIndicies}");              
                Cbvm.KSPairsIndicies = KSPairsIndicies;  
                //_logger.LogInformation($"IN POST PAGE 4, Session out: {Cbvm.KSPairsIndicies[0]}");
                //pack it up 
                var serializedout = JsonSerializer.Serialize(Cbvm);
                _logger.LogInformation($"IN POST PAGE 4, Serialized out: {serializedout.ToString()}");
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




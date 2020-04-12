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
    public class Page6Model : PageModel
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
        [Display(Name="KSPairs")]        
        public int[][] KSPairsIndicies {get; set;}
        

        public List<Disposition> DispositionList{get;set;}
        public List<KnowledgeElement> Knowledges{get;set;}
        public List<SkillLevel> Skills{get;set;}


        public CompetencyBuilderViewModel Cbvm {get; set;}

        private readonly ILogger<Page1Model> _logger;
        private readonly IUnitOfWork _UOW;        

        public Page6Model(ILogger<Page1Model> logger, IUnitOfWork uow)
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
            _logger.LogInformation($"CBVM: {serializedin.ToString()}");
            //fill my variables with the session contents
            CompetencyName = Cbvm.CompetencyName;
            CompetencyDescription = Cbvm.CompetencyDescription;
            DispositionIndicies = Cbvm.DispositionIndicies;
            KSPairsIndicies = Cbvm.KSPairsIndicies;
            var repoDisp = _UOW.GetRepositoryAsync<Disposition>();
            var repoK = _UOW.GetRepositoryAsync<KnowledgeElement>();
            var repoS = _UOW.GetRepositoryAsync<SkillLevel>();
            IEnumerable<Disposition> tempDispList = await repoDisp.GetListAsync();
            IEnumerable<KnowledgeElement> tempKnowledgeList = await repoK.GetListAsync();
            IEnumerable<SkillLevel> tempSkillList = await repoS.GetListAsync();
            foreach (var disp in tempDispList)
            {
                foreach (var dispIndices in DispositionIndicies)
                {
                    if(disp.Id == dispIndices){
                        _logger.LogInformation("Adding a DISP");
                        DispositionList.Add(disp);
                    }
                }
            }
            foreach (var know in tempKnowledgeList)
            {
                for (int i = 0; i < KSPairsIndicies.Length; i++)
                {
                    if(know.Id == KSPairsIndicies[i][0]){
                           _logger.LogInformation("Adding a KNOWL");
                        Knowledges.Add(know);
                    }
                }
            }
            foreach (var skillElement in tempSkillList)
            {
                for (int i = 0; i < KSPairsIndicies.Length; i++)
                {
                    if(skillElement.Id == KSPairsIndicies[i][1]){
                           _logger.LogInformation("Adding a SKILL");
                        Skills.Add(skillElement);
                    }
                }    
            }
        }
         public async Task<IActionResult>  OnPostAsync(){

            _logger.LogInformation("IN ON POST ASYNC");

            await HttpContext.Session.LoadAsync();

                  
            //is my session variable null?
            if(string.IsNullOrEmpty(HttpContext.Session.GetString(SerializedCompetencyJSONKey)))
            {
                //if so, make a new one 
                Cbvm = new CompetencyBuilderViewModel();
                //fill it with what i want
                Cbvm.CompetencyName = CompetencyName;
                Cbvm.CompetencyDescription = CompetencyDescription;
                Cbvm.DispositionIndicies = DispositionIndicies;               
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
                _logger.LogInformation($"IN POST PAGE 2, Session out: {Cbvm.CompetencyName}");
                Cbvm.CompetencyDescription = CompetencyDescription;
                _logger.LogInformation($"IN POST PAGE 2, Session out: {Cbvm.CompetencyDescription}");
                Cbvm.DispositionIndicies = DispositionIndicies;  
                _logger.LogInformation($"IN POST PAGE 2, Session out: {Cbvm.DispositionIndicies}");              

                //pack it up 
                var serializedout = JsonSerializer.Serialize(Cbvm);
                _logger.LogInformation($"IN POST PAGE 2, Serialized out: {serializedout.ToString()}");
                //send it out
                HttpContext.Session.SetString(SerializedCompetencyJSONKey, serializedout);                
            }


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



        // public int Id {get; set;}
        // public string Name { get; set;}
        // public string Description {get; set;}
        // public string CartesianIndex{get; set;}
        // public string SemioticIndex{get; set;}
        // public string Etymology {get; set;}
        // public bool Selected {get; set;}
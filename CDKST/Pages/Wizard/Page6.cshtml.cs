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
        [BindProperty]
        [Display(Name="KSPairs")]        
        public int[] KSPairsIndicies {get; set;}
        

        public List<Disposition> DispositionList = new List<Disposition>();
        public List<KnowledgeElement> KnowledgeElementList = new List<KnowledgeElement>();
        public List<SkillLevel> SkillLevelList = new List<SkillLevel>();
        
        public CompetencyBuilderViewModel Cbvm {get; set;}

        private readonly ILogger<Page1Model> _logger;
        private readonly IUnitOfWork _UOW;        

        public Page6Model(ILogger<Page1Model> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;
        }


        public async Task OnGetAsync()//In this method I need to organize data from my json object to display to the page, and confirm the contents are what was desired
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
              //Makes the (RepositoryAsyncs) I need for later use. Disp,Know,Skill
            var repoDisp = _UOW.GetRepositoryAsync<Disposition>();
            var repoK = _UOW.GetRepositoryAsync<KnowledgeElement>();
            var repoS = _UOW.GetRepositoryAsync<SkillLevel>();


            //*********DISPOSITION SECTION**********\\

            //Dispositions
            IEnumerable<Disposition> tempDispList = await repoDisp.GetListAsync();
            //holds all the dispositions from the database
            List<Disposition> DispList = tempDispList.ToList();
             _logger.LogInformation("DISPLISTCOUNT "+DispList.Count().ToString());

             //make my DispositionList
            foreach (var disp in DispList)
            {
                foreach (var dispIndices in DispositionIndicies)
                {
                    if(disp.Id == dispIndices)
                    {
                        DispositionList.Add(disp);
                    }
                }
            }
            
            //***************KSPAIRS SECTION*****************\\

            //Knowledge
             IEnumerable<KnowledgeElement> tempKnowledgeList = await repoK.GetListAsync();
             //Holds all knowledgeElements from the database 
            List<KnowledgeElement> KnowledgeList = tempKnowledgeList.ToList();
                            //_logger.LogInformation("KNOWLISTCOUNT "+KnowledgeList.Count().ToString());

              //Skill
             IEnumerable<SkillLevel> tempSkillList = await repoS.GetListAsync();
             //Holds all skills from the database
            List<SkillLevel> SkillList = tempSkillList.ToList();
                            //_logger.LogInformation("SKILLLISTCOUNT "+SkillList.Count().ToString());

             //KnowledgeElementList and SkillLevelList creation 
            for(int i = 0; i< KSPairsIndicies.Length; i++){
                //Even indices are my knowledges 
                if(i%2==0){
                    foreach (var item in KnowledgeList)
                    {
                        if(item.Id == KSPairsIndicies[i])
                        {
                            KnowledgeElementList.Add(item);
                        }
                    }
                }else{//The Odd indices are skills
                   foreach (var item in SkillList)
                    {
                        if(item.Id == KSPairsIndicies[i])
                        {
                            SkillLevelList.Add(item);
                        }
                    }
                }
            }  
        }
         public async Task<IActionResult>  OnPostAsync(){//In this method I will have confirmed the form data and save the correct competency to the database
            _logger.LogInformation("IN ON POST ASYNC PAGE 6");
            _logger.LogInformation(KSPairsIndicies.Count().ToString());
            await HttpContext.Session.LoadAsync();
             //Reset these just in case, Pretty sure this is never necessary
            DispositionList = new List<Disposition>();
            KnowledgeElementList = new List<KnowledgeElement>();
            SkillLevelList = new List<SkillLevel>();
             //Makes the (RepositoryAsyncs) I need for later use. Disp,Know,Skill
            var repoDisp = _UOW.GetRepositoryAsync<Disposition>();
            var repoK = _UOW.GetRepositoryAsync<KnowledgeElement>();
            var repoS = _UOW.GetRepositoryAsync<SkillLevel>();
            //*********DISPOSITION SECTION**********\\
            //Dispositions
            IEnumerable<Disposition> tempDispList = await repoDisp.GetListAsync();
            //holds all the dispositions from the database
            List<Disposition> DispList = tempDispList.ToList();
             _logger.LogInformation("DISPLISTCOUNT "+DispList.Count().ToString());
             //make my DispositionList
            foreach (var disp in DispList)
            {
                foreach (var dispIndices in DispositionIndicies)
                {
                    if(disp.Id == dispIndices)
                    {
                        DispositionList.Add(disp);
                    }
                }
            }
            //***************KSPAIRS SECTION*****************\\
            //Knowledge
             IEnumerable<KnowledgeElement> tempKnowledgeList = await repoK.GetListAsync();
             //Holds all knowledgeElements from the database 
            List<KnowledgeElement> KnowledgeList = tempKnowledgeList.ToList();
                            //_logger.LogInformation("KNOWLISTCOUNT "+KnowledgeList.Count().ToString());
              //Skill
             IEnumerable<SkillLevel> tempSkillList = await repoS.GetListAsync();
             //Holds all skills from the database
            List<SkillLevel> SkillList = tempSkillList.ToList();
                            //_logger.LogInformation("SKILLLISTCOUNT "+SkillList.Count().ToString());
             //KnowledgeElementList and SkillLevelList creation 
            for(int i = 0; i< KSPairsIndicies.Length; i++){
                //Even indices are my knowledges 
                if(i%2==0){
                    foreach (var item in KnowledgeList)
                    {
                        if(item.Id == KSPairsIndicies[i])
                        {
                            KnowledgeElementList.Add(item);
                        }
                    }
                }else{//The Odd indices are skills
                   foreach (var item in SkillList)
                    {
                        if(item.Id == KSPairsIndicies[i])
                        {
                            SkillLevelList.Add(item);
                        }
                    }
                }
            }
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
            await makeAndCreateCompetency();
            return RedirectToPage("/Wizard/Confirmed");
        }
        async Task makeAndCreateCompetency(){
            IDMachine ID = new IDMachine();
            var repoC = _UOW.GetRepositoryAsync<Competency>();
            var repoCD = _UOW.GetRepositoryAsync<CompetencyDisposition>();
            var repoKS = _UOW.GetRepositoryAsync<KSPair>();
            IEnumerable<Competency> allCompsIE = await repoC.GetListAsync();
            List<Competency> allComps = allCompsIE.ToList();
            IEnumerable<CompetencyDisposition> allCDsIE = await repoCD.GetListAsync();
            List<CompetencyDisposition> allCDs = allCDsIE.ToList();
            IEnumerable<KSPair> allKSIE = await repoKS.GetListAsync();
            List<KSPair> allKS = allKSIE.ToList();
            List<CompetencyDisposition> forMyNewCompDISP = new List<CompetencyDisposition>();
            foreach(var item in DispositionList)
                {
                    CompetencyDisposition newCD = new CompetencyDisposition(){
                   
                    Disposition = item
                    };
                    forMyNewCompDISP.Add(newCD);
                    allCDs.Add(newCD);

                }
            List<KSPair> forMyNewCompKS = new List<KSPair>();
            for (int i = 0; i < KnowledgeElementList.Count; i++)
            {
                KSPair newKS = new KSPair{
                            
                             KnowledgeElement = KnowledgeElementList[i],
                            SkillLevel = SkillLevelList[i]
                        };
                forMyNewCompKS.Add(newKS);
                allKS.Add(newKS);
            }
                //  new KSPair{
                //             Id =1,
                //             KnowledgeElement = knowledgeElements[0],
                //             SkillLevel = skillLevels[5],
                //         },
             AtomicCompetency newComp = new AtomicCompetency{ 
                        Id = ID.getNewID(allComps),
                        Name = CompetencyName,
                        Description = CompetencyDescription,
                        CompetencyDispostions = forMyNewCompDISP,          
                        KSPairs = forMyNewCompKS
                    };
                    await repoC.AddAsync(newComp);
                    int whytIsThisAnInt = _UOW.SaveChanges();
        }         
    }    
}



   
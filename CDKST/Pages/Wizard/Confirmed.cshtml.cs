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
    public class ConfirmedModel : PageModel
    {
        public const string SerializedCompetencyJSONKey = "_CompetencySerliazed";

        [BindProperty]
        [Display(Name = "Competency Name")]
        public string CompetencyName { get; set; }

        [BindProperty]
        [Display(Name = "Competency Description")]
        public string CompetencyDescription { get; set; }
        [BindProperty]
        [Display(Name = "Dispositions")]
        public int[] DispositionIndicies { get; set; }
        [Display(Name = "KSPairs")]
        public int[] KSPairsIndicies { get; set; }


        public List<Disposition> DispositionList = new List<Disposition>();
        public List<KnowledgeElement> KnowledgeElementList = new List<KnowledgeElement>();
        public List<SkillLevel> SkillLevelList = new List<SkillLevel>();


        public CompetencyBuilderViewModel Cbvm { get; set; }

        private readonly ILogger<Page1Model> _logger;
        private readonly IUnitOfWork _UOW;

        public ConfirmedModel(ILogger<Page1Model> logger, IUnitOfWork uow)
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
            //Makes the Units of Work (RepositoryAsyncs) I need for later use. Disp,Know,Skill
            var repoDisp = _UOW.GetRepositoryAsync<Disposition>();
            var repoK = _UOW.GetRepositoryAsync<KnowledgeElement>();
            var repoS = _UOW.GetRepositoryAsync<SkillLevel>();


            //*********DISPOSITION SECTION**********\\

            //Dispositions
            IEnumerable<Disposition> tempDispList = await repoDisp.GetListAsync();
            //holds all the dispositions from the database
            List<Disposition> DispList = tempDispList.ToList();
            _logger.LogInformation("DISPLISTCOUNT " + DispList.Count().ToString());

            //make my DispositionList
            foreach (var disp in DispList)
            {
                foreach (var dispIndices in DispositionIndicies)
                {
                    if (disp.Id == dispIndices)
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
            for (int i = 0; i < KSPairsIndicies.Length; i++)
            {
                //Even indices are my knowledges 
                if (i % 2 == 0)
                {
                    foreach (var item in KnowledgeList)
                    {
                        if (item.Id == KSPairsIndicies[i])
                        {
                            KnowledgeElementList.Add(item);
                        }
                    }
                }
                else
                {//The Odd indices are skills
                    foreach (var item in SkillList)
                    {
                        if (item.Id == KSPairsIndicies[i])
                        {
                            SkillLevelList.Add(item);
                        }
                    }
                }
            }


        }
        public void OnPostAsync()
        {


        }



    }

}





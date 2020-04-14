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
using MyData.Data;
using MyRepo;
using CDKST.ViewModels;

namespace CDKST.Pages.Wizard
{
    public class Page3Model : PageModel
    {
         public const string SerializedCompetencyJSONKey = "_CompetencySerliazed";

        [BindProperty]
        [Display(Name="Competency Name")]
        public string CompetencyName {get; set;}

        [BindProperty]
        [Display(Name="Competency Description")]        
        public string CompetencyDescription {get; set;}
        [BindProperty]
        [Display(Name="Disposition Indicies")]        
        public int[] DispositionIndicies {get; set;}

        [BindProperty]
        public string IsComposite { get; set; }
        //Unnecessary, I just liked the array here, totally should make IsComposite a Bool
        public string[] CompetencyTypes = new[] { "Atomic", "Composite"};

        public CompetencyBuilderViewModel Cbvm {get; set;}

        private readonly ILogger<Page1Model> _logger;
        private readonly IUnitOfWork _UOW;        

        public Page3Model(ILogger<Page1Model> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;
        }


        public async Task OnGetAsync()//I dont need to do much besides preserve my data on this page, We are asking if it will be atomic or composite
        {
            _logger.LogInformation("OnGet Page 3");
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

        //     _logger.LogInformation($"COMPNAME: {CompetencyName}");
        //     _logger.LogInformation($"COMPDESCR: {CompetencyDescription}");
        //     _logger.LogInformation($"DISPINDICE: {DispositionIndicies[0]}");
        }
         public async Task<IActionResult>  OnPostAsync(){//Move my data along and read the form result to direct to the correct page 

            _logger.LogInformation("IN ON POST ASYNC PAGE 3");
            //  _logger.LogInformation($"CompName: {CompetencyName}");
            // _logger.LogInformation($"DISP: {DispositionIndicies[0]}");

            //Where My Session At?
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
                Cbvm.CompetencyDescription = CompetencyDescription;                
                Cbvm.DispositionIndicies = DispositionIndicies;  
                Cbvm.KSPairsIndicies = new int[0];
                //  _logger.LogInformation($"IN POST PAGE 3, Session in: {CompetencyName}");
                // _logger.LogInformation($"IN POST PAGE 3, Session out: {Cbvm.CompetencyName}");
                // _logger.LogInformation($"IN POST PAGE 3, Session in: {CompetencyDescription}");
                // _logger.LogInformation($"IN POST PAGE 3, Session out: {Cbvm.CompetencyDescription}");
                // _logger.LogInformation($"IN POST PAGE 3, Session in: {DispositionIndicies[0]}");
                // _logger.LogInformation($"IN POST PAGE 3, Session out: {Cbvm.DispositionIndicies[0]}");   

                //pack it up 
                var serializedout = JsonSerializer.Serialize(Cbvm);
                _logger.LogInformation($"IN POST PAGE 3, Serialized out: {serializedout.ToString()}");

                //send it out
                HttpContext.Session.SetString(SerializedCompetencyJSONKey, serializedout);                
            }
            //Redirect based on form result 
            if(IsComposite == "Atomic"){
                 return RedirectToPage("/Wizard/Page4");
            }else{
                //PUNKED. WE ONLY DO ATOMICS
                 return RedirectToPage("/Wizard/Page4");
            }
           

        }

    }
}

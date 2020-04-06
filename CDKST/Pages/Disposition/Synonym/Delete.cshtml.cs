// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.EntityFrameworkCore;
// using MyData.Data.Models.Disposition;
// using Microsoft.Extensions.Logging;
// using MyRepo;


// namespace CDKST.Pages_Disposition_Synonym
// {
//     public class DeleteModel : PageModel
//     {
       
//        private readonly ILogger<IndexModel> _logger;
//         private readonly IUnitOfWork _UOW;

//         public DeleteModel(ILogger<IndexModel> logger, IUnitOfWork uow)
//         {
//             _logger = logger;
//             _UOW = uow;            
//         }
//         [BindProperty]
//         public DispositionSynonym DispositionSynonym { get; set; }

//         public async Task<IActionResult> OnGetAsync(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

        

//             if (DispositionSynonym == null)
//             {
//                 return NotFound();
//             }
//             return Page();
//         }

//         public async Task<IActionResult> OnPostAsync(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//                 _UOW.GetRepository<DispositionSynonym>().Delete(DispositionSynonym);

//             if (DispositionSynonym != null)
//             {
                
//             }

//             return RedirectToPage("./Index");
//         }
//     }
// }

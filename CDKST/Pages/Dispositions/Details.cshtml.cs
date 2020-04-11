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


// namespace CDKST.CDKST.Pages.Disposition
// {

//     public class DetailsModel : PageModel
//     {
//         private readonly ILogger<InModel> _logger;
//         private readonly IUnitOfWork _UOW;

//         public DetailsModel(ILogger<IndexModel> logger, IUnitOfWork uow)
//         {
//             _logger = logger;
//             _UOW = uow;            
//         }

//         public DispositionSynonym DispositionSynonym { get; set; }

//         public async Task<IActionResult> OnGetAsync(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             DispositionSynonym = await _context.DispositionSynonym.FirstOrDefaultAsync(m => m.ID == id);

//             if (DispositionSynonym == null)
//             {
//                 return NotFound();
//             }
//             return Page();
//         }
//     }
// }

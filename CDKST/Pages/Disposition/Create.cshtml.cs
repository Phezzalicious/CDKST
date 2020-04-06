// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using MyData.Data.Models.Disposition;
// using Microsoft.Extensions.Logging;
// using MyRepo;


// namespace CDKST.Pages.CDKST.Disposition
// {
//     public class CreateModel : PageModel
//     {
       
//         private readonly IUnitOfWork _UOW;
//         private readonly ILogger<IndexModel> _logger;
//         public CreateModel(IUnitOfWork uow, ILogger<IndexModel> logger){
//             _UOW = uow;
//             _logger = logger;
//         }
//         public IActionResult OnGet()
//         {
//             return Page();
//         }

//         [BindProperty]
//         public DispositionSynonym DispositionSynonym { get; set; }

//         // To protect from overposting attacks, enable the specific properties you want to bind to, for
//         // more details, see https://aka.ms/RazorPagesCRUD.
//         public async Task<IActionResult> OnPostAsync()
//         {
//             if (!ModelState.IsValid)
//             {
//                 return Page();
//             }

//             _UOW.GetRepository<DispositionSynonym>().Add(DispositionSynonym);
            
//             return RedirectToPage("./Index");
//         }
//     }
// }

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using MyData.Data.Models.Disposition;
// using Microsoft.Extensions.Logging;
// using MyRepo;


// namespace CDKST.Pages_Disposition_Synonym
// {
//     public class EditModel : PageModel
//     {
//         private readonly ILogger<IndexModel> _logger;
//         private readonly IUnitOfWork _UOW;

//         public EditModel(ILogger<IndexModel> logger, IUnitOfWork uow)
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

//             DispositionSynonym = await _context.DispositionSynonym.FirstOrDefaultAsync(m => m.ID == id);

//             if (DispositionSynonym == null)
//             {
//                 return NotFound();
//             }
//             return Page();
//         }

//         // To protect from overposting attacks, enable the specific properties you want to bind to, for
//         // more details, see https://aka.ms/RazorPagesCRUD.
//         public async Task<IActionResult> OnPostAsync()
//         {
//             if (!ModelState.IsValid)
//             {
//                 return Page();
//             }

//             _context.Attach(DispositionSynonym).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!DispositionSynonymExists(DispositionSynonym.ID))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return RedirectToPage("./Index");
//         }

//         private bool DispositionSynonymExists(int id)
//         {
//             return _context.DispositionSynonym.Any(e => e.ID == id);
//         }
//     }
// }

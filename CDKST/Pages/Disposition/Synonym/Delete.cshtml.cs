using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Disposition;

namespace CDKST.Pages_Disposition_Synonym
{
    public class DeleteModel : PageModel
    {
        private readonly CDKSTContext _context;

        public DeleteModel(CDKSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DispositionSynonym DispositionSynonym { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DispositionSynonym = await _context.DispositionSynonym.FirstOrDefaultAsync(m => m.ID == id);

            if (DispositionSynonym == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DispositionSynonym = await _context.DispositionSynonym.FindAsync(id);

            if (DispositionSynonym != null)
            {
                _context.DispositionSynonym.Remove(DispositionSynonym);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

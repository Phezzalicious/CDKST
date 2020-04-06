using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Disposition;

namespace CDKST.Pages_Disposition_Applied
{
    public class DeleteModel : PageModel
    {
        private readonly CDKSTContext _context;

        public DeleteModel(CDKSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DispositionApplied DispositionApplied { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DispositionApplied = await _context.DispositionApplied.FirstOrDefaultAsync(m => m.ID == id);

            if (DispositionApplied == null)
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

            DispositionApplied = await _context.DispositionApplied.FindAsync(id);

            if (DispositionApplied != null)
            {
                _context.DispositionApplied.Remove(DispositionApplied);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

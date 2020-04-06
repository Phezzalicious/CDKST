using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Competency;

namespace CDKST.Pages_Competency_Composite
{
    public class DeleteModel : PageModel
    {
        private readonly CDKSTContext _context;

        public DeleteModel(CDKSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Composite Composite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Composite = await _context.Composite.FirstOrDefaultAsync(m => m.ID == id);

            if (Composite == null)
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

            Composite = await _context.Composite.FindAsync(id);

            if (Composite != null)
            {
                _context.Composite.Remove(Composite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

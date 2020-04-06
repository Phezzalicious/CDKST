using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Disposition;

namespace CDKST.Pages_Disposition_Applied
{
    public class EditModel : PageModel
    {
        private readonly CDKSTContext _context;

        public EditModel(CDKSTContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DispositionApplied).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispositionAppliedExists(DispositionApplied.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DispositionAppliedExists(int id)
        {
            return _context.DispositionApplied.Any(e => e.ID == id);
        }
    }
}

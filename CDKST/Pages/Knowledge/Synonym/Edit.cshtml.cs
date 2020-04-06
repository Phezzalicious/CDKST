using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Knowledge;

namespace CDKST.Pages_Knowledge_Synonym
{
    public class EditModel : PageModel
    {
        private readonly CDKSTContext _context;

        public EditModel(CDKSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KnowledgeSynonym KnowledgeSynonym { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KnowledgeSynonym = await _context.KnowledgeSynonym.FirstOrDefaultAsync(m => m.ID == id);

            if (KnowledgeSynonym == null)
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

            _context.Attach(KnowledgeSynonym).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnowledgeSynonymExists(KnowledgeSynonym.ID))
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

        private bool KnowledgeSynonymExists(int id)
        {
            return _context.KnowledgeSynonym.Any(e => e.ID == id);
        }
    }
}

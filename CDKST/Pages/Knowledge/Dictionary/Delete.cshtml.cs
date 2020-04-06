using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Knowledge;

namespace CDKST.Pages_Knowledge_Dictionary
{
    public class DeleteModel : PageModel
    {
        private readonly CDKSTContext _context;

        public DeleteModel(CDKSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KnowledgeDictionary KnowledgeDictionary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KnowledgeDictionary = await _context.KnowledgeDictionary.FirstOrDefaultAsync(m => m.ID == id);

            if (KnowledgeDictionary == null)
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

            KnowledgeDictionary = await _context.KnowledgeDictionary.FindAsync(id);

            if (KnowledgeDictionary != null)
            {
                _context.KnowledgeDictionary.Remove(KnowledgeDictionary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

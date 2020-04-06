using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyData.Data.Models.Knowledge;

namespace CDKST.Pages_Knowledge_Dictionary
{
    public class CreateModel : PageModel
    {
        private readonly CDKSTContext _context;

        public CreateModel(CDKSTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KnowledgeDictionary KnowledgeDictionary { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.KnowledgeDictionary.Add(KnowledgeDictionary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyData.Data.Models.Disposition;

namespace CDKST.Pages_Disposition_Dictionary
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
        public DispositionDictionary DispositionDictionary { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DispositionDictionary.Add(DispositionDictionary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

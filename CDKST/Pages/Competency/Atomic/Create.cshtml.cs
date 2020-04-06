using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyData.Data.Models.Competency;

namespace CDKST.Pages_Competency_Atomic
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
        public Atomic Atomic { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Atomic.Add(Atomic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

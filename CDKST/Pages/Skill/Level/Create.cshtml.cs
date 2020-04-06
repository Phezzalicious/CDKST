using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyData.Data.Models.Skill;
using MyRepo;
namespace CDKST.Pages_Skill_Level
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
        public SkillLevel SkillLevel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SkillLevel.Add(SkillLevel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

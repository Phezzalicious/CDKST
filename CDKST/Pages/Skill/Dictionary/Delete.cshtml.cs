using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Skill;

namespace CDKST.Pages_Skill_Dictionary
{
    public class DeleteModel : PageModel
    {
        private readonly CDKSTContext _context;

        public DeleteModel(CDKSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SkillDictionary SkillDictionary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SkillDictionary = await _context.SkillDictionary.FirstOrDefaultAsync(m => m.ID == id);

            if (SkillDictionary == null)
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

            SkillDictionary = await _context.SkillDictionary.FindAsync(id);

            if (SkillDictionary != null)
            {
                _context.SkillDictionary.Remove(SkillDictionary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

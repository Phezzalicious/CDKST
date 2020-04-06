using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Skill;

namespace CDKST.Pages_Skill_VerbSynonym
{
    public class DeleteModel : PageModel
    {
        private readonly CDKSTContext _context;

        public DeleteModel(CDKSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SkillVerbSynonym SkillVerbSynonym { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SkillVerbSynonym = await _context.SkillVerbSynonym.FirstOrDefaultAsync(m => m.ID == id);

            if (SkillVerbSynonym == null)
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

            SkillVerbSynonym = await _context.SkillVerbSynonym.FindAsync(id);

            if (SkillVerbSynonym != null)
            {
                _context.SkillVerbSynonym.Remove(SkillVerbSynonym);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

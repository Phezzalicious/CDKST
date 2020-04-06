using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Skill;
using MyRepo;
namespace CDKST.Pages_Skill_Level
{
    public class DeleteModel : PageModel
    {
        private readonly CDKSTContext _context;

        public DeleteModel(CDKSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SkillLevel SkillLevel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SkillLevel = await _context.SkillLevel.FirstOrDefaultAsync(m => m.ID == id);

            if (SkillLevel == null)
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

            SkillLevel = await _context.SkillLevel.FindAsync(id);

            if (SkillLevel != null)
            {
                _context.SkillLevel.Remove(SkillLevel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

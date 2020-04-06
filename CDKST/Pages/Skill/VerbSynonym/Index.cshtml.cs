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
    public class IndexModel : PageModel
    {
        private readonly CDKSTContext _context;

        public IndexModel(CDKSTContext context)
        {
            _context = context;
        }

        public IList<SkillVerbSynonym> SkillVerbSynonym { get;set; }

        public async Task OnGetAsync()
        {
            SkillVerbSynonym = await _context.SkillVerbSynonym.ToListAsync();
        }
    }
}

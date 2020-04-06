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
    public class IndexModel : PageModel
    {
        private readonly CDKSTContext _context;

        public IndexModel(CDKSTContext context)
        {
            _context = context;
        }

        public IList<SkillDictionary> SkillDictionary { get;set; }

        public async Task OnGetAsync()
        {
            SkillDictionary = await _context.SkillDictionary.ToListAsync();
        }
    }
}

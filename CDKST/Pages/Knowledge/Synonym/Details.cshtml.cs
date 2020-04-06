using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Knowledge;

namespace CDKST.Pages_Knowledge_Synonym
{
    public class DetailsModel : PageModel
    {
        private readonly CDKSTContext _context;

        public DetailsModel(CDKSTContext context)
        {
            _context = context;
        }

        public KnowledgeSynonym KnowledgeSynonym { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KnowledgeSynonym = await _context.KnowledgeSynonym.FirstOrDefaultAsync(m => m.ID == id);

            if (KnowledgeSynonym == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

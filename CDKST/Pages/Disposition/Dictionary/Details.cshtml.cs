using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Disposition;

namespace CDKST.Pages_Disposition_Dictionary
{
    public class DetailsModel : PageModel
    {
        private readonly CDKSTContext _context;

        public DetailsModel(CDKSTContext context)
        {
            _context = context;
        }

        public DispositionDictionary DispositionDictionary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DispositionDictionary = await _context.DispositionDictionary.FirstOrDefaultAsync(m => m.ID == id);

            if (DispositionDictionary == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

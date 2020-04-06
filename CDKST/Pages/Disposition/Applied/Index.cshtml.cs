using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Disposition;

namespace CDKST.Pages_Disposition_Applied
{
    public class IndexModel : PageModel
    {
        private readonly CDKSTContext _context;

        public IndexModel(CDKSTContext context)
        {
            _context = context;
        }

        public IList<DispositionApplied> DispositionApplied { get;set; }

        public async Task OnGetAsync()
        {
            DispositionApplied = await _context.DispositionApplied.ToListAsync();
        }
    }
}

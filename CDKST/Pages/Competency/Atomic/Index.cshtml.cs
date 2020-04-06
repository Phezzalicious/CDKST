using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Competency;

namespace CDKST.Pages_Competency_Atomic
{
    public class IndexModel : PageModel
    {
        private readonly CDKSTContext _context;

        public IndexModel(CDKSTContext context)
        {
            _context = context;
        }

        public IList<Atomic> Atomic { get;set; }

        public async Task OnGetAsync()
        {
            Atomic = await _context.Atomic.ToListAsync();
        }
    }
}

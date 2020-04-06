using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Knowledge;

namespace CDKST.Pages_Knowledge_Dictionary
{
    public class IndexModel : PageModel
    {
        private readonly CDKSTContext _context;

        public IndexModel(CDKSTContext context)
        {
            _context = context;
        }

        public IList<KnowledgeDictionary> KnowledgeDictionary { get;set; }

        public async Task OnGetAsync()
        {
            KnowledgeDictionary = await _context.KnowledgeDictionary.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyData.Data.Models.Disposition;
using Microsoft.Extensions.Logging;
using MyRepo;

namespace CDKST.Pages.Knowledge
{
    public class IndexModel : PageModel
    {
         [BindProperty]
        public IEnumerable<DispositionInstance> DispositionInstanceList {get; set;}

        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _UOW;

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;            
        }

        public async Task OnGetAsync()
        {
            //var repository = _UOW.GetRepository<DispositionInstance>();
            var repository = _UOW.GetRepositoryAsync<DispositionInstance>();

           DispositionInstanceList = await repository.GetListAsync();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using MyData.Data;
using MyRepo;
using CDKST.ViewModels;

namespace CDKST.Pages.Wizard
{
    public class IndexModel : PageModel
    {
     
        public void OnGet()
        {
        }

        
    }
}

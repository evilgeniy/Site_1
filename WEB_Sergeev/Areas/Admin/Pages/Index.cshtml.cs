using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_Sergeev.Data;
using WEB_Sergeev.Entities;

namespace WEB_Sergeev.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WEB_Sergeev.Data.ApplicationDbContext _context;

        public IndexModel(WEB_Sergeev.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Engine> Engine { get;set; }

        public async Task OnGetAsync()
        {
            Engine = await _context.Engines.ToListAsync();
        }
    }
}

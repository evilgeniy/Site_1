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
    public class DetailsModel : PageModel
    {
        private readonly WEB_Sergeev.Data.ApplicationDbContext _context;

        public DetailsModel(WEB_Sergeev.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Engine Engine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Engine = await _context.Engines.FirstOrDefaultAsync(m => m.EngineId == id);

            if (Engine == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

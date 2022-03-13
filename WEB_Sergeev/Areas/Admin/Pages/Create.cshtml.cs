using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_Sergeev.Data;
using WEB_Sergeev.Entities;

namespace WEB_Sergeev.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WEB_Sergeev.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(WEB_Sergeev.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["EngineClassId"] = new SelectList(_context.EngineClasses, "EngineClassId", "ClassName");
            return Page();
        }

        [BindProperty]
        public Engine Engine { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Engines.Add(Engine);
            await _context.SaveChangesAsync();

            if(Image != null)
            {
                var fileName = $"{Engine.EngineId}" + Path.GetExtension(Image.FileName);
                Engine.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

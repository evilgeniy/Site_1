using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_Sergeev.Entities;
using WEB_Sergeev.Extensions;
using WEB_Sergeev.Models;
using WEB_Sergeev.Data;
using Microsoft.Extensions.Logging;

namespace WEB_Sergeev.Controllers
{
    public class EngineController : Controller
    {
        private ApplicationDbContext context;
        private int pageSize;
        private ILogger logger;

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            logger.LogInformation($"info: group={group}, page={pageNo}");


            var enginesFiltered = context.Engines.Where(d => !group.HasValue || d.ClassId == group.Value);

            var model = ListViewModel<Engine>.GetModel(enginesFiltered, pageNo, pageSize);

            ViewData["Groups"] = context.EngineClasses;
            ViewData["CurrentGroup"] = group ?? 0;

            if (Request.IsAjaxRequest())
            {
                return PartialView("listpartial", model);
            }
            else
            {
                return View(model);
            }

        }

        public EngineController(ApplicationDbContext context, ILogger<EngineController> logger)
        {
            pageSize = 3;
            this.context = context;
            this.logger = logger;
        }

        
    }
}

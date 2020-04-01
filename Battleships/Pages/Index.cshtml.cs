﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Battleships.Services;

namespace Battleships.Pages
{
    public class IndexModel : PageModel
    {
        private GameManagementService _g;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, GameManagementService g)
        {
            _logger = logger;
            _g = g;
        }

        public void OnGet()
        {

        }

        public ActionResult OnGetStartGame(int size)
        {
            _g.StartGame(size);
            return RedirectToPage("./GamePreparation");
        }
    }
}

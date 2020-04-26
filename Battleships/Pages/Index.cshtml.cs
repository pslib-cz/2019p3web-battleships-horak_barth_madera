using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Battleships.Services;

namespace Battleships.Pages
{
    public class IndexModel : PageModel //Barth, Horák(session - rozměry hracího pole do sessiony pro redirect na GamePrep.)
    {
        private SessionStorage<int> _session;
        private IGamePreparation _g;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IGamePreparation g, SessionStorage<int> session)
        {
            _logger = logger;
            _g = g;
            _session = session;
        }

        public void OnGet()
        {
            
        }

        public ActionResult OnGetStartGame(int size)
        {
            _g.StartGame(size);
            _session.Save("Size", size);
            return RedirectToPage("./GamePreparation");
        }
    }
}

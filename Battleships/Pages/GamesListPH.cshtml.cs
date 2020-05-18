using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;
using Battleships.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Battleships.Pages
{
    public class PrivacyModel : PageModel
    {
        private SessionStorage<Guid> _session;
        
        public List<Game> AllGames;
        public List<Game> ActiveGames;
        private IGamePreparation _gp;
        private IMainMenu _mm;
        public IGame _ga;

        public PrivacyModel(SessionStorage<Guid> session, IGamePreparation gp, IGame ga, IMainMenu mm)
        {
            _session = session;
            _gp = gp;
            _ga = ga;
            _mm = mm;
        }

        public void OnGet()
        {
            AllGames = _gp.LoadAllGames();
            ActiveGames = _gp.LoadActiveGames();
        }

        public ActionResult OnGetRemoveGame(Guid value)
        {
            _mm.DeleteGame(value);
            AllGames = _gp.LoadAllGames();
            ActiveGames = _gp.LoadActiveGames();
            return Page();
        }

        public ActionResult OnGetEnterGame(Guid value)
        {
            
            _ga.JoinGame(value);
            
            return RedirectToPage("./Game");
        }
    }
}

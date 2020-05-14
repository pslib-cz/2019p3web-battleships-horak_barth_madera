using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;
using Battleships.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utf8Json;

namespace Battleships.Pages
{
    public class GamesListModel : PageModel //Barth
    {
        private SessionStorage<Guid> _session;
        private SessionStorage<string> _sessionString;
        public List<Game> AllGames;
        public List<Game> ActiveGames;

        private IGamePreparation _gp;
        private IMainMenu _mm;

        [TempData]
        public string Message { get; set; }

        public GamesListModel(SessionStorage<Guid> session, IGamePreparation gp, IMainMenu mm)
        {
            _session = session;
            _gp = gp;
            _mm = mm;
            AllGames = _gp.LoadAllGames();
            ActiveGames = _gp.LoadActiveGames();
        }

        public void OnGet()
        {
        }

        public void OnGetRemove(Guid value)
        {
            _mm.DeleteGame(value);
            Page();
        }

        public ActionResult OnGetEnterGame(Guid value)
        {
            _session.Save("EnterId", value);
            return RedirectToPage("./GamePreparation");
        }
    }
}
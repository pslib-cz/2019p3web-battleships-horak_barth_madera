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
        private ApplicationDbContext _db;
        private SessionStorage<Guid> _session;
        public List<Game> AllGames;
        public List<Game> ActiveGames;
        private IGamePreparation _gp;

        public GamesListModel(ApplicationDbContext db, SessionStorage<Guid> session, IGamePreparation gp)
        {
            _db = db;
            _session = session;
            _gp = gp;
            AllGames = _gp.LoadAllGames();
            ActiveGames = _gp.LoadActiveGames();
        }

        public void OnGet()
        {
        }

        private ActionResult OnGetEnterGame(Guid value)
        {
            _session.Save("EnterId", value);
            return RedirectToPage("./GamePreparation");
        }
    }
}
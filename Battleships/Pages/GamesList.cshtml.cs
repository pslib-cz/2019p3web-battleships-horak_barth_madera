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
        private SessionStorage<string> _session;

        public List<Game> Games;

        public GamesListModel(ApplicationDbContext db, SessionStorage<string> session)
        {
            _db = db;
            _session = session;
        }

        private List<Game> LoadGames()
        {
            return (from p in _db.Games /*orderby Guid.NewGuid()*/ select p).Take(10).ToList();
        }

        public void OnGet()
        {
            _session.Save("GamesList", JsonSerializer.ToJsonString(LoadGames()));
            for (int i = 0; i <= _db.Games.Count(); i++)
            {
                Games = JsonSerializer.Deserialize<List<Game>>(_session.Load("GamesList"));
            }
        }

        private ActionResult OnGetEnterGame(Guid value)
        {
            //načíst data dané hry
            return RedirectToPage("./GamePreparation");
        }
    }
}
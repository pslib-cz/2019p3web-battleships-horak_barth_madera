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
        public List<Game> Games;

        public GamesListModel(ApplicationDbContext db, SessionStorage<Guid> session)
        {
            _db = db;
            _session = session;
            Games = LoadGames();
        }

        private List<Game> LoadGames()
        {
            return (from p in _db.Games /*orderby Guid.NewGuid()*/ select p).Take(10).ToList();
        }

        public void OnGet()
        {
        }

        private ActionResult OnGetEnterGame(Guid value)
        {
            //načíst data dané hry
            return RedirectToPage("./GamePreparation");
        }
    }
}
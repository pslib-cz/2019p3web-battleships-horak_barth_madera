using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;
using Battleships.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public void OnGet()
        {
            foreach (var item in _db.Games)
            {
                Games.Add(item);
            }
        }
    }
}
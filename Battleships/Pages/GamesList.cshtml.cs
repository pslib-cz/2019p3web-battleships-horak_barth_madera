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
    public class GamesListModel : PageModel
    {
        private ApplicationDbContext _db;
        private SessionStorage<string> _session;

        public List<UserGame> UserGames;

        public GamesListModel(ApplicationDbContext db, SessionStorage<string> session)
        {
            _db = db;
            _session = session;
        }

        public void OnGet()
        {
           /* UserGames =*/ /*_db.UserGames;*/ /*_session.Load("")*/
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Battleships.Services;
using Battleships.Models;

namespace Battleships.Pages
{
    public class GamePreparationModel : PageModel //Barth
    {
        private SessionStorage<Guid> _session;
        private ApplicationDbContext _db;
        public Guid _gameId;
        public int _gameSize;

        public GamePreparationModel(ApplicationDbContext db, SessionStorage<Guid> session)
        {
            _session = session;
            _db = db;
        }

        public void OnGet()
        {
            _gameId = _session.Load("GameId");
            _gameSize = 5; /* <--   _db.Games (where GameId == _gameId).GameSize*/
        }
    }
}
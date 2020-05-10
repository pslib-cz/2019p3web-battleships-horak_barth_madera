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
        public Guid _gameId;
        private IGamePreparation _gp;
        public Game LoadedGame;

        public GamePreparationModel(IGamePreparation gp, SessionStorage<Guid> session)
        {
            _session = session;
            _gp = gp;
            _gameId = _session.Load("GameId");
            LoadedGame = _gp.LoadGame(_gameId);
        }

        public void OnGet()
        {
        }

        public void OnGetTileAction(int _x, int _y)
        {
            _gp.TileAction(_gameId, _x, _y);
        }
    }
}
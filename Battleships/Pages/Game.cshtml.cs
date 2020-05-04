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
    public class GameModel : PageModel  //Autor: Petr Horák
    {
        private IGame _gameService;
        private SessionStorage<Guid> _sessionGuid;
        
        public Guid _gameId;
        public int _gameSize;

        public List<List<NavyBattlePiece>> PlayingField;
        

        public GameModel(IGame game, SessionStorage<Guid> sessionGuid)
        {
            _gameService = game;
            _sessionGuid = sessionGuid;            
            _gameId = sessionGuid.Load("GameId");                     
        }

        public void OnGet()
        {
            PlayingField = _gameService.GetBattlefield(_gameId);
            
        }
    }
}
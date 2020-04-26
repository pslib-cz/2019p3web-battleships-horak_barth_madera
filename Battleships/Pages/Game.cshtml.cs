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
        private SessionStorage<int> _sessionInt;
        public Guid _gameId;
        public int _gameSize;

        public List<NavyBattlePiece> Pieces;
        public NavyBattlePiece Piece;

        public GameModel(IGame game, SessionStorage<Guid> sessionGuid, SessionStorage<int> sessionInt)
        {
            _gameService = game;
            _sessionGuid = sessionGuid;
            _sessionInt = sessionInt;
            _gameId = sessionGuid.Load("GameId");
            _gameSize = sessionInt.Load("Size");
            
        }

        public void OnGet()
        {
            Pieces = _gameService.GetBattleField(_gameId);
            Piece = _gameService.GetNavyBattlePiece(_gameId);
        }
    }
}
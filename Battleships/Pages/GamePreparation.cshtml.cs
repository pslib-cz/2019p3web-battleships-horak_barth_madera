using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Battleships.Services;
using Battleships.Models;
using Battleships.ViewModels;
using Battleships.Models.Enums;

namespace Battleships.Pages
{
    public class GamePreparationModel : PageModel 
    {
        private IGame _gameService;
        private SessionStorage<Guid> _sessionGuid;
        public Game Game;
        public Guid _gameId;
        public int _gameSize;
        public BattlefieldPartialModel partialModel;
        public List<List<NavyBattlePiece>> PlayingField;


        public GamePreparationModel(IGame game, SessionStorage<Guid> sessionGuid)
        {
            _gameService = game;
            _sessionGuid = sessionGuid;
            _gameId = sessionGuid.Load("GameId");
            Game = _gameService.GetGame(_gameId);
        }

        public void OnGet()
        {
            partialModel = new BattlefieldPartialModel(_gameService.GetBattlefield(_gameService.GetUserGame(_gameId).NavyBattlePieces.OrderBy(x => x.PosX).ToList()), _gameService.GetUserGame(_gameId), _gameService.GetUser());
            Game = _gameService.GetGame(_gameId);
        }

        public ActionResult OnGetPieceClick(int x, int y, int ug)
        {
            partialModel = new BattlefieldPartialModel(_gameService.GetBattlefield(_gameService.GetUserGame(_gameId).NavyBattlePieces.OrderBy(x => x.PosX).ToList()), _gameService.GetUserGame(_gameId), _gameService.GetUser());
            Game = _gameService.GetGame(_gameId);
            _gameService.PlaceShip(ug, x, y);

            return Page();
        }

        public ActionResult OnGetDone()
        {
            partialModel = new BattlefieldPartialModel(_gameService.GetBattlefield(_gameService.GetUserGame(_gameId).NavyBattlePieces.OrderBy(x => x.PosX).ToList()), _gameService.GetUserGame(_gameId), _gameService.GetUser());
            Game = _gameService.GetGame(_gameId);
            _gameService.ChangePlayerState(_gameService.GetUserGame(Game.GameId), PlayerState.Playing);
            _gameService.ChangeGameState(Game.GameId);
            return RedirectToPage("./GameBattle");
        }
    }
}
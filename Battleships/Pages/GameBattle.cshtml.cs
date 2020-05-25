using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;
using Battleships.Models.Enums;
using Battleships.Services;
using Battleships.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utf8Json;

namespace Battleships.Pages
{
    public class GamesListModel : PageModel //Barth
    {
        private IGame _gameService;
        private SessionStorage<Guid> _sessionGuid;
        public Game Game;
        public Guid _gameId;
        public int _gameSize;
        public BattlefieldPartialModel partialModel;
        public List<List<NavyBattlePiece>> PlayingField;
        public List<BattlefieldPartialModel> partialModels { get; set; } = new List<BattlefieldPartialModel>();


        public GamesListModel(IGame game, SessionStorage<Guid> sessionGuid)
        {
            _gameService = game;
            _sessionGuid = sessionGuid;
            _gameId = sessionGuid.Load("GameId");
            Game = _gameService.GetGame(_gameId);

            
        }

        public void OnGet()
        {
            
            foreach (var item in Game.UserGames)
            {
                partialModels.Add(new BattlefieldPartialModel(_gameService.GetBattlefield(item.NavyBattlePieces.ToList()), item, _gameService.GetUser()));
            }
            
            Game = _gameService.GetGame(_gameId);
            _gameService.ChangeGameState(Game.GameId);
        }

        public ActionResult OnGetDone()
        {
            partialModel = new BattlefieldPartialModel(_gameService.GetBattlefield(_gameService.GetUserGame(_gameId).NavyBattlePieces.ToList()), _gameService.GetUserGame(_gameId), _gameService.GetUser());
            Game = _gameService.GetGame(_gameId);
            _gameService.ChangePlayerState(_gameService.GetUserGame(Game.GameId), PlayerState.Playing);
            _gameService.ChangeGameState(Game.GameId);
            return Page();
        }

        public ActionResult OnGetFire()
        {
            partialModel = new BattlefieldPartialModel(_gameService.GetBattlefield(_gameService.GetUserGame(_gameId).NavyBattlePieces.ToList()), _gameService.GetUserGame(_gameId), _gameService.GetUser());
            Game = _gameService.GetGame(_gameId);

            //TODO

            return Page();
        }
    }
}
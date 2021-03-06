﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;
using Battleships.Models.Enums;
using Battleships.Services;
using Battleships.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Battleships.Pages
{
    public class GameModel : PageModel  //Autor: Petr Horák
    {
        private IGame _gameService;
        private SessionStorage<Guid> _sessionGuid;
        public Game Game;
        public Guid _gameId;
        public int _gameSize;
        public BattlefieldPartialModel partialModel;
        public List<List<NavyBattlePiece>> PlayingField;
        

        public GameModel(IGame game, SessionStorage<Guid> sessionGuid)
        {           
            _gameService = game;
            _sessionGuid = sessionGuid;            
            _gameId = sessionGuid.Load("GameId");
            Game = _gameService.GetGame(_gameId);
        }

        //public void OnGet()
        //{
        //    partialModel = new BattlefieldPartialModel(_gameService.GetBattlefield(_gameId), _gameService.GetGame(_gameId), _gameService);
        //    Game = _gameService.GetGame(_gameId);
        //}

        //public ActionResult OnGetPieceClick(int x, int y, int ug)
        //{
        //    partialModel = new BattlefieldPartialModel(_gameService.GetBattlefield(_gameId), _gameService.GetGame(_gameId), _gameService);
        //    Game = _gameService.GetGame(_gameId);
        //    _gameService.PlaceShip(ug, x, y);
            
        //    return Page();
        //}

        //public ActionResult OnGetDone()
        //{
        //    partialModel = new BattlefieldPartialModel(_gameService.GetBattlefield(_gameId), _gameService.GetGame(_gameId), _gameService);
        //    Game = _gameService.GetGame(_gameId);
        //    _gameService.ChangePlayerState(_gameService.GetUserGame(Game.GameId), PlayerState.Playing);
        //    _gameService.ChangeGameState(Game.GameId);
        //    return Page();
        //}

        //public ActionResult OnGetFire()
        //{
        //    partialModel = new BattlefieldPartialModel(_gameService.GetBattlefield(_gameId), _gameService.GetGame(_gameId), _gameService);
        //    Game = _gameService.GetGame(_gameId);

        //    //TODO

        //    return Page();
        //}
    }
}
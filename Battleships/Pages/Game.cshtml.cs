﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;
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
        

        public GameModel(IGame game, SessionStorage<Guid> sessionGuid, BattlefieldPartialModel partial)
        {           
            _gameService = game;
            _sessionGuid = sessionGuid;            
            _gameId = sessionGuid.Load("GameId");
            partialModel = partial;
        }

        public void OnGet()
        {
            PlayingField = _gameService.GetBattlefield(_gameId);
            Game = _gameService.GetGame(_gameId);

            partialModel._battlefield = PlayingField;
        }
    }
}
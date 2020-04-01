using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Battleships.Pages
{
    public class GameModel : PageModel  //Autor: Petr Horák
    {
        private IGame _gameService;
        public GameModel(IGame game)
        {
            _gameService = game;
        }

        public void OnGet()
        {

        }
    }
}
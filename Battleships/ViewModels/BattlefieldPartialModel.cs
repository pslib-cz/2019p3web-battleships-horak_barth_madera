using Battleships.Models;
using Battleships.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.ViewModels
{
    public class BattlefieldPartialModel
    {
        public List<List<NavyBattlePiece>> Battlefield { get; }
        public Game Game { get; }

        public IGame _gl;

        public BattlefieldPartialModel(List<List<NavyBattlePiece>> bf, Game game, IGame gl)
        {
            Battlefield = bf;
            Game = game;
            _gl = gl;
        }
    }
}

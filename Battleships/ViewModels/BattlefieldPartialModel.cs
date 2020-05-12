using Battleships.Models;
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

        public BattlefieldPartialModel(List<List<NavyBattlePiece>> bf, Game game)
        {
            Battlefield = bf;
            Game = game;
        }
    }
}

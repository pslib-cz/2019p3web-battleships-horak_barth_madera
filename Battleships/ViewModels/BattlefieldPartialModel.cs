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
        public UserGame Ug { get; }


        public BattlefieldPartialModel(List<List<NavyBattlePiece>> bf, Game game, UserGame ug)
        {
            Battlefield = bf;
            Game = game;
            Ug = ug;
        }
    }
}

using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.ViewModels
{
    public class BattlefieldPartialModel
    {
        public List<List<NavyBattlePiece>> _battlefield;

        public BattlefieldPartialModel(List<List<NavyBattlePiece>> bf)
        {
            _battlefield = bf;
        }
    }
}

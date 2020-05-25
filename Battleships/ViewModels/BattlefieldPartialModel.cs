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
        public UserGame UserGame { get; }
        public User LoggedInUser { get; }

        public BattlefieldPartialModel(List<List<NavyBattlePiece>> bf, UserGame ug, User usr)
        {
            Battlefield = bf;
            UserGame = ug;
            LoggedInUser = usr;
        }
    }
}

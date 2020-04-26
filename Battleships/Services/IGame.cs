using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public interface IGame //hra, 2 hrací pole, připojení druhého hráče, konec hry
    {


        void CreateBattleField(UserGame userGame, Game game); //vytvoří NavyBattlePieces a vytvoří pole 
        Game GetGame(Guid gameId);
        Game GetGame(int userGameId);
        NavyBattlePiece GetNavyBattlePiece(Guid gameId);
        List<NavyBattlePiece> GetBattleField(Guid gameId);
    }
}

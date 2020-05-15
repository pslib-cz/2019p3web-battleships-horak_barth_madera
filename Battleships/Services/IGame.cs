using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public interface IGame //hra, 2 hrací pole, připojení druhého hráče, konec hry
    {     
        Game GetGame(Guid gameId);
        Game GetGame(int userGameId);
        UserGame GetUserGame(Guid gameId);
        User GetUser(string userId);
        string GetUserName(string userId);
        void CreateBattleField(UserGame userGame);
        NavyBattlePiece GetNavyBattlePiece(Guid gameId); 
        List<NavyBattlePiece> GetBattlePieces(Guid gameId);
        List<List<NavyBattlePiece>> GetBattlefield(Guid gameId);
        bool JoinGame(Guid gameId);
        bool PlaceShip(int ug, int posX, int posY);
    }
}

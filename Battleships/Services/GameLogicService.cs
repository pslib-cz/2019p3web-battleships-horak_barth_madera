using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public class GameLogicService : IGame //Autor: Petr Horák
    {
        public ApplicationDbContext _db { get; set; }
        

        public GameLogicService(ApplicationDbContext context)
        {
            _db = context;
            
        }

        public void CreateBattleField(UserGame userGame, Game game)
        {

            for (int x = 0; x < game.GameSize; x++)
            {
                for (int y = 0; y < game.GameSize; y++)
                {
                    _db.NavyBattlePieces.Add(new NavyBattlePiece { UserGame = userGame, PosX = x, PosY = y, Hidden = false });
                    _db.SaveChanges();
                }
                _db.SaveChanges();
            }
            
        }

        public Game GetGame(Guid gameId)
        {
            return _db.Games.SingleOrDefault(x => x.GameId == gameId);
        }
        public Game GetGame(int userGameId)
        {
            var ug = _db.UserGames.SingleOrDefault(x => x.Id == userGameId);
            return _db.Games.SingleOrDefault(y => y.GameId == ug.GameId);
        }


        public NavyBattlePiece GetNavyBattlePiece(Guid gameId) 
        {
            var ug = _db.UserGames.SingleOrDefault(x => x.GameId == gameId);
            return _db.NavyBattlePieces.FirstOrDefault(x => x.UserGameId == ug.Id);
        }

        public List<NavyBattlePiece> GetBattleField(Guid gameId)
        {
            var ug = _db.UserGames.SingleOrDefault(x => x.GameId == gameId);
            //battlePieces.Add(_db.NavyBattlePieces.SingleOrDefault(x => x.UserGameId == ug.Id));
            //return battlePieces;

            List<NavyBattlePiece> battlePieces = new List<NavyBattlePiece>();

            foreach (var item in _db.NavyBattlePieces.Where(x => x.UserGameId == ug.Id))
            {
                battlePieces.Add(item);
            }
            return battlePieces;
        }
    }
}

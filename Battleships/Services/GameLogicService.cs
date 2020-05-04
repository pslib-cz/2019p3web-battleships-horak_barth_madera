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

        public void CreateBattleField(UserGame userGame) //jen usergame - HOTOVO
        {
            var g = _db.Games.SingleOrDefault(x => x.GameId == userGame.GameId);

            for (int x = 0; x < g.GameSize; x++)
            {
                for (int y = 0; y < g.GameSize; y++)
                {
                    _db.NavyBattlePieces.Add(new NavyBattlePiece { UserGame = userGame, PosX = x, PosY = y, Hidden = true });
                    
                }
                
            }
            _db.SaveChanges();
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


        public NavyBattlePiece GetNavyBattlePiece(Guid gameId)  // není potřeba moc - pouze testovací
        {
            var ug = _db.UserGames.SingleOrDefault(x => x.GameId == gameId);
            return _db.NavyBattlePieces.FirstOrDefault(x => x.UserGameId == ug.Id);
        }

        public List<NavyBattlePiece> GetBattlePieces(Guid gameId)
        {
            var ug = _db.UserGames.SingleOrDefault(x => x.GameId == gameId);


            //List<NavyBattlePiece> battlePieces = new List<NavyBattlePiece>();
            //foreach (var item in _db.NavyBattlePieces.Where(x => x.UserGameId == ug.Id))
            //{
            //    battlePieces.Add(item);
            //}

            //return battlePieces;

            return _db.NavyBattlePieces.Where(x => x.UserGameId == ug.Id).OrderBy(x => new{  x.PosY, x.PosX } ).ToList(); //seřadit
        }

        //metoda - vrací polepolí 
        private List<NavyBattlePiece> GetExactNavyBattlePieces(Guid gameId, int Xposition) 
        {
            return GetBattlePieces(gameId).Where(x => x.PosX == Xposition).ToList(); //seřadit
        }

        public List<List<NavyBattlePiece>> GetBattlefield(Guid gameId)
        {
            List<List<NavyBattlePiece>> battlefield = new List<List<NavyBattlePiece>>();
            
            // k db jenom jednou GetBattlePieces do Listu

            var g = _db.Games.SingleOrDefault(x => x.GameId == gameId);

            for (int x = 0; x < g.GameSize; x++)
            {
                List<NavyBattlePiece> column = new List<NavyBattlePiece>();

                foreach (var item in GetExactNavyBattlePieces(gameId, x))
                {
                    column.Add(item);
                }

                battlefield.Add(column);
            }

            return battlefield;
        }
    }
}

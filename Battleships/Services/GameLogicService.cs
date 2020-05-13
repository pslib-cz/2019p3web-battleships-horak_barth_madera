using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public class GameLogicService : IGame //Autor: Petr Horák
    {
        private SessionStorage<Guid> _session;
        private ApplicationDbContext _db { get; set; }
        private string _activeUser;

        public GameLogicService(ApplicationDbContext context, Identity identity, SessionStorage<Guid> session)
        {
            _db = context;
            _activeUser = identity.LoginId;
            _session = session;
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
        public UserGame GetUserGame(Guid gameId)
        {           
            return _db.UserGames.SingleOrDefault(x => x.GameId == gameId);           
        }
        public User GetUser(string userId)
        {
            if (userId != null)
            {
                return _db.Users.SingleOrDefault(x => x.Id == userId);
            }
            return new User();
        }


        #region Hrací pole

        public void CreateBattleField(UserGame userGame) //jen usergame - HOTOVO
        {
            var g = _db.Games.SingleOrDefault(x => x.GameId == userGame.GameId);

            for (int x = 0; x < g.GameSize; x++)
            {
                for (int y = 0; y < g.GameSize; y++)
                {
                    _db.NavyBattlePieces.Add(new NavyBattlePiece { UserGame = userGame, PosX = x, PosY = y, Hidden = true, });

                }

            }
            _db.SaveChanges();
        }

        public NavyBattlePiece GetNavyBattlePiece(Guid gameId)  // není potřeba moc - pouze testovací
        {
            var ug = _db.UserGames.SingleOrDefault(x => x.GameId == gameId);
            return _db.NavyBattlePieces.FirstOrDefault(x => x.UserGameId == ug.Id);
        }

        public List<NavyBattlePiece> GetBattlePieces(Guid gameId)
        {
            var ug = _db.UserGames.SingleOrDefault(x => x.GameId == gameId);

            //return _db.NavyBattlePieces.Where(x => x.UserGameId == ug.Id).OrderBy(x => new{  x.PosY, x.PosX } ).ToList(); //SPRÁVNĚ
            return _db.NavyBattlePieces.Where(x => x.UserGameId == ug.Id).OrderBy(x => x.PosY).ThenBy(x => x.PosX).ToList(); //asi taky teď už
        }

        //metoda - vrací polepolí 
        private List<NavyBattlePiece> GetExactNavyBattlePieces(Guid gameId, int Yposition) 
        {
            return GetBattlePieces(gameId).Where(x => x.PosY == Yposition).ToList(); //seřadit
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

            battlefield.Reverse();

            return battlefield;
        }

        #endregion 

        public bool JoinGame(Guid gameId)
        {
            var game = _db.Games.SingleOrDefault(x => x.GameId == gameId);
            

            if (_activeUser == "") return false;

            UserGame ug = new UserGame { Game = game, UserId = _activeUser };

            if (game.UserGames.Count() < game.MaxPlayers)
            {
                game.UserGames.Add(ug);
            }
            

            _session.Save("GameId", game.GameId);
            _db.UserGames.Add(ug);
            CreateBattleField(ug);
            _db.SaveChanges();
            return true;
        }
    }
}

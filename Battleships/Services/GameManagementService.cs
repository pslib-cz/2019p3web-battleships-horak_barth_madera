using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;

namespace Battleships.Services
{
    public class GameManagementService : IGamePreparation //Autor: Michal Barth
    {
        private SessionStorage<Guid> _session;
        private ApplicationDbContext _db;
        private string _activeUser;

        public GameManagementService(ApplicationDbContext db, Identity identity, SessionStorage<Guid> session)
        {
            _db = db;
            _session = session;
            _activeUser = identity.LoginId;
        }

        public void StartGame(int gameSize)
        {
            if (_activeUser == "") return;

            Game tempGame = new Game { 
                GameId = Guid.NewGuid(), 
                GameSize = gameSize, 
                GameState = Models.Enums.GameState.Setup,
                OwnerId = _activeUser };

            UserGame ug = new UserGame();
            ug.GameId = tempGame.GameId;
            ug.UserId = _activeUser;

            _session.Save("GameId", tempGame.GameId);
            string StringGameSize = Convert.ToString(gameSize);
            //_session.Save("GameSize", StringGameSize);
            _db.Games.Add(tempGame);
            _db.UserGames.Add(ug);
            _db.SaveChanges();
        }
    }
}

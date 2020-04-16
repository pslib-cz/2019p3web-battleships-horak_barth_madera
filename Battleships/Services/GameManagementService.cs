using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;

namespace Battleships.Services
{
    public class GameManagementService : IGamePreparation //Autor: Michal Barth
    {
        private SessionStorage<string> _session;
        private ApplicationDbContext _db;

        public GameManagementService(ApplicationDbContext db, SessionStorage<string> session)
        {
            _db = db;
            _session = session;
        }

        public void StartGame(int gameSize)
        {
            Game tempGame = new Game { GameId = Guid.NewGuid(), GameSize = gameSize, GameState = 0 };
            
            _session.Save("GameId", tempGame.GameId.ToString());
            string StringGameSize = Convert.ToString(gameSize);
            _session.Save("GameSize", StringGameSize);
            _db.Games.Add(tempGame);
            _db.SaveChanges();
        }
    }
}

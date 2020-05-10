using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public class MainMenuService : IMainMenu
    {
        private ApplicationDbContext _db;
        private SessionStorage<string> _session;

        public MainMenuService(ApplicationDbContext db, SessionStorage<string> session)
        {
            _db = db;
            _session = session;
        }

        public void DeleteGame(Guid value)
        {
            var tempGame = _db.Games.SingleOrDefault(x => x.GameId == value);
            var ug = _db.UserGames.SingleOrDefault(x => x.GameId == value);
            var nbp = _db.NavyBattlePieces.Where(x => x.UserGame == ug);

            _db.Remove(tempGame);
            _db.Remove(ug);
            _db.Remove(nbp);

            _db.SaveChanges();

            if (!(_db.Games.Contains(tempGame) || _db.UserGames.Contains(ug) /* || _db.NavyBattlePieces.Contains(nbp)*/))
            {
                _session.Save("Message", $"Hra {tempGame} byla úspěšně smazána.");
            } else
            {
                _session.Save("Message", $"Hra {tempGame} nebyla smazána.");
            }
        }

        public Game GetGame(Guid value)
        {
            var ug = _db.Games.SingleOrDefault(x => x.GameId == value);
            return _db.Games.SingleOrDefault(x => x.GameId == ug.GameId);
        }

        public void JoinGame()
        {
            throw new NotImplementedException();
        }
    }
}

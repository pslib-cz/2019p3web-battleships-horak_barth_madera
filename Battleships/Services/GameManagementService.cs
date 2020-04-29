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
        private IGame _gameLogicService;

        public GameManagementService(ApplicationDbContext db, Identity identity, SessionStorage<Guid> session, IGame gameLogicService)
        {
            _db = db;
            _session = session;
            _activeUser = identity.LoginId;
            _gameLogicService = gameLogicService;
        }

        public void StartGame(int gameSize)
        {
            if (_activeUser == "") return;

            Game tempGame = new Game {
                GameId = Guid.NewGuid(),
                MaxPlayers = 2,
                GameSize = gameSize,
                GameState = Models.Enums.GameState.Setup,
                OwnerId = _activeUser,
                CurrentPlayerId = _activeUser
            };

            UserGame ug = new UserGame {
                GameId = tempGame.GameId,
                UserId = _activeUser };

            _session.Save("GameId", tempGame.GameId);
            _db.Games.Add(tempGame);
            _db.UserGames.Add(ug);
            _db.SaveChanges();

            //P.H. 26.4. - Vytvoření hracího pole
            _gameLogicService.CreateBattleField(ug, tempGame);
        }

        public List<Game> LoadAllGames()
        {
            return _db.Games.ToList();
        }

        public List<Game> LoadActiveGames()
        {
            return _db.Games.Where(x => x.CurrentPlayerId == _activeUser).ToList();
        }

        public Game LoadGame(Guid value)
        {
            Game game = new Game
            {
                GameId = value,
                MaxPlayers = _db.Games.SingleOrDefault(x => x.GameId == value).MaxPlayers,
                GameSize = _db.Games.SingleOrDefault(x => x.GameId == value).GameSize,
                GameState = _db.Games.SingleOrDefault(x => x.GameId == value).GameState,
                OwnerId = _db.Games.SingleOrDefault(x => x.GameId == value).OwnerId,
                CurrentPlayerId = _db.Games.SingleOrDefault(x => x.GameId == value).CurrentPlayerId
            };

            return game;
        }
    }
}

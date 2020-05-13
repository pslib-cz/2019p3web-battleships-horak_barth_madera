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
        

        public MainMenuService(ApplicationDbContext db)
        {
            _db = db;
            
        }

        public void DeleteGame(Guid value)
        {
            var tempGame = _db.Games.SingleOrDefault(x => x.GameId == value);
            var ug = _db.UserGames.Where(x => x.GameId == value).ToList(); // Where místo singleordefault
            


            if (ug != null)
            {
                foreach (var item in ug)
                {
                    var nbp = _db.NavyBattlePieces.Where(x => x.UserGame == item).ToList();
                    
                    if (nbp != null)
                    {
                        foreach (var item2 in nbp)
                        {
                            _db.NavyBattlePieces.Remove(item2);
                        }
                    }

                    _db.UserGames.Remove(item);
                    
                }
                
            }
            if (tempGame != null)
            {
                _db.Games.Remove(tempGame);               
            }
            
            
            _db.SaveChanges();

            //if (!(_db.Games.Contains(tempGame) || _db.UserGames.Contains(ug) /* || _db.NavyBattlePieces.Contains(nbp)*/))
            //{
            //    _session.Save("Message", $"Hra {tempGame} byla úspěšně smazána.");
            //}
            //else
            //{
            //    _session.Save("Message", $"Hra {tempGame} nebyla smazána.");
            //}
        }

        public Game GetGame(Guid value)
        {
            var ug = _db.Games.SingleOrDefault(x => x.GameId == value);
            return _db.Games.SingleOrDefault(x => x.GameId == ug.GameId);
        }


    }
}

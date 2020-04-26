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

        public void CreateBattleField(UserGame userGame, Game game) //funguje - v db jsou přeházené PosX PosY - složitější vypisování
        {

            for (int x = 0; x < game.GameSize; x++)
            {
                for (int y = 0; y < game.GameSize; y++)
                {
                    _db.NavyBattlePieces.Add(new NavyBattlePiece { UserGame = userGame, PosX = x, PosY = y, Hidden = false });

                }
            }
            _db.SaveChanges();
        }
    }
}

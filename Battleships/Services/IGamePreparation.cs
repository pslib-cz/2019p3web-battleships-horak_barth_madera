using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;

namespace Battleships.Services
{
    public interface IGamePreparation //umisťování lodí, atd.
    {
        void StartGame(int gameSize);
    }
}

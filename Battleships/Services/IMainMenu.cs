using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public interface IMainMenu //připojení do hry, vytvoření hry, zobrazení hry, vypisování her
    {
        Game GetGame(Guid value);
        void DeleteGame(Guid value);
        void JoinGame();
    }
}

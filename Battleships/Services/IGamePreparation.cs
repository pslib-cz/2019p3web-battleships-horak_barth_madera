﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;

namespace Battleships.Services
{
    public interface IGamePreparation //umisťování lodí, atd.
    {
        void StartGame(int gameSize);

        List<Game> LoadAllGames();

        List<Game> LoadActiveGames();

        Game LoadGame(Guid value);

        void TileAction(Guid gameId, int _x, int _y);
    }
}

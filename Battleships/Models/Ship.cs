﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ShipPiece> ShipPieces { get; set; }
        public ICollection<ShipGame> ShipGames { get; set; }
        public ICollection<ShipUser> ShipUsers { get; set; } //
        public ICollection<NavyBattlePiece> NavyBattlePieces { get; set; }
    }
}

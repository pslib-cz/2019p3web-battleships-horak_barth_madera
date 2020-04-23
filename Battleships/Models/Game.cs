﻿using Battleships.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }

        public int MaxPlayers { get; set; }
        public int GameSize { get; set; }

        // co to znamená?
        public string CurrentPlayerId { get; set; }

        public string OwnerId { get; set; }
        
        [ForeignKey("OwnerId")]
        public User User { get; set; }

        public ICollection<UserGame> UserGames { get; set; }
        public GameState GameState { get; set; }
    }
}

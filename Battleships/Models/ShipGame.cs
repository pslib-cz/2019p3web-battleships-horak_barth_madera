using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class ShipGame
    {
        public int ShipId { get; set; }
        
        [Key]
        public Guid GameId { get; set; }
        
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }
        
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<UserGame> UserGames { get; set; }
    }
}

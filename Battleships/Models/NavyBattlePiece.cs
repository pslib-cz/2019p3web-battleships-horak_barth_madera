using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class NavyBattlePiece
    {
        [Key]
        public int Id { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }

        public string UserGameId { get; set; }
        [ForeignKey("UserGameId")]
        public UserGame UserGame { get; set; }

        public bool Hidden { get; set; }

    }
}

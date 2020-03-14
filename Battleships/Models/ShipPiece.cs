using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class ShipPiece
    {
        [Key]
        public int Id { get; set; }
        
        public int ShipId { get; set; }
        
        public int PosX { get; set; }
        
        public int PosY { get; set; }
        
        public bool IsMargin { get; set; }
        
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }
    }
}

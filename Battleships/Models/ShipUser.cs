using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class ShipUser
    {
        public string UserId { get; set; }

        public int ShipId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }
    }
}

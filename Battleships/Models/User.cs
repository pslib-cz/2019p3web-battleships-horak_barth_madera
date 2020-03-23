using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class User : IdentityUser
    {
        public ICollection<Game> Game { get; set; }
        public ICollection<UserGame> Games { get; set; }
    }
}

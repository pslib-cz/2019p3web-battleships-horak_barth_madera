using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Services
{
    public class GameLogicService
    {
        public ApplicationDbContext _db { get; set; }
        public GameLogicService(ApplicationDbContext context)
        {
            _db = context;
        }
    }
}

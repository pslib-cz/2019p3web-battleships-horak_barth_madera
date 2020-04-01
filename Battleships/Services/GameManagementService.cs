using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Models;

namespace Battleships.Services
{
    public class GameManagementService //Autor: Michal Barth
    {
        private SessionStorage<string> _session;
        private ApplicationDbContext _db;

        public GameManagementService(ApplicationDbContext db, SessionStorage<string> session)
        {
            _db = db;
            _session = session;
        }
    }
}

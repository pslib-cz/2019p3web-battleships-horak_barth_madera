using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Battleships.Services;

namespace Battleships.Pages
{
    public class GamePreparationModel : PageModel //Barth
    {
        public int GameSize;
        private SessionStorage<string> _session;
        public string sessionString;

        public GamePreparationModel(SessionStorage<string> session)
        {
            _session = session;
        }

        public void OnGet()
        {
            sessionString = _session.Load("GameSize");
            GameSize = Convert.ToInt32(sessionString);
        }
    }
}
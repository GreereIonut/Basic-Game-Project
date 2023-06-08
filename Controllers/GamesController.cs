using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Games.Models;
using Games.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Games.Controllers
{
  
    public class GamesController : Controller
    {

         private readonly ApplicationDbContext _db;
        public GamesController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Dislpay
        public IActionResult Index()
        {
            IEnumerable<GameModel> game = _db.Games;

            return View(game);
        }
        //Create
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GameModel game)
        {
            
            _db.Games.Add(game);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
       
    }
}
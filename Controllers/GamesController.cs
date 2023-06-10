using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Games.Models;
using Games.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {

            ViewData["CurrentSort"]=sortOrder;
            ViewData["TitleSortParam"]=String.IsNullOrEmpty(sortOrder)? "title_desc":"";
            ViewData["GenereSortParam"]=sortOrder=="Genere"? "genere_desc":"Genere";
            ViewData["CurrentFilter"]=searchString;

            if(searchString!=null)
            {
                pageNumber=1;
            }
            else
            {
                searchString=currentFilter;
            }

            var games=from s in _db.Games
                      select s;
            
            if(!String.IsNullOrEmpty(searchString))
            {
                games=games.Where(s=>s.Title.Contains(searchString)
                                     || s.Genere.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "title_desc":
                    games=games.OrderByDescending(s=>s.Title);
                    break;
                case "Genere":
                    games=games.OrderBy(s=> s.Genere);
                    break;
                case "genere_desc":
                    games=games.OrderByDescending(s=>s.Genere);
                    break;
                default:
                    games=games.OrderBy(s=>s.Title);
                    break;
            }
            int pageSize=3;
            return View(await PaginatedList<GameModel>.CreateAsync(games.AsNoTracking(),pageNumber?? 1,pageSize));
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
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
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ReviewsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Review(int GameId)
        {
            var model = new ReviewModel { gameId = GameId };
            return View(model);

        }
        [HttpPost]
        public IActionResult InsertReview(ReviewModel reviews, int Gameid)
        {

            reviews.gameId = Gameid;
            _db.Reviews.Add(reviews);
            _db.SaveChanges();
            return RedirectToAction("Index", "Games");
        }

        public IActionResult SeeReviews(int GameId){
            var Reviews=_db.Reviews.Where(g=>g.gameId==GameId);

            return View(Reviews);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeedHead.Models;
using SeedHead.Models.Repositories;
using SeedHead.Data;

namespace SeedHead.Controllers
{
    public class ReviewsController : Controller
    {
        private ISeedRepository seedRepo;
        private IReviewRepository reviewRepo;
        public SeedHeadContext db = new SeedHeadContext();


        public ReviewsController(IReviewRepository repo = null)
        {
            if (repo == null)
            {
                this.reviewRepo = new EFReviewRepository();
                this.seedRepo = new EFSeedRepository();
            }
            else
            {
                this.reviewRepo = repo;
            }
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Details(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }

        public IActionResult Create(int id)
        {
            Seed thisSeed = reviewRepo.Seeds.FirstOrDefault(Seeds => Seeds.SeedId == id);
            ViewBag.Seed = thisSeed;
            return View();

        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            
            reviewRepo.Save(review);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.SeedId = new SelectList(reviewRepo.Seeds, "SeedId", "Name");
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);

            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            reviewRepo.Edit(review);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            Review thisReview = reviewRepo.Reviews.FirstOrDefault(x => x.ReviewId == id);
            reviewRepo.Delete(thisReview);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteAll()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
        public IActionResult DeleteAllReviews()
        {
            reviewRepo.DeleteAll();
            return RedirectToAction("Index");
        }

    }
}

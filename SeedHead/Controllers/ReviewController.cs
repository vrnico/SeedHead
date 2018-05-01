using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeedHead.Models;
using SeedHead.Models.Repositories;

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
            }
            else
            {
                this.reviewRepo = repo;
            }
        }

        public ViewResult Index(int id)
        {

            List<Review> model = reviewRepo.Reviews.Where(r => r.SeedId == id).Include(r => r.Seed).ToList();
            Seed seed = seedRepo.Seeds.Include(s => s.Reviews).FirstOrDefault(s => s.SeedId == id);
            ViewBag.Seed = seed;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }

        public IActionResult Create(int id)
        {
            ViewBag.Seed = seedRepo.Seeds.FirstOrDefault(s => s.SeedId == id);
            return View(new Review() { SeedId = id });

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

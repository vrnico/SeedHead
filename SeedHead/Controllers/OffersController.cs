using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeedHead.Models;


namespace SeedHead.Controllers
{
    public class OffersController : Controller
    {
        private SeedHeadContext db = new SeedHeadContext();
        public IActionResult Index()
        {
            List<Offer> model = db.Offers.ToList();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var thisOffer = db.Offers.Include(offer => offer.Seeds)
            .FirstOrDefault(offers => offers.OfferId == id);
            return View(thisOffer);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Offer offer)
        {
            db.Offers.Add(offer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisOffer = db.Offers.FirstOrDefault(offers => offers.OfferId == id);
            ViewBag.OfferId = new SelectList(db.Seeds, "SeedId", "Name");
            return View(thisOffer);
        }
        [HttpPost]
        public IActionResult Edit(Offer offer)
        {
            db.Entry(offer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisOffer = db.Offers.FirstOrDefault(offers => offers.OfferId == id);
            return View(thisOffer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisOffer = db.Offers.FirstOrDefault(offers => offers.OfferId == id);
            db.Offers.Remove(thisOffer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
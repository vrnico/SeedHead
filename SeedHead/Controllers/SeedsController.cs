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
    public class SeedsController : Controller
    {
    
        private SeedHeadContext db = new SeedHeadContext();

        public IActionResult Index()
        {
        
            return View(db.Seeds.Include(seeds => seeds.Offer).ToList());
        }

        public IActionResult Details(int id)
        {
            Seed thisSeed = db.Seeds.FirstOrDefault(seeds => seeds.SeedId == id);
            return View(thisSeed);
        }

        public IActionResult Create()
        {
            ViewBag.OfferId = new SelectList(db.Offers, "OfferId", "Name");
            return View();
           
        }

        [HttpPost]
        public IActionResult Create(Seed seed)
        {
            db.Seeds.Add(seed);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisSeed = db.Seeds.FirstOrDefault(seeds => seeds.SeedId == id);
            ViewBag.OfferId = new SelectList(db.Offers, "OfferId", "Name");
            return View(thisSeed);
        }

        [HttpPost]
        public IActionResult Edit(Seed seed)
        {
            db.Entry(seed).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisItem = db.Seeds.FirstOrDefault(seeds => seeds.SeedId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisSeed = db.Seeds.FirstOrDefault(seeds => seeds.SeedId == id);
            db.Seeds.Remove(thisSeed);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

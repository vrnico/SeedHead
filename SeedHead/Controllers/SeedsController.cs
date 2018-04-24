using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeedHead.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeedHead.Controllers
{
    public class SeedsController : Controller
    {
        // GET: /<controller>/
        private SeedHeadContext db = new SeedHeadContext();
        public IActionResult Index()
        {
            List<Seed> model = db.Seeds.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Seed thisSeed = db.Seeds.FirstOrDefault(seeds => seeds.SeedId == id);
            return View(thisSeed);
        }

        public IActionResult Create()
        {
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

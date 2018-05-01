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
    public class SeedsController : Controller
    {
    
        private ISeedRepository seedRepo;
        private IReviewRepository reviewRepo;
        public SeedHeadContext db = new SeedHeadContext();

        public SeedsController(ISeedRepository repo = null)
        {
            if (repo == null)
            {
                this.seedRepo = new EFSeedRepository();
            }
            else
            {
                this.seedRepo = repo;
            }
        }

        public ViewResult Index()
        {
        
            return View(seedRepo.Seeds.Include(seeds => seeds.Offer).ToList());
        }

        public IActionResult Details(int id)
        {
            Seed thisSeed = seedRepo.Seeds.FirstOrDefault(seeds => seeds.SeedId == id);
         
            Seed model = seedRepo.Seeds.Include(s => s.Offer).FirstOrDefault(s => s.SeedId == id);
            return View(thisSeed);
        }

        public IActionResult Create()
        {
            ViewBag.OfferId = new SelectList(seedRepo.Offers, "OfferId", "Name");
            return View();
           
        }

        [HttpPost]
        public IActionResult Create(Seed seed)
        {
            seedRepo.Save(seed);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.OfferId = new SelectList(seedRepo.Offers, "OfferId", "Name");
            Seed thisSeed = seedRepo.Seeds.FirstOrDefault(seeds => seeds.SeedId == id);
            
            return View(thisSeed);
        }

        [HttpPost]
        public IActionResult Edit(Seed seed)
        {
            seedRepo.Edit(seed);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Seed thisSeed = seedRepo.Seeds.FirstOrDefault(seeds => seeds.SeedId == id);
            return View(thisSeed);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            Seed thisSeed = seedRepo.Seeds.FirstOrDefault(x => x.SeedId == id);
            seedRepo.Delete(thisSeed);
            
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAll()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
        public IActionResult DeleteAllSeeds()
        {
            seedRepo.DeleteAll();
            return RedirectToAction("Index");
        }

    }
}

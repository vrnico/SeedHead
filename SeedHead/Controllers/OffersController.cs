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
    public class OffersController : Controller
    {
        private IOfferRepository offerRepo;
        private SeedHeadContext db = new SeedHeadContext();

        public OffersController(IOfferRepository repo = null)
        {
            if (repo == null)
            {
                this.offerRepo = new EFOfferRepository();
            }
            else
            {
                this.offerRepo = repo;
            }
        }




        public IActionResult Index()
        {
            List<Offer> model = offerRepo.Offers.ToList();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            Offer thisOffer = offerRepo.Offers.FirstOrDefault(offers => offers.OfferId == id);
            return View(thisOffer);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Offer offer)
        {
            offerRepo.Save(offer);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Offer thisOffer = offerRepo.Offers.FirstOrDefault(offers => offers.OfferId == id);
            return View(thisOffer);
        }
        [HttpPost]
        public IActionResult Edit(Offer offer)
        {
            offerRepo.Edit(offer);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Offer thisOffer = offerRepo.Offers.FirstOrDefault(offers => offers.OfferId == id);
            return View(thisOffer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Offer thisOffer = offerRepo.Offers.FirstOrDefault(offers => offers.OfferId == id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAll()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
        public IActionResult DeleteAllOffers()
        {
            offerRepo.DeleteAll();
            return RedirectToAction("Index");
        }

    }
}
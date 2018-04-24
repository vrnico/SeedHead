﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    }
}
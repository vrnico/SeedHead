using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeedHead.Models;
using SeedHead.Controllers;
using SeedHead.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeedHead.Controllers
{
    public class HomeController : Controller
    {
        private readonly SeedHeadContext _context;

        public HomeController(SeedHeadContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var seedHeadContext = _context.Seeds
                
                .Include(r => r.Reviews);
            List<Seed> seedList= await seedHeadContext.ToListAsync();
            List<Seed> topThree = seedList.OrderByDescending(r => r.Reviews.Count).ToList();
            List<Seed> top3 = topThree.Take(3).ToList();
            return View(top3);
        }

    }
}

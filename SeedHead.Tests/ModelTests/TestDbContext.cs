using Microsoft.EntityFrameworkCore;
using SeedHead.Data;
using SeedHead.Models;

namespace SeedHead.Data
{
    public class TestDbContext : SeedHeadContext
    {
        public override DbSet<Seed> Seeds { get; set; }
        public override DbSet<Offer> Offers { get; set; }
        public override DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=seedhead_test;uid=root;pwd=root;");
        }
    }
}
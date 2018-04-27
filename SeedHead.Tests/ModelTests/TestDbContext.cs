﻿using Microsoft.EntityFrameworkCore;

namespace SeedHead.Models
{
    public class TestDbContext : SeedHeadContext
    {
        public override DbSet<Seed> Seeds { get; set; }
        public override DbSet<Offer> Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;database=seedhead_test;uid=root;pwd=root;");
        }
    }
}
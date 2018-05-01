
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeedHead.Models;

namespace SeedHead.Data

{
    public class SeedHeadContext : DbContext
    {
        public SeedHeadContext()
        {
        }

        public virtual DbSet<Offer> Offers { get; set; }

        public virtual DbSet<Seed> Seeds { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=seedhead;uid=root;pwd=root;");
        }

        public SeedHeadContext(DbContextOptions<SeedHeadContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Offer>().ToTable("Offers");
            builder.Entity<Seed>().ToTable("Seeds");
            base.OnModelCreating(builder);
        }
    }
}
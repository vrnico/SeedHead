using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedHead.Models
{
    public class SeedHeadContext : DbContext
    {
        public DbSet<Seed> Seeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=8889;database=seedhead;uid=root;pwd=root;");
    }
}

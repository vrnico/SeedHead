using Microsoft.EntityFrameworkCore;

namespace SeedHead.Models
{
    public class SeedHeadContext : DbContext
    {
        public SeedHeadContext()
        {
        }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Seed> Seeds { get; set; }

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
            base.OnModelCreating(builder);
        }
    }
}
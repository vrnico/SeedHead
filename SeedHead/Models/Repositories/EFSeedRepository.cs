using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedHead.Models.Repositories
{
    public class EFSeedRepository : ISeedRepository
    {
        SeedHeadContext db = new SeedHeadContext();

        public IQueryable<Seed> Seeds
        { get { return db.Seeds; } }

        public IQueryable<Offer> Offers
        { get { return db.Offers; } }

        public Seed Save(Seed seed)
        {
            db.Seeds.Add(seed);
            db.SaveChanges();
            return seed;
        }

        public Seed Edit(Seed seed)
        {
            db.Entry(seed).State = EntityState.Modified;
            db.SaveChanges();
            return seed;
        }

        public void Delete(Seed seed)
        {
            db.Seeds.Remove(seed);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Seeds;");
        }
    }
}
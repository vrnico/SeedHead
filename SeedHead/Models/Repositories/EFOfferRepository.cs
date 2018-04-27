using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedHead.Models.Repositories
{
    public class EFOfferRepository : IOfferRepository
    {
        SeedHeadContext db = new SeedHeadContext();

        public IQueryable<Offer> Offers
        { get { return db.Offers; } }

        public IQueryable<Seed> Seeds
        { get { return db.Seeds; } }

        public Offer Save(Offer offer)
        {
            db.Offers.Add(offer);
            db.SaveChanges();
            return offer;
        }

        public Offer Edit(Offer offer)
        {
            db.Entry(offer).State = EntityState.Modified;
            db.SaveChanges();
            return offer;
        }

        public void Delete(Offer offer)
        {
            db.Offers.Remove(offer);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Offers;");
        }
    }
}

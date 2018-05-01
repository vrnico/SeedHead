using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeedHead.Data;

namespace SeedHead.Models.Repositories

{
    public interface IOfferRepository
    {
        IQueryable<Offer> Offers { get; }
        IQueryable<Seed> Seeds { get; }
        Offer Save(Offer offer);
        Offer Edit(Offer offer);
        void Delete(Offer offer);
        void DeleteAll();
    }
}

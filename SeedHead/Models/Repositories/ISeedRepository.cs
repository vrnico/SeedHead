using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedHead.Models
{
    public interface ISeedRepository
    {
        IQueryable<Seed> Seeds { get; }
        IQueryable<Offer> Offers { get; }
        Seed Save(Seed seed);
        Seed Edit(Seed seed);
        void Delete(Seed seed);
        void DeleteAll();
    }
}
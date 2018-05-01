using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeedHead.Data;

namespace SeedHead.Models.Repositories
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        IQueryable<Seed> Seeds { get; }
        Review Save(Review review);
        Review Edit(Review review);
        void Delete(Review review);
        void DeleteAll();
    }
}
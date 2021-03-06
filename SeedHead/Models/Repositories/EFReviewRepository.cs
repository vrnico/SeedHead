﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using SeedHead.Data;
using System.Threading.Tasks;

namespace SeedHead.Models.Repositories
{
    public class EFReviewRepository : IReviewRepository
    {
        SeedHeadContext db = new SeedHeadContext();

        public EFReviewRepository()
        {
            db = new SeedHeadContext();
        }
        public EFReviewRepository(SeedHeadContext thisDb)
        {
            db = thisDb;
        }





        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public IQueryable<Seed> Seeds
        { get { return db.Seeds; } }

        public Review Save(Review review)
        {
            
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Delete(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Reviews;");
        }
    }
}
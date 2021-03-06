﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SeedHead.Data;


namespace SeedHead.Models
{
    [Table("Seeds")]
    public class Seed
    {

        [Key]
        public int SeedId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public Seed(string name, int amount, string description)
        {
            Name = name;
            Amount = amount;
            Description = description;
            OfferId = 0;


        }


        public Seed()
        {
        }




        public override bool Equals(object seedNon)
        {
            if (!(seedNon is Seed))
            {
                return false;
            }
            else
            {
                Seed newSeed = (Seed)seedNon;
                return this.SeedId.Equals(newSeed.SeedId);
            }
        }

        public override int GetHashCode()
        {
            return this.SeedId.GetHashCode();
        }

        public int GetRating(Seed seed)
        {
            if(seed.Reviews.Count > 0)
            {
                List<int> ratings = new List<int>();
                foreach (var review in seed.Reviews)
                {
                    ratings.Add(review.Rating);
                }
                int avgRating = (int)Math.Round(ratings.Average());
                return avgRating;

            }
            else
            {
                return 0;
            }
        }
    }
}




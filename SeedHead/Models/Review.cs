using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SeedHead.Data;


namespace SeedHead.Models

{
    [Table("Reviews")]
    public class Review
    {

        [Key]
        public int ReviewId { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public string Name { get; set; }
        public int SeedId { get; set; }
        
        public virtual Seed Seed { get; set; }

        public Review(string name, int rating, string description)
        {
            Name = name;
            Rating = rating;
            Description = Description;
            SeedId = 0;


        }


        public Review()
        {
        }




        public override bool Equals(object reviewNon)
        {
            if (!(reviewNon is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)reviewNon;
                return this.ReviewId.Equals(newReview.ReviewId);
            }
        }

        public override int GetHashCode()
        {
            return this.ReviewId.GetHashCode();
        }

        public bool RatingOneThruFive()
        {
            if (Rating <= 0 || Rating > 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool DescLength()
        {
            if (Description.Length > 255)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

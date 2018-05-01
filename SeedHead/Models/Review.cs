using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeedHead.Models

{
    [Table("Reviews")]
    public class Review
    {

        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
     

        [ForeignKey("Seeds")]
        public int SeedId { get; set; }
        public virtual Seed Seed { get; set; }




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
    }
}

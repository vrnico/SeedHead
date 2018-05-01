using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SeedHead.Data;

namespace SeedHead.Models
{
    [Table("Offers")]
    public class Offer
    {
 
        [Key]
        public int OfferId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Seed> Seeds { get; set; }


        public override bool Equals(object offerNon)
        {
            if (!(offerNon is Offer))
            {
                return false;
            }
            else
            {
                Offer newOffer = (Offer)offerNon;
                return this.OfferId.Equals(newOffer.OfferId);
            }
        }

        public override int GetHashCode()
        {
            return this.OfferId.GetHashCode();
        }
    }
}

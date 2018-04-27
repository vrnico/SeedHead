using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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


        public Seed(string name, string description, int amount)
        {
            Name = name;
            Description = description;
            Amount = amount;
            SeedId = 0;
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
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeedHead.Models
{
    [Table("Offers")]
    public class Offer
    {
        public Offer()
        {
            this.Seeds = new HashSet<Seed>();
        }

        [Key]
        public int OfferId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Seed> Seeds { get; set; }
    }
}

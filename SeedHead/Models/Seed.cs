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
    }


}

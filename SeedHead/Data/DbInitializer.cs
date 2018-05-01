using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SeedHead.Models;

namespace SeedHead.Data
{
    public class DbInitializer
    {
        public static void Initialize(SeedHeadContext context)
        {
            if (context.Seeds.Any())
            {
                return;
            }


            var offers = new Offer[]
           {
               new Offer(){ Name = "Human Flesh Body World" },
               new Offer(){ Name = "Fail House" },
               new Offer(){ Name = "Cam's Gardening Palace" },
               new Offer(){ Name = "DIY Seed Farm" }
           };

            var seeds = new Seed[]
            {
               new Seed(){ Name = "Amaranth", Description = "Plant with the spring or summer rains. Broadcast or rake the tiny seeds, covering with 1/4 inch of soil. Thin any crowded seedlings and add them to a salad. Amaranth species are wind pollinated and easily cross, bag seedheads to maintain purity. Bagging maturing seedheads makes harvesting the grain easy as well. Approx. 0.3g/300 seeds per packet.", Amount = 20, OfferId= 1},

                new Seed(){ Name = "Red Cored Chantenay", Description = "Our farm crew all rated it at or near the top for eating quality; great for consuming fresh or cooked. An excellent performer in heavy as well as loamy soils; broad (1.5-2in) shoulders, 4 - 6in long roots that have a a blunt tip. Strong, bushy, 2 ft. tops are effective for competing with weeds and make for easy pulling. Organically grown. Approx. 2g/1200 seeds per packet.", Amount = 100, OfferId= 3},

                new Seed(){ Name = "Dragon Carrot", Description = "Dragon is a striking carrot variety that produces 7in long, broad shouldered carrots with bright purple skin and an orange interior. It offers the best flavor of all purple varieties and is an excellent keeper. Purple carrots are extra nutritious in comparison with orange carrots.   Approx. 1g/600 seeds per packet.", Amount = 100, OfferId= 1},

                  new Seed(){ Name = "Chihuahuan Maiz Dulce", Description = "A rare maiz dulce variety from Cerocahui, Chihuahua. Long, slender 6-10in ears produced on tall 8ft stalks. Some occasional blue and white floury kernels.  If you want more sweet kernels and fewer flour kernels, plant only the translucent yellow seeds.", Amount = 50, OfferId= 4},

                new Seed(){ Name = "Lettuce Mixed", Description = "This diverse mix of lettuce varieties contains equal proportions of Summer Bibb, Black-Seeded Simpson, Oakleaf, Red Saladbowl, and Paris Island Cos.  A beautiful blend of colors, tastes and textures for your salad.  Approx. 1g/700 seeds per packet.", Amount = 50, OfferId= 3},

                 new Seed(){ Name = "Oregon Sugar Peas", Description = "Snow pea (edible pods). Famous for its sweet, mild flavor. Delicious raw, in stir-fries or steamed al dente. Tall, 24-30in vines bear smooth, 4in pea pods. Resistant to both pea enation virus and powdery mildew. Organically grown.  Approx. 11g/50 seeds per packet.", Amount = 50, OfferId= 3},

                 new Seed(){ Name = "Nichols Heirloom", Description = "These seeds were sent to us by the Nichols family in Tucson. Volunteer seeds that just kept coming up, they have been maintained by the family patriarch for about 50 years. It is well adapted to the desert; it is heat-tolerant and prefers full sunlight. These \"pink cherry\" tomatoes are prolific producers. Approx. 0.1g/25 seeds per packet.", Amount = 50, OfferId= 2},

                  new Seed(){ Name = "Sunflower", Description = "Also known as Annual Sunflower or Wild Sunflower.  This wild ancestor of domesticated sunflowers is native throughout the southwestern US.  Multi-branched plants bear 2 inch wide flowers on stalks growing 3-6 feet tall.   Birds love the seeds.    Under some conditions this plant will reseed and can spread into colonies, so it is considered invasive in some states.", Amount = 200, OfferId= 2},

                new Seed(){ Name = "Crimson Sweet Watermelon", Description = "Bright red color, fewer and smaller seeds and an above average sugar content. An oblong member of the \"picnic\" family of watermelons. Commonly weighs 20-30 lbs. Resistant to anthracnose and fusarium wilt. Highly adaptable.  Organically grown.   Approx. 1g/25 seeds per packet.", Amount = 100, OfferId= 4},

                new Seed(){ Name = "White Egg Turnip", Description = "Egg-shaped, round white roots. Ideal for early market bunching. Very sweet and mild fresh from the garden! Approx. 1g/600 seeds per packet.", Amount = 100, OfferId= 1}


            };


            foreach (Seed s in seeds)
            {
                context.Seeds.Add(s);
            }


            foreach (Offer o in offers)
            {
                context.Offers.Add(o);
            }





            context.SaveChanges();
        }
    }
}
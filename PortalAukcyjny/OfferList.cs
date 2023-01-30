using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAukcyjny
{
    public class OfferList
    {
        public List<Offer> listOffers { get; set; }

        public OfferList()
        {
            listOffers = new List<Offer>();

            listOffers.Add(new Offer()
            {
                Item = "Iphone 12 PRO",
                Category = "elektronika",
                Price = 4600,
                Special = true
            });

            listOffers.Add(new Offer()
            {
                Item = "Konsola Playstation 5",
                Category = "elektronika",
                Price = 2899,
                Special = false
            });

            listOffers.Add(new Offer()
            {
                Item = "Bluza Adidas Meska Szara",
                Category = "odzież",
                Price = 249,
                Special = true
            });

            listOffers.Add(new Offer()
            {
                Item = "Spodnie Wrangler Arizona",
                Category = "odzież",
                Price = 189,
                Special = false
            });

            listOffers.Add(new Offer()
            {
                Item = "Basen ogrodowy Premium",
                Category = "dom i ogrod",
                Price = 1199,
                Special = false
            });

            listOffers.Add(new Offer()
            {
                Item = "Krzeslo skandynawskie granatowe",
                Category = "dom i ogrod",
                Price = 88,
                Special = false
            });

            listOffers = listOffers.OrderByDescending(l => l.Special).ToList();

            int i = 1;
            foreach(var item in listOffers)
            {
                item.Id = i;
                i++;
            }
        }

        public void AddOfferToList(Offer offer)
        {
            int itemNumbers = listOffers.Count;

            offer.Id = itemNumbers + 1;

            listOffers.Add(offer);

            listOffers = listOffers.OrderByDescending(l => l.Special).ToList();
        }

        public void WriteList()
        {
            int i = 1;
            foreach(var item in listOffers)
            {
                if(item.Special)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{item.Id}. {item.Item} | {item.Category} | {item.Price} PLN\n");
                i++;

                Console.ResetColor();
            }
        }

        public Offer GetOfferById(int id)
        {
            var offer = listOffers.Where(l => l.Id == id).FirstOrDefault();

            if(offer!=null)
            {
                return offer;
            }

            return null;
        }
    }
}

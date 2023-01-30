using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAukcyjny
{
    public class Offer
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool Special { get; set; }

        public Offer()
        {

        }

        public Offer(string item, string category, decimal price, bool special)
        {
            Item = item;
            Category = category;
            Price = price;
            Special = special;
        }
    }
}

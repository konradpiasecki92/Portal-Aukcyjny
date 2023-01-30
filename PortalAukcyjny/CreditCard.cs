using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAukcyjny
{
    public  class CreditCard
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public decimal Limit { get; set; }

        public CreditCard()
        {

        }

        public CreditCard(string name, string cardNumber, decimal limit)
        {
            Name = name;
            CardNumber = cardNumber;
            Limit = limit;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAukcyjny
{
    public class CreditCardList
    {
        public List<CreditCard> creditsCards { get; set; }

        public CreditCardList()
        {
            creditsCards = new List<CreditCard>();

            creditsCards.Add(new CreditCard()
            {
                Name = "Visa",
                CardNumber = "0001",
                Limit = 100
            });

            creditsCards.Add(new CreditCard()
            {
                Name = "Mastercard",
                CardNumber = "0002",
                Limit = 10000
            });

            creditsCards.Add(new CreditCard()
            {
                Name = "American Express",
                CardNumber = "0003",
                Limit = 3000
            });

            creditsCards.Add(new CreditCard()
            {
                Name = "Diners Club",
                CardNumber = "0004",
                Limit = 1000
            });

        }

        public bool ValidateAmount(string cardNumber, decimal price)
        {
            var card = creditsCards.Where(c => c.CardNumber == cardNumber).FirstOrDefault();

            if (card != null && card.Limit>= price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CreditCard GetCreditCard(string cardNumber)
        {
            var card = creditsCards.Where(c => c.CardNumber == cardNumber).FirstOrDefault();

            return card;
        }

        public void UpdateBalance(string cardNumber, decimal price)
        {
            var card = creditsCards.Where(c => c.CardNumber == cardNumber).FirstOrDefault();
            card.Limit = card.Limit - price;
        }
    }
}

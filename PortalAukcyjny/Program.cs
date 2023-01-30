using PortalAukcyjny;
using System.Diagnostics;

bool zamknij =false;

while (!zamknij)
{
    Console.Clear();
    Console.WriteLine("WYBIERZ OPCJE:\n");
    Console.WriteLine("1 => ZAKUP\n");
    Console.WriteLine("2 => SPRZEDAŻ\n");
    Console.WriteLine("3 => ZAKOŃCZ PROGRAM\n");
    Console.WriteLine("WYBIERZ 1, 2 LUB 3:");


    if (!int.TryParse(Console.ReadLine(), out int wybor))
    {
        Console.WriteLine("Blad!");
    }
    else
    {
        

        OfferList offerList = new OfferList();
        CreditCardList cardList = new CreditCardList();
        switch (wybor)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("LISTA PRZEDMIOTOW NA AUKCJE\n");
                Console.WriteLine("-----------------------------\n");
                offerList.WriteList();
                Console.WriteLine("PODAJ NUMER PRODUKTU KTÓRY CHCESZ ZAKUPIĆ:\n");
                int wyborProduktu = int.Parse(Console.ReadLine());
                
                Console.Clear();
                Console.WriteLine("PODAJ NUMER KARTY KREDYTOWEJ (CZTERY CYFRY):\n");
                string cardNumber = Console.ReadLine();
                var itemCheck = offerList.GetOfferById(wyborProduktu);
                while (!cardList.ValidateAmount(cardNumber, itemCheck.Price))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NIEWYSTARCZAJĄCY LIMIT NA RACHUNKU KARTY");
                    Console.ResetColor();
                    Console.WriteLine("PODAJ NUMER KARTY KREDYTOWEJ (CZTERY CYFRY):\n");
                    cardNumber = Console.ReadLine();
                }

                Console.Clear();
                var card = cardList.GetCreditCard(cardNumber);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Kupiłeś przedmiot: {itemCheck.Item}\n");
                Console.WriteLine($"Cena: {itemCheck.Price} PLN\n");
                Console.WriteLine($"Płatność kartą: {card.Name} (nr karty: {card.CardNumber})\n");
                cardList.UpdateBalance(cardNumber, itemCheck.Price);
                Console.ResetColor();
                Console.WriteLine("Aby przejsc dalej nacisnij klawisz...");
                Console.ReadKey();

                break;
            case 2:
                Console.Clear();
                Console.WriteLine("PODAJ NAZWĘ PRZEDMIOTU, KTÓRY CHCESZ SPRZEDAĆ: \n");
                string name = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("PODAJ KATEGORIĘ PRZEDMIOTU, DO KTÓREJ NALEŻY PRODUKT: \n");
                string category = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("PODAJ CENĘ PRZEDMIOTU, KTÓRĄ CHCESZ OTRZYMAĆ: \n");
                string priceText = Console.ReadLine();
                decimal price;
                bool isValid = false;

                do
                {
                    Console.WriteLine("PODAJ CENĘ PRZEDMIOTU, KTÓRĄ CHCESZ OTRZYMAĆ: \n");
                    isValid = decimal.TryParse(priceText, out price);

                    if (isValid)
                    {
                        Console.Clear();
                        Console.WriteLine("ZŁA CENA! \n");
                        Console.WriteLine("PODAJ CENĘ PRZEDMIOTU, KTÓRĄ CHCESZ OTRZYMAĆ: \n");
                    }
                }
                while (!isValid);


                Console.Clear();
                Console.WriteLine("NAPISZ \"tak\" JEŻELI PRZEDMIOT MA BYĆ PROMOWANY: \n");
                string promoText = Console.ReadLine();
                bool promo = false;

                if(promoText.ToLower() == "tak")
                {
                    promo = true;
                }

                Offer newOffer = new Offer(name, category, price, promo);
                offerList.AddOfferToList(newOffer);

                break;
            case 3:
                zamknij = true;
                break;
        }

        if(!zamknij)
        {

            Console.Clear();
            Console.WriteLine($"CZY CHCESZ ZAMKNĄC APLIKACJE ? (T/N) \n");
            string odp = Console.ReadLine();
            if (odp.ToLower() == "t")
            {
                zamknij = true;
            }
            else
            {
                zamknij = false;
            }
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Yugioh
{
    public class TrapCardContainer : CardContainer
    {
        public TrapCardContainer()
        {
            foreach (string name in CardData.TrapNames)
            {
                bool found = false;
                foreach (Card c in (Application.Current as App).myDeckCardData.Collection.ToList())
                {
                    // Don't add a card to trap deck if it's already in My Deck
                    if (name == c.Name)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Collection.Add(TrapCardData.NewCard(name));
                }
            }
        }
    }

    public class TrapCard : Card
    {
        public string Category { get; set; }
        public TrapCard()
        {
            CardType = "Trap";
        }
    }
}

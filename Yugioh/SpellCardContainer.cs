using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Yugioh
{
    public class SpellCardContainer : CardContainer
    {
        public SpellCardContainer()
        {
            foreach (string name in CardData.SpellNames)
            {
                bool found = false;
                foreach (Card c in (Application.Current as App).myDeckCardData.Collection.ToList())
                {
                    // Don't add a card to spell deck if it's already in My Deck
                    if (name == c.Name)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Collection.Add(SpellCardData.NewCard(name));
                }
            }
        }
    }

    public class SpellCard : Card
    {
        public string Category { get; set; }
        public SpellCard()
        {
            CardType = "Spell";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Yugioh
{
    // Wrapper for a collection of monster cards (only used for deck builder)
    public class MonsterCardContainer : CardContainer
    {
        public MonsterCardContainer()
        {
            foreach (string name in CardData.MonsterNames)
            {
                bool found = false;
                foreach (Card c in (Application.Current as App).myDeckCardData.Collection.ToList())
                {
                    // Don't add a card to monster deck if it's already in My Deck
                    if (name == c.Name)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Collection.Add(MonsterCardData.NewCard(name));
                }
            }
        }
    }

    // Extra definitions specific to monster cards
    public class MonsterCard : Card, IComparable
    {
        public MonsterCard()
        {
            CardType = "Monster";
        }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public void SetPower(int atk, int def)
        {
            Attack = atk;
            Defense = def;
            ShortDescription = atk + "/" + def;
        }
        public int CompareTo(object o)
        {
            MonsterCard c = o as MonsterCard;
            if (c == null)
            {
                throw new ArgumentException("Object is not a Card");
            }
            int primary = this.Attack.CompareTo(c.Attack);
            if (primary == 0)
            {
                return this.Defense.CompareTo(c.Defense);
            }
            return primary;
        }
    }
}

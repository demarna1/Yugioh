using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yugioh
{
    public class Player
    {
        // Public properties for a player
        public int LifePoints { get; set; }
        public CardCollection Hand { get; set; }
        public CardCollection Deck { get; set; }
        public CardCollection Graveyard { get; set; }
        public CardCollection FieldMonsters { get; set; }
        public CardCollection FieldSpells { get; set; }

        // Constructor for new player
        public Player()
        {
            LifePoints = 8000;
            Hand = new CardCollection();
            Deck = new CardCollection();
            Graveyard = new CardCollection();
            FieldMonsters = new CardCollection();
            FieldSpells = new CardCollection();
        }
    }
}

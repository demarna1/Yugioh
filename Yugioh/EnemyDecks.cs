using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yugioh
{
    public static class EnemyDecks
    {
        public static readonly string[] EnemyDeck1 = 
        {
            "Harpie Girl",
            "M-Warrior #2",
            "One-Eyed Shield Dragon",
            "Kumootoko",
            "Science Soldier",
            "Spirit of the Harp",
            "Flame Manipulator",
            "Silver Fang",
            "Terra the Terrible",
            "Dark Titan of Terror",
            "D. Human",
            "Feral Imp",
            "Clown Zombie",
            "Armored Lizard",
            "Rogue Doll",
        };

        public static CardCollection CreateEnemyCollection() 
        {
            // Create enemy deck collection and return
            CardCollection enemyDeck = new CardCollection();
            foreach (string c in EnemyDeck1)
            {
                enemyDeck.Add(CardData.CreateCardFromName(c));
            }
            return enemyDeck;
        }
    }
}

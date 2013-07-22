using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yugioh
{
    public class EffectCardContainer : CardContainer
    {
        public EffectCardContainer()
        {
        }
    }

    public class EffectCard : Card
    {
        public string Category { get; set; }
        public EffectCard()
        {
            CardType = "Effect";
        }
    }
}

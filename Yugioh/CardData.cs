using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Yugioh
{
    public static class CardData
    {
        public static readonly string[] MonsterNames = 
        {
            "Skull Servant",
            "Harpie Girl",
            "M-Warrior #2",
            "Swordsman of Landstar",
            "One-Eyed Shield Dragon",
            "Kumootoko",
            "Science Soldier",
            "Spirit of the Harp",
            "Flame Manipulator",
            "Dokuroyaiba",
            "M-Warrior #1",
            "Fairy Dragon",
            "Baby Dragon",
            "Silver Fang",
            "Terra the Terrible",
            "Ogre of the Black Shadow",
            "Aqua Madoor",
            "Dark Titan of Terror",
            "D. Human",
            "Feral Imp",
            "Magical Ghost",
            "Giant Soldier of Stone",
            "Clown Zombie",
            "Witty Phantom",
            "Armored Lizard",
            "Gazelle the King of Mythical Beasts",
            "Rogue Doll",
            "Darkfire Soldier #1",
            "Ansatsu",
            "Rude Kaiser",
            "Gyakutenno Megami",
            "Curse of Dragon",
            "Judge Man",
            "Beast of Talwar",
            "Dark Magician",
            "Wingweaver"
        };

        public static readonly string[] SpellNames =
        {
            "Block Attack",
            "Dian Keto the Cure Master",
            "Pot of Greed",
            "Remove Trap",
            "Stop Defense"
        };

        public static readonly string[] TrapNames = 
        {
            "Castle Walls",
            "Enchanted Javelin",
            "Reinforcements",
            "Ring of Destruction",
            "Solemn Wishes",
            "Ultimate Offering"
        };

        public static Card CreateCardFromName(string name)
        {
            foreach (string s in MonsterNames)
            {
                if (s == name)
                {
                    return MonsterCardData.NewCard(name);
                }
            }
            foreach (string s in SpellNames)
            {
                if (s == name)
                {
                    return SpellCardData.NewCard(name);
                }
            }
            foreach (string s in TrapNames)
            {
                if (s == name)
                {
                    return TrapCardData.NewCard(name);
                }
            }
            return null;
        }
    }

    public static class MonsterCardData
    {
        public static MonsterCard NewCard(string name)
        {
            Uri baseUri = new Uri("ms-appx:///");
            MonsterCard card = new MonsterCard();
            card.Name = name;
            switch (name)
            {
                case "Skull Servant":
                    card.Description = "A skeletal ghost that isn't strong but can mean trouble in large numbers.";
                    card.SetImage(baseUri, "Assets/Monster/SkullServant.jpg");
                    card.SetPower(300, 200);
                    break;
                case "Harpie Girl":
                    card.Description = "A Harpie chick who aspires to flit about beautifully and gorgeously, but attack sharply.";
                    card.SetImage(baseUri, "Assets/Monster/HarpieGirl.jpg");
                    card.SetPower(500, 500);
                    break;
                case "M-Warrior #2":
                    card.Description = "Specializing in combination attacks, this warrior is equipped with a tough, magnetically coated armor.";
                    card.SetImage(baseUri, "Assets/Monster/MWarrior2.jpg");
                    card.SetPower(500, 1000);
                    break;
                case "Swordsman of Landstar":
                    card.Description = "An amateur with a sword, this fairy warrior relies on its mysterious powers.";
                    card.SetImage(baseUri, "Assets/Monster/SwordsmanOfLandstar.jpg");
                    card.SetPower(500, 1200);
                    break;
                case "One-Eyed Shield Dragon":
                    card.Description = "This dragon wears a shield not only for its own protection, but also for ramming its enemies.";
                    card.SetImage(baseUri, "Assets/Monster/OneEyedShieldDragon.jpg");
                    card.SetPower(700, 1300);
                    break;
                case "Kumootoko":
                    card.Description = "A massive, intelligent spider that traps enemies with webbing.";
                    card.SetImage(baseUri, "Assets/Monster/Kumootoko.jpg");
                    card.SetPower(700, 1400);
                    break;
                case "Science Soldier":
                    card.Description = "Soldiers equipped with state-of-the-art weaponry to face unknown creatures.";
                    card.SetImage(baseUri, "Assets/Monster/ScienceSoldier.jpg");
                    card.SetPower(800, 800);
                    break;
                case "Spirit of the Harp":
                    card.Description = "A spirit that soothes the soul with the music of its heavenly harp.";
                    card.SetImage(baseUri, "Assets/Monster/SpiritOfTheHarp.jpg");
                    card.SetPower(800, 2000);
                    break;
                case "Flame Manipulator":
                    card.Description = "This Spellcaster attacks enemies with fire-related spells such as \"Sea of Flames\" and \"Wall of Fire\".";
                    card.SetImage(baseUri, "Assets/Monster/FlameManipulator.jpg");
                    card.SetPower(900, 1000);
                    break;
                case "Dokuroyaiba":
                    card.Description = "A boomerang with brains that will pursue a target to the ends of the earth.";
                    card.SetImage(baseUri, "Assets/Monster/Dokuroyaiba.jpg");
                    card.SetPower(1000, 400);
                    break;
                case "M-Warrior #1":
                    card.Description = "Specializing in combination attacks, this warrior uses magnetism to block an enemy's escape.";
                    card.SetImage(baseUri, "Assets/Monster/MWarrior1.jpg");
                    card.SetPower(1000, 500);
                    break;
                case "Fairy Dragon":
                    card.Description = "This beautiful Dragon spirit harbors hidden strength.";
                    card.SetImage(baseUri, "Assets/Monster/FairyDragon.jpg");
                    card.SetPower(1100, 1200);
                    break;
                case "Baby Dragon":
                    card.Description = "Much more than just a child, this dragon is gifted with untapped power.";
                    card.SetImage(baseUri, "Assets/Monster/BabyDragon.jpg");
                    card.SetPower(1200, 700);
                    break;
                case "Silver Fang":
                    card.Description = "A snow wolf that's beautiful to the eye, but absolutely vicious in battle.";
                    card.SetImage(baseUri, "Assets/Monster/SilverFang.jpg");
                    card.SetPower(1200, 800);
                    break;
                case "Terra the Terrible":
                    card.Description = "Known as a swamp dweller, this creature is a mission of the dark forces.";
                    card.SetImage(baseUri, "Assets/Monster/TerraTheTerrible.jpg");
                    card.SetPower(1200, 1300);
                    break;
                case "Ogre of the Black Shadow":
                    card.Description = "An ogre possessed by the powers of the dark. Few can withstand its rapid charge.";
                    card.SetImage(baseUri, "Assets/Monster/OgreOfTheBlackShadow.jpg");
                    card.SetPower(1200, 1400);
                    break;
                case "Aqua Madoor":
                    card.Description = "A wizard of the waters that conjures a liquid wall to crush any enemies that oppose him.";
                    card.SetImage(baseUri, "Assets/Monster/AquaMadoor.jpg");
                    card.SetPower(1200, 2000);
                    break;
                case "Dark Titan of Terror":
                    card.Description = "A fiend said to dwell in the world of dreams, it attacks enemies in their sleep.";
                    card.SetImage(baseUri, "Assets/Monster/DarkTitanOfTerror.jpg");
                    card.SetPower(1300, 1100);
                    break;
                case "D. Human":
                    card.Description = "Gifted with the power of dragons, this warrior wields a sword created from a dragon's fang.";
                    card.SetImage(baseUri, "Assets/Monster/DHuman.jpg");
                    card.SetPower(1300, 1100);
                    break;
                case "Feral Imp":
                    card.Description = "A playful little fiend that lurks in the dark, waiting to attack an unwary enemy.";
                    card.SetImage(baseUri, "Assets/Monster/FeralImp.jpg");
                    card.SetPower(1300, 1400);
                    break;
                case "Magical Ghost":
                    card.Description = "This creature casts a spell of terror and confusion just before attacking its enemies.";
                    card.SetImage(baseUri, "Assets/Monster/MagicalGhost.jpg");
                    card.SetPower(1300, 1400);
                    break;
                case "Giant Soldier of Stone":
                    card.Description = "A giant warrior made of stone. A punch from this creature has earth-shaking results.";
                    card.SetImage(baseUri, "Assets/Monster/GiantSoldierOfStone.jpg");
                    card.SetPower(1300, 2000);
                    break;
                case "Clown Zombie":
                    card.Description = "A clown revived by the powers of darkness. Its deadly dance has sent many monsters to their graves.";
                    card.SetImage(baseUri, "Assets/Monster/ClownZombie.jpg");
                    card.SetPower(1350, 0);
                    break;
                case "Witty Phantom":
                    card.Description = "Dressed in a night-black tuxedo, this creature presides over death.";
                    card.SetImage(baseUri, "Assets/Monster/WittyPhantom.jpg");
                    card.SetPower(1400, 1300);
                    break;
                case "Armored Lizard":
                    card.Description = "A lizard with a very tough hide and a vicious bite.";
                    card.SetImage(baseUri, "Assets/Monster/ArmoredLizard.jpg");
                    card.SetPower(1500, 1200);
                    break;
                case "Gazelle the King of Mythical Beasts":
                    card.Description = "This monster moves so fast that it looks like an illusion to mortal eyes.";
                    card.SetImage(baseUri, "Assets/Monster/GazelleTheKingOfMythicalBeasts.jpg");
                    card.SetPower(1500, 1200);
                    break;
                case "Rogue Doll":
                    card.Description = "A deadly doll gifted with mystical power, it is particularly powerful when attacking against dark forces.";
                    card.SetImage(baseUri, "Assets/Monster/RogueDoll.jpg");
                    card.SetPower(1600, 1000);
                    break;
                case "Darkfire Soldier #1":
                    card.Description = "An explosive expert from a special elite force.";
                    card.SetImage(baseUri, "Assets/Monster/DarkfireSoldier1.jpg");
                    card.SetPower(1700, 1150);
                    break;
                case "Ansatsu":
                    card.Description = "A silent and deadly warrior specializing in assassination.";
                    card.SetImage(baseUri, "Assets/Monster/Ansatsu.jpg");
                    card.SetPower(1700, 1200);
                    break;
                case "Rude Kaiser":
                    card.Description = "With an axe in each hand, this monster delivers heavy damage.";
                    card.SetImage(baseUri, "Assets/Monster/RudeKaiser.jpg");
                    card.SetPower(1800, 1600);
                    break;
                case "Gyakutenno Megami":
                    card.Description = "This fairy uses her mystical power to protect the weak and provide spiritual support.";
                    card.SetImage(baseUri, "Assets/Monster/GyakutennoMegami.jpg");
                    card.SetPower(1800, 2000);
                    break;
                case "Curse of Dragon":
                    card.Description = "A wicked dragon that taps into dark forces to execute a powerful attack.";
                    card.SetImage(baseUri, "Assets/Monster/CurseOfDragon.jpg");
                    card.SetPower(2000, 1500);
                    break;
                case "Judge Man":
                    card.Description = "This club-wielding warrior battles to the end and will never surrender.";
                    card.SetImage(baseUri, "Assets/Monster/JudgeMan.jpg");
                    card.SetPower(2200, 1500);
                    break;
                case "Beast of Talwar":
                    card.Description = "Only the master of the sword among the Fiend-Type monsters is permitted to hold the Talwar.";
                    card.SetImage(baseUri, "Assets/Monster/BeastOfTalwar.jpg");
                    card.SetPower(2400, 2150);
                    break;
                case "Dark Magician":
                    card.Description = "The ultimate wizard in terms of attack and defense.";
                    card.SetImage(baseUri, "Assets/Monster/DarkMagician.jpg");
                    card.SetPower(2500, 2100);
                    break;
                case "Wingweaver":
                    card.Description = "A six-winged fairy who prays for peace and hope.";
                    card.SetImage(baseUri, "Assets/Monster/Wingweaver.jpg");
                    card.SetPower(2750, 2400);
                    break;
            }
            return card;
        }
    }

    public static class EffectCardData
    {
        public static EffectCard NewCard(string name)
        {
            Uri baseUri = new Uri("ms-appx:///");
            EffectCard card = new EffectCard();
            card.Name = name;
            return card;
        }
    }

    public static class SpellCardData
    {
        public static SpellCard NewCard(string name)
        {
            Uri baseUri = new Uri("ms-appx:///");
            SpellCard card = new SpellCard();
            card.Name = name;
            switch (name)
            {
                case "Block Attack":
                    card.Description = "Select 1 of your opponent's monsters and shift it to Defense Position.";
                    card.SetImage(baseUri, "Assets/Spell/BlockAttack.jpg");
                    card.ShortDescription = "";
                    card.Category = "Normal";
                    break;
                case "Dian Keto the Cure Master":
                    card.Description = "Increases your Life Points by 1000 points.";
                    card.SetImage(baseUri, "Assets/Spell/DianKetoTheCureMaster.jpg");
                    card.ShortDescription = "";
                    card.Category = "Normal";
                    break;
                case "Pot of Greed":
                    card.Description = "Draw 2 cards from your Deck.";
                    card.SetImage(baseUri, "Assets/Spell/PotOfGreed.jpg");
                    card.ShortDescription = "";
                    card.Category = "Normal";
                    break;
                case "Remove Trap":
                    card.Description = "Destroys 1 face-up Trap Card on the field.";
                    card.SetImage(baseUri, "Assets/Spell/RemoveTrap.jpg");
                    card.ShortDescription = "";
                    card.Category = "Normal";
                    break;
                case "Stop Defense":
                    card.Description = "Select 1 of your opponent's monsters and switch it to Attack Position. If the card is face-down, flip it face-up. If the card has a flip effect, it is activated immediately.";
                    card.SetImage(baseUri, "Assets/Spell/StopDefense.jpg");
                    card.ShortDescription = "";
                    card.Category = "Normal";
                    break;
            }
            return card;
        }
    }

    public static class TrapCardData
    {
        public static TrapCard NewCard(string name)
        {
            Uri baseUri = new Uri("ms-appx:///");
            TrapCard card = new TrapCard();
            card.Name = name;
            switch (name)
            {
                case "Castle Walls":
                    card.Description = "Increase the DEF of 1 face-up monster on the field by 500 points until the end of this turn.";
                    card.SetImage(baseUri, "Assets/Trap/CastleWalls.jpg");
                    card.ShortDescription = "";
                    card.Category = "Normal";
                    break;
                case "Enchanted Javelin":
                    card.Description = "Increase your Life Points by the ATK of 1 attacking monster.";
                    card.SetImage(baseUri, "Assets/Trap/EnchantedJavelin.jpg");
                    card.ShortDescription = "";
                    card.Category = "Normal";
                    break;
                case "Reinforcements":
                    card.Description = "Increase 1 selected monster's ATK by 500 points during the turn this card is activated.";
                    card.SetImage(baseUri, "Assets/Trap/Reinforcements.jpg");
                    card.ShortDescription = "";
                    card.Category = "Normal";
                    break;
                case "Ring of Destruction":
                    card.Description = "Destroy 1 face-up monster and inflict damage to both players equal to its ATK.";
                    card.SetImage(baseUri, "Assets/Trap/RingOfDestruction.jpg");
                    card.ShortDescription = "";
                    card.Category = "Normal";
                    break;
                case "Solemn Wishes":
                    card.Description = "You gain 500 Life Points when you draw a card (or cards).";
                    card.SetImage(baseUri, "Assets/Trap/SolemnWishes.jpg");
                    card.ShortDescription = "Continuous";
                    card.Category = "Continuous";
                    break;
                case "Ultimate Offering":
                    card.Description = "At the cost of 500 Life Points per monster, a player is allowed an extra Normal Summon or Set.";
                    card.SetImage(baseUri, "Assets/Trap/UltimateOffering.jpg");
                    card.ShortDescription = "Continuous";
                    card.Category = "Continuous";
                    break;
            }
            return card;
        }
    }
}

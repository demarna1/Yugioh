using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;

namespace Yugioh
{
    // A collection of generic cards
    public class CardCollection : IEnumerable<Object>
    {
        private ObservableCollection<Card> cardCollection = new ObservableCollection<Card>();

        public IEnumerator<Object> GetEnumerator()
        {
            return cardCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Card card)
        {
            cardCollection.Add(card);
        }

        public void Remove(Card card)
        {
            cardCollection.Remove(card);
        }

        public int Count()
        {
            return cardCollection.Count;
        }

        public Card Get(int index)
        {
            return cardCollection.ElementAt(index);
        }

        public Card Pop()
        {
            if (cardCollection.Count() > 0)
            {
                Card card = cardCollection.ElementAt(0);
                cardCollection.Remove(card);
                return card;
            }
            return null;
        }

        public void Sort()
        {
            cardCollection.BubbleSort();
        }
    }

    public static class ListExtension
    {
        public static void BubbleSort(this IList collection)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    object o1 = collection[j - 1];
                    object o2 = collection[j];
                    if (((IComparable)o1).CompareTo(o2) > 0)
                    {
                        collection.Remove(o1);
                        collection.Insert(j, o1);
                    }
                }
            }
        }
    }
}

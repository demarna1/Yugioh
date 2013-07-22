using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Yugioh
{
    // Wrapper for a collection of generic cards
    public class CardContainer
    {
        private CardCollection collection = new CardCollection();
        public CardCollection Collection
        {
            get
            {
                return this.collection;
            }
        }
    }

    // Definition for a generic card
    public class Card
    {
        public string Name { get; set; }
        public string CardType { get; set; }
        public string Description { get; set; }
        public ImageSource Image { get; set; }
        public void SetImage(Uri baseUri, String path)
        {
            Image = new BitmapImage(new Uri(baseUri, path));
        }
        public string ShortDescription { get; set; }
    }
}

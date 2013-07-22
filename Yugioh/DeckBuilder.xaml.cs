using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Yugioh
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DeckBuilder : Yugioh.Common.LayoutAwarePage
    {
        public const int DECK_LIMIT = 15;

        private App app = Application.Current as App;
        private CardContainer currentCardData;
        private MonsterCardContainer monsterCardData;
        private EffectCardContainer effectCardData;
        private SpellCardContainer spellCardData;
        private TrapCardContainer trapCardData; 
        private bool addMode;

        public DeckBuilder()
        {
            this.InitializeComponent();

            // Initialize card data listings
            monsterCardData = new MonsterCardContainer();
            effectCardData = new EffectCardContainer();
            spellCardData = new SpellCardContainer();
            trapCardData = new TrapCardContainer();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // Transition to default screen
            currentCardData = monsterCardData;
            deckCountText.Text = "Deck: " + app.myDeckCardData.Collection.Count() + "/" + DECK_LIMIT;
            addScreenTransition();
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void onSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Card selectedCard = (Card)cardGridView.SelectedItem;
            if (selectedCard != null)
            {
                magnifiedCard.Source = selectedCard.Image;
                magnifiedCardDescription.Text = selectedCard.Description;
            }
        }

        private void addRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Card selectedCard = (Card)cardGridView.SelectedItem;
            if (selectedCard == null)
            {
                return;
            }
            if (addMode)
            {
                currentCardData.Collection.Remove(selectedCard);
                app.myDeckCardData.Collection.Add(selectedCard);
                if (app.myDeckCardData.Collection.Count() >= DECK_LIMIT)
                {
                    addRemoveButton.IsEnabled = false;
                }
            }
            else
            {
                app.myDeckCardData.Collection.Remove(selectedCard);
                switch (selectedCard.CardType)
                {
                    case "Monster": 
                        monsterCardData.Collection.Add(selectedCard); 
                        monsterCardData.Collection.Sort(); break;
                    case "Effect": 
                        effectCardData.Collection.Add(selectedCard); break;
                    case "Spell":
                        spellCardData.Collection.Add(selectedCard); break;
                    case "Trap": 
                        trapCardData.Collection.Add(selectedCard); break;
                    default: break;
                }
                if (app.myDeckCardData.Collection.Count() == 0)
                {
                    addRemoveButton.IsEnabled = false;
                }
            }

            // Save my deck content to storage
            saveMyDeckToStorage();

            // Update deck count text
            deckCountText.Text = "Deck: " + app.myDeckCardData.Collection.Count() + "/" + DECK_LIMIT;

            // Update view with no current selection on right panel
            cardGridView.ItemsSource = null;
            cardGridView.ItemsSource = currentCardData.Collection;
            resetLockedCard();
        }

        private void myDeckButton_Click(object sender, RoutedEventArgs e)
        {
            cardGridView.ItemsSource = app.myDeckCardData.Collection;
            currentCardData = app.myDeckCardData;
            addRemoveButton.Content = "Remove from Deck";
            addRemoveButton.IsEnabled = app.myDeckCardData.Collection.Count() > 0;
            addMode = false;
            resetLockedCard();
        }

        private void monsterCardButton_Click(object sender, RoutedEventArgs e)
        {
            currentCardData = monsterCardData;
            addScreenTransition();
        }

        private void effectCardButton_Click(object sender, RoutedEventArgs e)
        {
            currentCardData = effectCardData;
            addScreenTransition();
        }  

        private void spellCardButton_Click(object sender, RoutedEventArgs e)
        {
            currentCardData = spellCardData;
            addScreenTransition();
        }

        private void trapCardButton_Click(object sender, RoutedEventArgs e)
        {
            currentCardData = trapCardData;
            addScreenTransition();
        }

        private void addScreenTransition()
        {
            cardGridView.ItemsSource = currentCardData.Collection;
            addRemoveButton.Content = "Add to Deck";
            addRemoveButton.IsEnabled = app.myDeckCardData.Collection.Count() < DECK_LIMIT;
            addMode = true;
            resetLockedCard();
        }

        private void resetLockedCard()
        {
            Uri baseUri = new Uri("ms-appx:///");
            magnifiedCard.Source = new BitmapImage(new Uri(baseUri, "Assets/YugiohCard.png"));
            magnifiedCardDescription.Text = "No Card Selected.";
        }

        private void saveMyDeckToStorage()
        {
            Windows.Storage.ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            Windows.Storage.ApplicationDataCompositeValue composite = new Windows.Storage.ApplicationDataCompositeValue();
            int deckCount = app.myDeckCardData.Collection.Count();
            composite["deckCount"] = deckCount;
            for (int i = 0; i < deckCount; i++)
            {
                composite["myCard" + i] = app.myDeckCardData.Collection.Get(i).Name;
            }
            roamingSettings.Values["myDeck"] = composite;
        }
    }
}

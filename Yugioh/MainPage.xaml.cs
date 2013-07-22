﻿using System;
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
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Yugioh
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Yugioh.Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
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
            // Restore values stored in session state
            if (pageState != null && pageState.ContainsKey("greetingOutputText"))
            {
                greetingOutput.Text = pageState["greetingOutputText"].ToString();
            }
            
            // Restore user name
            Windows.Storage.ApplicationDataContainer roamingSettings = 
                Windows.Storage.ApplicationData.Current.RoamingSettings;
            if (roamingSettings.Values.ContainsKey("userName"))
            {
                nameInput.Text = roamingSettings.Values["userName"].ToString();
            }
            
            // Restore My Deck
            (Application.Current as App).myDeckCardData = new CardContainer();
            if (roamingSettings.Values.ContainsKey("myDeck"))
            {
                Windows.Storage.ApplicationDataCompositeValue composite = (Windows.Storage.ApplicationDataCompositeValue)roamingSettings.Values["myDeck"];
                if (composite != null)
                {
                    int deckCount = (int)composite["deckCount"];
                    for (int i = 0; i < deckCount; i++)
                    {
                        string name = (string)composite["myCard" + i];
                        Card card = CardData.CreateCardFromName(name);
                        (Application.Current as App).myDeckCardData.Collection.Add(card);
                    }
                }
            }

            // Adjust deck count text
            deckCountText.Text = "Deck Count: " + (Application.Current as App).myDeckCardData.Collection.Count() + "/" + DeckBuilder.DECK_LIMIT;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            pageState["greetingOutputText"] = greetingOutput.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            greetingOutput.Text = "Hello, " + nameInput.Text + "!";
        }

        private void NameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer roamingSettings = 
                Windows.Storage.ApplicationData.Current.RoamingSettings;
            roamingSettings.Values["userName"] = nameInput.Text;
        }

        private void BuildDeckButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(DeckBuilder));
            }
        }

        private void startDuelButton_Click(object sender, RoutedEventArgs e)
        {
            // Need at least 15 cards to duel
            if ((Application.Current as App).myDeckCardData.Collection.Count() >= 15)
            {
                // Navigate to duel page
                if (this.Frame != null)
                {
                    this.Frame.Navigate(typeof(Duel));
                }
            }
        }
    }
}

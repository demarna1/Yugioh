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

namespace Yugioh
{
    public enum Phase
    {
        DrawPhase,
        StandbyPhase,
        MainPhase1,
        BattlePhase,
        MainPhase2,
        EndPhase
    }

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Duel : Yugioh.Common.LayoutAwarePage
    {
        // Constuct two new players
        Player me = new Player();
        Player enemy = new Player();

        // Phase and turn state variables
        Phase turnPhase = Phase.DrawPhase;
        bool myTurn = true;

        // Temporary UI elements
        Button startResumeButton;
        Card currentSelectedHandCard;

        public Duel()
        {
            this.InitializeComponent();
        }

        #region Events

        void startResumeButton_Click(object sender, RoutedEventArgs e)
        {
            // Remove start button and restore opacity
            statusGrid.Children.Remove(startResumeButton);
            statusGridTop.Opacity = 1.0;

            // Shuffle both decks

            // Add first 5 cards to hand from deck for both players
            for (int i = 0; i < 5; i++)
            {
                me.Hand.Add(me.Deck.Pop());
                enemy.Hand.Add(enemy.Deck.Pop());
            }

            // Add decks to battlefield grid
            Add3DCards((int)(me.Deck.Count() / 2), false);
            Add3DCards((int)(enemy.Deck.Count() / 2), true);

            // Display my hand and enemy's hand
            myHandListView.ItemsSource = me.Hand;
            DisplayEnemyHand();
        }

        private void battlefield_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            battlefieldBackground.Clip.Rect = new Rect(0, 0, battlefieldBackground.ActualWidth, battlefieldBackground.ActualHeight);
            double margin = battlefieldBackground.ActualHeight - 668 + 95;
            battlefieldGrid.Margin = new Thickness(margin, 25, margin, 45);
            enemyHandCanvas.Width = battlefieldBackground.ActualWidth - 54;
        }

        private void myMonsterSlot_Drop(object sender, DragEventArgs e)
        {
            if (currentSelectedHandCard != null)
            {
                Image monsterSlot = (Image)sender;
                monsterSlot.Source = currentSelectedHandCard.Image;
            }
            me.Hand.Remove(currentSelectedHandCard);
            myHandListView.ItemsSource = null;
            myHandListView.ItemsSource = me.Hand;
        }
        
        private void myHandListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentSelectedHandCard = (Card)myHandListView.SelectedItem;
        }

        #endregion

        #region Support Methods

        private void AddTemporaryStartButton()
        {
            startResumeButton = new Button();
            startResumeButton.Content = "Start Game";
            startResumeButton.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
            startResumeButton.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;
            startResumeButton.Margin = new Thickness(130, 100, 130, 100);
            startResumeButton.Click += startResumeButton_Click;
            statusGrid.Children.Add(startResumeButton);
            statusGridTop.Opacity = 0;
        }     

        private void DisplayEnemyHand()
        {
            double centerX = enemyHandCanvas.ActualWidth / 2;

            for (int i = 0; i < enemy.Hand.Count(); i++)
            {
                Image cardImage = CreateNewBlankCardImage();
                cardImage.Height = enemyHandCanvas.ActualHeight;
                cardImage.SetValue(Canvas.LeftProperty, centerX);
                PlaneProjection projection = new PlaneProjection();
                projection.GlobalOffsetX = 65 * (i + 0.5 - (enemy.Hand.Count() / 2.0));
                cardImage.Projection = projection;
                enemyHandCanvas.Children.Add(cardImage);
            }
        }

        private void Add3DCards(int num, bool isEnemy)
        {
            for (int i = 0; i < num; i++)
            {
                Image extraCardImage = CreateNewBlankCardImage();
                extraCardImage.Margin = new Thickness(0, 10, 0, 10);
                PlaneProjection projection = new PlaneProjection();
                projection.GlobalOffsetZ = 8 * i;
                projection.GlobalOffsetY = -3 * i;
                if (isEnemy)
                {
                    projection.GlobalOffsetX = -1 * i;
                    projection.RotationZ = 180;
                    extraCardImage.Projection = projection;
                    enemyFieldGrid.Children.Add(extraCardImage);
                }
                else
                {
                    projection.GlobalOffsetX = 1 * i;
                    extraCardImage.Projection = projection;
                    extraCardImage.SetValue(Grid.ColumnProperty, 5);
                    extraCardImage.SetValue(Grid.RowProperty, 1);
                    myFieldGrid.Children.Add(extraCardImage);
                }
            }
        }

        private Image CreateNewBlankCardImage()
        {
            Uri baseUri = new Uri("ms-appx:///");
            BitmapImage binImage = new BitmapImage(new Uri(baseUri, "Assets/YugiohCard.png"));
            Image cardImage = new Image();
            cardImage.Source = binImage;
            return cardImage;
        }

        #endregion

        #region Persistance

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
            AddTemporaryStartButton();
            // Initialize player decks for the start of the duel
            me.Deck = (Application.Current as App).myDeckCardData.Collection;
            enemy.Deck = EnemyDecks.CreateEnemyCollection();
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

        #endregion
    }
}

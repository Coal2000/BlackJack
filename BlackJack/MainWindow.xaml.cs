using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void NextDelegate();

        private short playerScore, dealerScore;
        private int bet, money, round;
        Deck mainDeck;

        public MainWindow()
        {
            InitializeComponent();
            round = 1;
            RoundCount.Text = round.ToString();
            money = 99;
            MoneyAmount.Text = money.ToString();
            TurnPerson.Text = "Player's";
            bet = 1;
            BetAmount.Text = bet.ToString();
            mainDeck = new Deck();
        }

        private void standClick(object sender, RoutedEventArgs e)
        {
            hitButton.FontSize = 10;
            if(playerScore > dealerScore)
            {
                Notifications.Text = "You Win!";
                money += 2 * bet;
                MoneyAmount.Text = money.ToString();

            }
            else if(playerScore < dealerScore)
            {
                Notifications.Text = "You Lose";
            }
            else
            {
                Notifications.Text = "Tied Round";
                money += bet;
                MoneyAmount.Text = money.ToString();
            }
            roundSetup();
        }

        private void hitClick(object sender, RoutedEventArgs e)
        {
            this.Title = "Clicked";
        }

        public void roundSetup()
        {
            round++;
            RoundCount.Text = round.ToString();
            money -= bet;
            Card one = mainDeck.PickACard();
            System.Diagnostics.Debug.WriteLine(one.image);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/cards/" + one.image);
            image.EndInit();
            
            dealerCardImage1.Source = image;
            dealerCardImage4.Source = image;
        }
    }
}

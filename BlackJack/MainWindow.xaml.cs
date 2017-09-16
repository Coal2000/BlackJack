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
        private int bet, money;

        public MainWindow()
        {
            InitializeComponent();
            RoundCount.Text = "1";
            money = 100;
            MoneyAmount.Text = "100";
            TurnPerson.Text = "Player's";
            bet = 1;
            BetAmount.Text = "1";
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

        }
    }
}

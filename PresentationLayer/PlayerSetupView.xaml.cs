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
using System.Windows.Shapes;
using TBQuestGame.Models;

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;
        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();

            SetUpWindow();
        }

        private void SetUpWindow()
        {
            NameTextBox.Focus();
            ErrorMessageTextBlock.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Validates the player setup view text boxes
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (NameTextBox.Text == "")
            {
                errorMessage += "A player name is required.\n";
            }
            else
            {
                _player.Name = NameTextBox.Text;
            }
            if (!int.TryParse(AgeTextBox.Text, out int age))
            {
                errorMessage += "Player age is required and must be an integer. \n";
            }
            else
            {
                _player.Age = age;
            }

            return errorMessage == "" ? true : false;
        }
        /// <summary>
        /// Event handler method for the ok button in PlayerSetupView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if(IsValidInput(out errorMessage))
            {
                Visibility = Visibility.Hidden;
            }
            else
            {
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
        }
        /// <summary>
        /// Event handler to quit the application at the PlayerSetupView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerSetupQuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

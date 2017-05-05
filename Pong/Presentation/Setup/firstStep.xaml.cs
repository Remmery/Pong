using System;
using System.Windows;
using System.Windows.Controls;

namespace Pong.Presentation.Setup {
    /// <summary>
    /// Interaction logic for firstStep.xaml
    /// </summary>
    public partial class firstStep : UserControl
    {
        private Data.Setup setup;
        private int numberOfPlayers;
        private int maxPlayers;
        private int minPlayers;

        public firstStep(Data.Setup setup)
        {
            InitializeComponent();
            this.setup = setup;
            Initialize();
            
        }

        /// <summary>
        /// Initialize the userControl: set some events for placeholders, set some variables and 
        /// show textboxes based on number of players selected.
        /// </summary>
        public void Initialize()
        {
            // Set some events
            textBoxFirstName.GotFocus += new RoutedEventHandler(RemovePlaceholderFromTextbox);
            textBoxFirstName.LostFocus += new RoutedEventHandler(AddPlaceholderToTextbox);
            textBoxSecondName.GotFocus += new RoutedEventHandler(RemovePlaceholderFromTextbox);
            textBoxSecondName.LostFocus += new RoutedEventHandler(AddPlaceholderToTextbox);
            textBoxThirdName.GotFocus += new RoutedEventHandler(RemovePlaceholderFromTextbox);
            textBoxThirdName.LostFocus += new RoutedEventHandler(AddPlaceholderToTextbox);
            textBoxFourthName.GotFocus += new RoutedEventHandler(RemovePlaceholderFromTextbox);
            textBoxFourthName.LostFocus += new RoutedEventHandler(AddPlaceholderToTextbox);

            // Set some variables
            this.numberOfPlayers = 2;
            this.maxPlayers = 4;
            this.minPlayers = 2;
            textBoxNumberOfPlayers.Text = numberOfPlayers.ToString();

            // Show textboxes based on numberOfPlayers
            showTextboxPlayerNames();
        }

        /// <summary>
        /// Gets or sets the number of players.
        /// </summary>
        public int NumberOfPlayers
        {
            get { return numberOfPlayers; }
            set
            {
                numberOfPlayers = value;
                textBoxNumberOfPlayers.Text = value.ToString();
                showTextboxPlayerNames();
            }
        }

        /// <summary>
        /// Onclick event: Increase the number of players by one if its lower than the maximum players
        /// </summary>
        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            if (this.numberOfPlayers < this.maxPlayers)
            {
                NumberOfPlayers++;
            }           
        }

        /// <summary>
        /// Onclick event: Reduce the number of players by one if its higher than the minimum players
        /// </summary>
        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            if (this.numberOfPlayers > this.minPlayers)
            {
                NumberOfPlayers--;
            }
        }

        /// <summary>
        /// Executed when number of players in the textbox is changed manual.
        /// Try to parse given number, check if number is in range from minPlayers - maxPlayers
        /// and set number of players.
        /// </summary>
        private void textBoxNumberOfPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {
            int x = 2;
            if (textBoxNumberOfPlayers == null)
            {
                return;
            }

            if (!int.TryParse(textBoxNumberOfPlayers.Text, out x))
            {             
                textBoxNumberOfPlayers.Text = this.numberOfPlayers.ToString();
            }

            // Check user input and adjust to min or max values
            if (x > this.maxPlayers)
            {
                x = this.maxPlayers;
            }
            else if (x < this.minPlayers)
            {
                x = this.minPlayers;
            }

            // Set numberOfPlayers and adjust player name input boxes
            this.NumberOfPlayers = x;
            showTextboxPlayerNames();
        }

        /// <summary>
        /// Shows number of textboxes based on the number of players.
        /// Example: 2 number of players selected = 2 textboxes visible for their names
        /// </summary>
        public void showTextboxPlayerNames()
        {
            // Hide 3th and 4th player
            if (this.numberOfPlayers == 2)
            {
                // Show
                textBoxFirstName.Visibility = Visibility.Visible;
                labelNameFirst.Visibility = Visibility.Visible;
                textBoxSecondName.Visibility = Visibility.Visible;
                labelNameSecond.Visibility = Visibility.Visible;
                // Hidden
                textBoxThirdName.Visibility = Visibility.Hidden;
                labelNameThird.Visibility = Visibility.Hidden;
                textBoxFourthName.Visibility = Visibility.Hidden;
                labelNameFourth.Visibility = Visibility.Hidden;
            }
            else if (this.numberOfPlayers == 3)
            {
                // Show
                textBoxFirstName.Visibility = Visibility.Visible;
                labelNameFirst.Visibility = Visibility.Visible;
                textBoxSecondName.Visibility = Visibility.Visible;
                labelNameSecond.Visibility = Visibility.Visible;
                textBoxThirdName.Visibility = Visibility.Visible;
                labelNameThird.Visibility = Visibility.Visible;
                // Hidden
                textBoxFourthName.Visibility = Visibility.Hidden;
                labelNameFourth.Visibility = Visibility.Hidden;
            }
            else if (this.numberOfPlayers == 4)
            {
                // Show
                textBoxFirstName.Visibility = Visibility.Visible;
                labelNameFirst.Visibility = Visibility.Visible;
                textBoxSecondName.Visibility = Visibility.Visible;
                labelNameSecond.Visibility = Visibility.Visible;
                textBoxThirdName.Visibility = Visibility.Visible;
                labelNameThird.Visibility = Visibility.Visible;
                textBoxFourthName.Visibility = Visibility.Visible;
                labelNameFourth.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Checks the UserControl, based on number of players, to validate that everything is filled in correctly.
        /// </summary>
        /// <returns>True if everything is filled in correctly, false if not filled in correctly</returns>
        public bool checkUserControl()
        {
            if (this.numberOfPlayers == 2)
            {
                if (textBoxFirstName.Text.Trim().Equals("") || textBoxSecondName.Text.Trim().Equals("")
                    || textBoxFirstName.Text.Trim().Equals("Please fill in your name") || textBoxSecondName.Text.Trim().Equals("Please fill in your name"))
                {
                    return false;
                }
                return true;
            }
            else if (this.numberOfPlayers == 3)
            {
                if (textBoxFirstName.Text.Trim().Equals("") || textBoxSecondName.Text.Trim().Equals("") || textBoxThirdName.Text.Trim().Equals("")
                    || textBoxFirstName.Text.Trim().Equals("Please fill in your name") || textBoxSecondName.Text.Trim().Equals("Please fill in your name") || textBoxThirdName.Text.Trim().Equals("Please fill in your name"))
                {
                    return false;
                }
                return true;
            }
            else if (this.numberOfPlayers == 4)
            {
                if (textBoxFirstName.Text.Trim().Equals("") || textBoxSecondName.Text.Trim().Equals("") || textBoxThirdName.Text.Trim().Equals("") || textBoxFourthName.Text.Trim().Equals("")
                    || textBoxFirstName.Text.Trim().Equals("Please fill in your name") || textBoxSecondName.Text.Trim().Equals("Please fill in your name") || textBoxThirdName.Text.Trim().Equals("Please fill in your name") || textBoxFourthName.Text.Trim().Equals("Please fill in your name"))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Onclick event: Executed when clicked on the button "Continue".
        /// Checks if user control is filled in correctly:
        /// If so, store user input and continue to the next
        /// If not, show a message that it was not filled in correctly.
        /// </summary>
        private void buttonContinue_Click(object sender, RoutedEventArgs e)
        {
            bool check = checkUserControl();

            if (!check)
            {
                MessageBox.Show("Please fill in the required fields.");
            } else
            {
                setup.NumberOfPlayers = numberOfPlayers;
                switch (this.numberOfPlayers)
                {
                    case 2:
                        setup.PlayerNames.Add(textBoxFirstName.Text);
                        setup.PlayerNames.Add(textBoxSecondName.Text);
                        break;
                    case 3:
                        setup.PlayerNames.Add(textBoxFirstName.Text);
                        setup.PlayerNames.Add(textBoxSecondName.Text);
                        setup.PlayerNames.Add(textBoxThirdName.Text);
                        break;
                    case 4:
                        setup.PlayerNames.Add(textBoxFirstName.Text);
                        setup.PlayerNames.Add(textBoxSecondName.Text);
                        setup.PlayerNames.Add(textBoxThirdName.Text);
                        setup.PlayerNames.Add(textBoxFourthName.Text);
                        break;
                    default:
                        break;
                }
                Window.GetWindow(this).Close();
            }       
        }

        /// <summary>
        /// Removes a placeholder from the textbox.
        /// </summary>
        public void RemovePlaceholderFromTextbox(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        /// <summary>
        /// Adds a placeholder to the textbox.
        /// </summary>
        public void AddPlaceholderToTextbox(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Text.Equals(""))
                box.Text = "Please fill in your name";
        }

        /// <summary>
        /// Executed when clicked on "Cancel":
        /// Closes everything and closes the setup.
        /// </summary>
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

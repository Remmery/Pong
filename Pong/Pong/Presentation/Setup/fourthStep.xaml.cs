using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Pong.Logic.Powerups;

namespace Pong.Presentation.Setup {
    /// <summary>
    /// Interaction logic for fourthStep.xaml
    /// </summary>
    public partial class fourthStep : UserControl {
        private Data.Setup setup;
        public fourthStep(Data.Setup setup) {
            InitializeComponent();
            this.setup = setup;
        }

        /// <summary>
        /// Check which powerups are selected by the user and add them to a list.
        /// </summary>
        /// <returns>Returns a list from selected powerups</returns>
        private List<PowerUp> checkPowerupCheckboxes() {
            List<PowerUp> list = new List<PowerUp>();

            if (checkBoxBombPowerup.IsChecked == true) {
                list.Add(new BombPowerUp(0, 0, 40, 1));
            }

            if (checkBoxHealthPowerUp.IsChecked == true) {
                list.Add(new HealthPowerUp(0, 0, 40, 1));
            }

            if (checkBoxMultiballPowerup.IsChecked == true) {
                list.Add(new MultiBallPowerUp(0, 0, 40));
            }

            if (checkBoxReversePowerup.IsChecked == true) {
                list.Add(new ReversePowerUp(0, 0, 40, 0));
            }

            if (checkBoxSpeedPowerup.IsChecked == true) {
                list.Add(new SpeedPowerUp(0, 0, 40, 10));
            }

            return list;
        }

        #region "Checkboxes + Buttons"
        /// <summary>
        /// Executed when clicked on "Play the game":
        /// Close everything and store user input to setup.
        /// </summary>
        private void buttonPlay_Click(object sender, RoutedEventArgs e) {
            setup.TimeLimit = (int)integerUpDownTimeLimit.Value;
            setup.MaxScore = (int)IntegerUpDownMaxScore.Value;
            setup.StartHealth = (int)IntegerUpDownStartHealth.Value;
            setup.MaxHealth = (int)IntegerUpDownMaxHealth.Value;
            setup.MinHealth = (int)IntegerUpDownMinHealth.Value;
            setup.StartVelocity = (int)IntegerUpDownStartVelocity.Value;
            setup.MaxVelocity = (int)IntegerUpDownMaxVelocity.Value;
            setup.Acceleration = (int)IntegerUpDownAcceleration.Value;
            setup.Powerups = checkPowerupCheckboxes();
            setup.AppearanceChancePercent = (int)IntegerUpDownChance.Value;
            setup.DamageBomb = (int)IntegerUpDownDamageBomb.Value;
            setup.HealingShield = (int)IntegerUpDownHealingShield.Value;
            setup.SpeedBallPercent = (int)IntegerUpDownSpeedball.Value;
            setup.ReverseTime = (int)IntegerUpDownReverseTime.Value;

            Window.GetWindow(this).Close();
        }

        /// <summary>
        /// Executed when clicked on "Cancel":
        /// Closes everything and closes the setup.
        /// </summary>
        private void buttonCancel_Click(object sender, RoutedEventArgs e) {
            Environment.Exit(0);
        }

        /// <summary>
        /// Executed when checkbox Bom powerup was (un)checked:
        /// Check check-state and adjust opacity from the image.
        /// Low opacity for disabled power-ups and full opacity for enabled ones.
        /// </summary>
        private void checkBoxBombPowerup_Checked(object sender, RoutedEventArgs e) {
            if (imageBomb != null) {
                if (checkBoxBombPowerup.IsChecked == true) {
                    imageBomb.Opacity = 1;
                    IntegerUpDownDamageBomb.IsEnabled = true;
                    IntegerUpDownChance.IsEnabled = true;
                }
                else {
                    imageBomb.Opacity = 0.20;
                    IntegerUpDownDamageBomb.IsEnabled = false;
                    if (AllPowerUpsUnchecked()) {
                        IntegerUpDownChance.IsEnabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Executed when checkbox Health powerup was (un)checked:
        /// Check check-state and adjust opacity from the image.
        /// Low opacity for disabled power-ups and full opacity for enabled ones.
        /// </summary>
        private void checkBoxHealthPowerUp_Checked(object sender, RoutedEventArgs e) {
            if (imageHealth != null) {
                if (checkBoxHealthPowerUp.IsChecked == true) {
                    imageHealth.Opacity = 1;
                    IntegerUpDownHealingShield.IsEnabled = true;
                    IntegerUpDownChance.IsEnabled = true;
                }
                else {
                    imageHealth.Opacity = 0.20;
                    IntegerUpDownHealingShield.IsEnabled = false;
                    if (AllPowerUpsUnchecked()) {
                        IntegerUpDownChance.IsEnabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Executed when checkbox Multiball powerup was (un)checked:
        /// Check check-state and adjust opacity from the image.
        /// Low opacity for disabled power-ups and full opacity for enabled ones.
        /// </summary>
        private void checkBoxMultiballPowerup_Checked(object sender, RoutedEventArgs e) {
            if (imageMultiball != null) {
                if (checkBoxMultiballPowerup.IsChecked == true) {
                    imageMultiball.Opacity = 1;
                    IntegerUpDownChance.IsEnabled = true;
                }
                else {
                    imageMultiball.Opacity = 0.20;
                    if (AllPowerUpsUnchecked()) {
                        IntegerUpDownChance.IsEnabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Executed when checkbox Reverse powerup was (un)checked:
        /// Check check-state and adjust opacity from the image.
        /// Low opacity for disabled power-ups and full opacity for enabled ones.
        /// </summary>
        private void checkBoxReversePowerup_Checked(object sender, RoutedEventArgs e) {
            if (imageReverse != null) {
                if (checkBoxReversePowerup.IsChecked == true) {
                    imageReverse.Opacity = 1;
                    IntegerUpDownReverseTime.IsEnabled = true;
                    IntegerUpDownChance.IsEnabled = true;
                }
                else {
                    imageReverse.Opacity = 0.20;
                    IntegerUpDownReverseTime.IsEnabled = false;
                    if (AllPowerUpsUnchecked()) {
                        IntegerUpDownChance.IsEnabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Executed when checkbox Speed powerup was (un)checked:
        /// Check check-state and adjust opacity from the image.
        /// Low opacity for disabled power-ups and full opacity for enabled ones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxSpeedPowerup_Checked(object sender, RoutedEventArgs e) {
            if (imageSpeedball != null) {
                if (checkBoxSpeedPowerup.IsChecked == true) {
                    imageSpeedball.Opacity = 1;
                    IntegerUpDownSpeedball.IsEnabled = true;
                    IntegerUpDownChance.IsEnabled = true;
                }
                else {
                    imageSpeedball.Opacity = 0.20;
                    IntegerUpDownSpeedball.IsEnabled = false;
                    if (AllPowerUpsUnchecked()) {
                        IntegerUpDownChance.IsEnabled = false;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Checks if all powerups are unchecked.
        /// </summary>
        /// <returns>True if no powerup was checked, false if not</returns>
        private bool AllPowerUpsUnchecked() {
            if (checkBoxBombPowerup.IsChecked == false && checkBoxHealthPowerUp.IsChecked == false && checkBoxMultiballPowerup.IsChecked == false && checkBoxReversePowerup.IsChecked == false && checkBoxSpeedPowerup.IsChecked == false) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
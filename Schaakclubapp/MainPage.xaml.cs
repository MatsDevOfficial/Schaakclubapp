using System;
using System.Windows;

namespace Schaakclubapp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Simpele loginfunctie
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "admin" && PasswordBox.Password == "admin")
            {
                MessageBox.Show("Inloggen geslaagd!");
                // Hier zou je de navigatie naar de admin interface kunnen doen
            }
            else
            {
                MessageBox.Show("Ongeldige gebruikersnaam of wachtwoord.");
            }
        }

        // Open het RSVP formulier
        private void RSVPButton_Click(object sender, RoutedEventArgs e)
        {
            RSVPForm rsvpForm = new RSVPForm();
            rsvpForm.ShowDialog();
        }
    }
}

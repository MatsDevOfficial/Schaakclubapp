using System.Windows;

namespace Schaakclubapp
{
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (username == "admin" && password == "admin123") // Gebruik een eenvoudige hardcoded login voor nu.
            {
                MainPage mainPage = new MainPage();
                AdminPage adminPage = new AdminPage(mainPage);
                adminPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ongeldige gebruikersnaam of wachtwoord.");
            }
        }
    }
}

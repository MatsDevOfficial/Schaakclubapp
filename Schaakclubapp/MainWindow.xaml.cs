using System.Windows;

namespace ChessClubApp
{
    public partial class MainWindow : Window
    {
        private const string AdminUsername = "beheerder";
        private const string AdminPassword = "schaak123";

        public MainWindow()
        {
            InitializeComponent();
            CheckForUpdates();
        }

        private async void CheckForUpdates()
        {
            if (await UpdateChecker.IsUpdateAvailable("1.0.0"))
            {
                if (MessageBox.Show("Er is een update beschikbaar. Wil je deze installeren?", "Update Beschikbaar",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    await UpdateChecker.DownloadAndInstallUpdate();
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == AdminUsername && PasswordBox.Password == AdminPassword)
            {
                var adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ongeldige gebruikersnaam of wachtwoord.");
            }
        }
    }
}

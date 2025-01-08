using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.IO.Compression;

namespace Schaakclubapp
{
    public partial class UpdateCheck : Window
    {
        // GitHub Release URL voor het zipbestand
        private static readonly string GitHubReleaseUrl = "https://github.com/MatsDevOfficial/Schaakclubapp/releases/latest/download/release.zip";
        private static readonly string UpdateZipPath = "update.zip"; // Pad voor de gedownloade update

        public UpdateCheck()
        {
            InitializeComponent();
            CheckForUpdatesAsync();
        }

        private async void CheckForUpdatesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "SchaakclubApp");
                    string response = await client.GetStringAsync(GitHubReleaseUrl);

                    // Start het downloadproces voor de update
                    StatusText.Text = "Nieuwe versie gedetecteerd. Downloaden...";

                    await DownloadAndUpdateAsync();

                    StatusText.Text = "Update voltooid! De app wordt opnieuw gestart.";
                    MessageBox.Show("De app is succesvol bijgewerkt!");
                    RestartApp(); // Start de app opnieuw na de update
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het controleren van updates: {ex.Message}");
            }
        }

        private async Task DownloadAndUpdateAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Download het zipbestand van de release
                    var response = await client.GetByteArrayAsync(GitHubReleaseUrl);

                    // Schrijf het zipbestand naar de schijf
                    await File.WriteAllBytesAsync(UpdateZipPath, response);

                    // Pak het zipbestand uit naar de huidige map
                    ZipFile.ExtractToDirectory(UpdateZipPath, AppDomain.CurrentDomain.BaseDirectory);

                    // Verwijder het zipbestand na het uitpakken
                    File.Delete(UpdateZipPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het downloaden of uitpakken van de update: {ex.Message}");
            }
        }

        private void RestartApp()
        {
            // Start de nieuwe versie van de app (de huidige exe-bestand in dezelfde map)
            string appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schaakclubapp.exe");
            System.Diagnostics.Process.Start(appPath);
            Application.Current.Shutdown(); // Sluit de oude versie af
        }
    }
}

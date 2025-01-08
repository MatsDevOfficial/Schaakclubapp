using System.Collections.Generic;
using System.Windows;

namespace Schaakclubapp
{
    public partial class AdminPage : Window
    {
        private MainPage mainPage;

        public AdminPage(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage;
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            string eventName = EventNameTextBox.Text;
            string eventDate = EventDateTextBox.Text;

            if (!string.IsNullOrEmpty(eventName) && !string.IsNullOrEmpty(eventDate))
            {
                string eventDetails = $"{eventName} - {eventDate}";
                mainPage.UpdateEventList(new List<string> { eventDetails });
                MessageBox.Show("Evenement toegevoegd!");
            }
            else
            {
                MessageBox.Show("Vul alle velden in.");
            }
        }
    }
}

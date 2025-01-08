using System.Windows;

namespace Schaakclubapp
{
    public partial class RSVPForm : Window
    {
        public RSVPForm()
        {
            InitializeComponent();
        }

        // Verzend het RSVP formulier
        private void SubmitRSVP_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vul je naam in om deel te nemen.");
            }
            else
            {
                MessageBox.Show($"Bedankt voor je RSVP, {name}!");
                this.Close();
            }
        }
    }
}

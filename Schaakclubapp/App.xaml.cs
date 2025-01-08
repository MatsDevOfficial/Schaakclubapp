using System;
using System.Windows;

namespace Schaakclubapp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Start de updatecontrole bij het opstarten van de applicatie
            UpdateCheck updateCheck = new UpdateCheck();
            updateCheck.ShowDialog(); // Toont het updatecontrole venster
        }
    }
}

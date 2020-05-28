using System.Windows;
using System.Windows.Controls;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Page
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void LogIn_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIn());
        }

        private void EnviarEmail_Clicked(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new LogIn());
        }
    }
}

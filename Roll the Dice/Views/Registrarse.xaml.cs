using System.Windows;
using System.Windows.Controls;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para Registrarse.xaml
    /// </summary>
    public partial class Registrarse : Page
    {
        public Registrarse()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIn());
        }

        private void Registrarse_Clicked(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new MenuPlayer());
        }

        private void VisibleErrorValidate_Click(object sender, RoutedEventArgs e)
        {
            borderValidatePass.Visibility = Visibility.Visible;
            textValidatePass.Visibility = Visibility.Visible;
        }

    }
}

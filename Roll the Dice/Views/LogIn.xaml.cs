using System;
using System.Windows;
using System.Windows.Controls;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateJoin());
        }

        private void Registrarse_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registrarse());
        }

        private void Contraseña_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ForgotPassword());
        }
    }
}

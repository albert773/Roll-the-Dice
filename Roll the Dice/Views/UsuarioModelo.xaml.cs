using System;
using System.Windows;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para UsuarioModelo.xaml
    /// </summary>
    public partial class UsuarioModelo : Window
    {
        public UsuarioModelo()
        {
            InitializeComponent();
        }

        public void ButtonPopUpLogOut_Click(Object sender, RoutedEventArgs e)
        {
            // No deberia cerrarse pero ya me entendeis
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu(Object sender, RoutedEventArgs e)
        {
            ButtonOpenBarMenu.Visibility = Visibility.Collapsed;
            ButtonCloseBarMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu(Object sender, RoutedEventArgs e)
        {
            ButtonOpenBarMenu.Visibility = Visibility.Visible;
            ButtonCloseBarMenu.Visibility = Visibility.Collapsed;
        }
    }
}

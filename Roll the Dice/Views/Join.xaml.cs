using System;
using System.Windows;
using System.Windows.Controls;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para Join.xaml
    /// </summary>
    public partial class Join : Page
    {
        MenuPlayer menu = null;
        public Join()
        {
            InitializeComponent();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateJoin());
        }

        private void Unirse_Click(object sender, RoutedEventArgs e)
        {
            //Cambio de pagina a Ventana
            menu = new MenuPlayer();
            menu.Show();
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.Close();
        }
    }
}

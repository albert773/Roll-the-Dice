using System.Windows;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para GMviewPlayer.xaml
    /// </summary>
    public partial class GMviewPlayer : Window
    {
         
        public GMviewPlayer()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu(object sender, RoutedEventArgs e)
        {
            ButtonOpenBarMenu.Visibility = Visibility.Visible;
            ButtonCloseBarMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu(object sender, RoutedEventArgs e)
        {
            ButtonCloseBarMenu.Visibility = Visibility.Visible;
            ButtonOpenBarMenu.Visibility = Visibility.Collapsed;
        }
    }
}

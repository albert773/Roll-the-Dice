using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para CreateJoin.xaml
    /// </summary>
    public partial class CreateJoin : Page
    {
        public CreateJoin()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIn());
        }

        private void Join_Clicked(object sender, RoutedEventArgs e)
        {
            //borderCreate.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a39cca"));
            NavigationService.Navigate(new Join());
        }

        private void Create_Clicked(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new MenuGM());
        }
    }
}

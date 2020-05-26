using System.Windows;
using System.Windows.Controls;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para Join.xaml
    /// </summary>
    public partial class Join : Page
    {
        public Join()
        {
            InitializeComponent();
        }

        private void CreateJoin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPlayer());
        }

        private void Unirse_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateJoin());
        }
    }
}

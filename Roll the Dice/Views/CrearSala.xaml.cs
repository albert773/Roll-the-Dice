using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para CrearSala.xaml
    /// </summary>
    public partial class CrearSala : Page
    {
        public CrearSala()
        {
            InitializeComponent();
        }

        private void Volver_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new CreateJoin());
        }

        private void Unirse_Click(object sender, RoutedEventArgs e)
        {
            MenuGM gm = new MenuGM();
            gm.Show();
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.Close();
        }
    }
}

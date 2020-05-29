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
    /// Lógica de interacción para CreacionDeCosas.xaml
    /// </summary>
    public partial class CreacionDeCosas : Window
    {
        public CreacionDeCosas()
        {
            InitializeComponent();
            creationFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void arma_Checked(object sender, RoutedEventArgs e)
        {
            creationFrame.Content = new CreacionArma();
        }

        private void armadura_Checked(object sender, RoutedEventArgs e)
        {
            creationFrame.Content = new CreacionArmaduras();
        }

        private void npc_Checked(object sender, RoutedEventArgs e)
        {
            creationFrame.Content = new CreacionNPC();
        }

        private void monstruo_Checked(object sender, RoutedEventArgs e)
        {
            creationFrame.Content = new CreacionMonstruo();
        }
    }
}

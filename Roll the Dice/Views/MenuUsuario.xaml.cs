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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para MenuUsuario.xaml
    /// </summary>
    public partial class MenuUsuario : Window
    {

        bool MenuClosed = false;
        public MenuUsuario()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            if (MenuClosed)
            {
                Storyboard openMenu = (Storyboard)button.FindResource("MenuOpen");
                openMenu.Begin();
            }
            else {
                Storyboard closeMenu = (Storyboard)button.FindResource("MenuClose");
                closeMenu.Begin();
            }
        }
    }
}

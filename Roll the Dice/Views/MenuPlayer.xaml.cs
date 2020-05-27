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
using System.Windows.Shapes;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para MenuPlayer.xaml
    /// </summary>
    public partial class MenuPlayer : Window
    {
        public MenuPlayer()
        {
            InitializeComponent();
            passworw.Background = Brushes.White;
            passworw.Foreground = Brushes.Black;
        }

        private void Ataq_Click(object sender, RoutedEventArgs e)
        {
            sword.Foreground = new SolidColorBrush(Colors.White);
            if (sword.Foreground == Brushes.White)
            {
                sword.Foreground = new SolidColorBrush(Colors.Purple);
            }
        }

        private void Def_Click(object sender, RoutedEventArgs e)
        {
            shield.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Hability_Click(object sender, RoutedEventArgs e)
        {
            book.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            dice.Foreground = new SolidColorBrush(Colors.White);

        }

        private void FixPass_Click(object sender, RoutedEventArgs e)
        {
            passworw.IsReadOnly = true;

        }
    }
}

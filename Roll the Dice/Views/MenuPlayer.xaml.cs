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
        TicketCharacter perso = new TicketCharacter();
        Inventario inv = new Inventario();
        int diceNum { get; set; } = 6;

        public MenuPlayer()
        {
            InitializeComponent();
            //passworw.Background = Brushes.White;
            //passworw.Foreground = Brushes.Black;
        }

        private void Ataq_Click(object sender, RoutedEventArgs e)
        {
            sword.Foreground = new SolidColorBrush(Colors.White);
            if (sword.Foreground == Brushes.White)
            {
                sword.Foreground = new SolidColorBrush(Colors.Purple);
            }
        }

        private void Perso_Click(object sender, RoutedEventArgs e)
        {
            if (perso.ShowActivated) {
                perso.Close();
            }
            this.perso = new TicketCharacter();
            perso.Show();
           
        }

        private void Invetario_Click(object sender, RoutedEventArgs e)
        {
            if (inv.ShowActivated)
            {
                inv.Close();
            }
            this.inv = new Inventario();
            inv.Show();
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            switch (diceNum)
            {
                case 1: 
            }

        }

 

        /*private void FixPass_Click(object sender, RoutedEventArgs e)
        {
            passworw.IsReadOnly = true;

        }*/
    }
}

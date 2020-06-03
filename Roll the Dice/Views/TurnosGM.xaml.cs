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
    /// Lógica de interacción para TurnosGM.xaml
    /// </summary>
    public partial class TurnosGM : Window
    {
        List<String> itemList = new List<String>() { "Jugador1", "Jugador2", "Jugador3"};
        public TurnosGM()
        {
            InitializeComponent();
        }

        private void dinamicCheckboxList()
        {
            //Acabar de mirar
            //var itemList = MenuGM.armas.ToList();
            foreach (var item in itemList)
            {
                //CheckBox chk = new CheckBox();
                //chk.Content = item.ToString();
                //st1.Items.Add(chk);

                turnosList.Items.Add(item);
            }
        }
    }
}

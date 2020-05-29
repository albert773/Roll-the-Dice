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
    /// Lógica de interacción para CreacionArma.xaml
    /// </summary>
    public partial class CreacionArma : Page
    {
        public CreacionArma()
        {
            InitializeComponent();
        }

        private void CrearArma_CLick(Object sender, EventArgs e) {
            //Acabar de mirar
            MenuGM.armas.Add(nombreArma.Text);
            //MenuGM menu = new MenuGM();
            //menu.reloadListCrear();
        }
    }
}

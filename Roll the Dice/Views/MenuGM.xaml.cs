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
    /// Lógica de interacción para MenuGM.xaml
    /// </summary>
    public partial class MenuGM : Window
    {
        CreacionDeCosas crea= new CreacionDeCosas();
        EliminarCosas eliminar = new EliminarCosas();

        public static List<string> armas = new List<string>();
        static List<Object> armaduras = new List<object>();
        static List<Object> items = new List<object>();
        static List<Object> npcMonstruos = new List<Object>();
        static List<Object> players = new List<object>();

        public MenuGM()
        {
            InitializeComponent();
            //reloadListCrear();
            frameMap.Content = new Mapa();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (crea.ShowActivated)
            {
                crea.Close();
            }
            this.crea = new CreacionDeCosas();
            crea.Show();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (eliminar.ShowActivated)
            {
                eliminar.Close();
            }
            this.eliminar = new EliminarCosas();
            eliminar.Show();
        }

        public void reloadListCrear() {
            foreach (Object obj in armas)
            {
                listCreados.Items.Add(obj);
            }
        }
    }
}

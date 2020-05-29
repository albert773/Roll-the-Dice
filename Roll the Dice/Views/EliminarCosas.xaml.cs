using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para EliminarCosas.xaml
    /// </summary>
    public partial class EliminarCosas : Window
    {
        

        public EliminarCosas()
        {
            InitializeComponent();
            dinamicCheckboxList();
        }

        private void dinamicCheckboxList()
        {
            //Acabar de mirar
            //var itemList = MenuGM.armas.ToList();
            List<String> itemList = new List<String>() { "Arma1", "Arma2", "Arma3", "Arma4", "Arma5", "Arma6","Arma7", "Arma8", "Arma9", "Arma10",
            "Arma11", "Arma12", "Arma13", "Arma14", "Arma15", "Arma16","Arma17", "Arma18", "Arma19", "Arma20",};
            foreach (var item in itemList) {
                //CheckBox chk = new CheckBox();
                //chk.Content = item.ToString();
                //st1.Items.Add(chk);
                st1.Items.Add(item);
            }
        }
    }
}

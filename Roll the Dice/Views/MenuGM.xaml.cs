﻿using System;
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
        public MenuGM()
        {
            InitializeComponent();
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
    }
}

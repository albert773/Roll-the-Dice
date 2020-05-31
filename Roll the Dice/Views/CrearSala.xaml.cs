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

        private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MyPasswordBox.Visibility = System.Windows.Visibility.Collapsed;
            MyTextBox.Visibility = System.Windows.Visibility.Visible;
            MyTextBox.Text = MyPasswordBox.Password.ToString();

            MyTextBox.Focus();
        }

        private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MyPasswordBox.Visibility = System.Windows.Visibility.Visible;
            MyTextBox.Visibility = System.Windows.Visibility.Collapsed;

            MyPasswordBox.Focus();
        }
    }
}

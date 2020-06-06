using RestSharp;
using Roll_the_Dice.Models;
using Roll_the_Dice.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
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
        RestClient client;
        public CrearSala()
        {
            InitializeComponent();
            client = new RestClient("https://roll-the-dice-service.conveyor.cloud/api/");
        }

        private void Volver_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new CreateJoin());
        }

        private async void Unirse_Click(object sender, RoutedEventArgs e)
        {
            if (Nombre.Text == null || Nombre.Text == "")
            {
                //TODO - Debes introducir un nombre
                return;
            }

            if (Contraseña.Password == null || Contraseña.Password == "")
            {
                //TODO - Debes introducir una contraseña
                return;
            }

            var request = new RestRequest("salas", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            var param = new Sala { nombre = Nombre.Text, propietario = Constants.Usuario.usuarioId, password = Encryption.EncodePasswordToBase64(Contraseña.Password) };
            request.AddJsonBody(param);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            MenuGM gm = new MenuGM();
            gm.Show();
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.Close();
        }

        private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Contraseña.Visibility = System.Windows.Visibility.Collapsed;
            MyTextBox.Visibility = System.Windows.Visibility.Visible;
            MyTextBox.Text = Contraseña.Password.ToString();

            MyTextBox.Focus();
        }

        private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Contraseña.Visibility = System.Windows.Visibility.Visible;
            MyTextBox.Visibility = System.Windows.Visibility.Collapsed;

            Contraseña.Focus();
        }
    }
}

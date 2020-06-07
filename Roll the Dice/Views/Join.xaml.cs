using RestSharp;
using Roll_the_Dice.Models;
using Roll_the_Dice.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para Join.xaml
    /// </summary>
    public partial class Join : Page
    {
        RestClient client;
        string salaSeleccionada;

        public Join()
        {
            InitializeComponent();        
        }

        private async void Ip_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Ip.Text == null || Ip.Text == "")
            {
                return;
            }

            client = new RestClient(Ip.Text + "api/");
            var request = new RestRequest("salas", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            List<Sala> salas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Sala>>(response.Content);

            foreach (Sala sala in salas)
            {
                Salas.Items.Add(sala.nombre);
            }
        }

        private void Salas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            salaSeleccionada = Salas.SelectedValue.ToString();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateJoin());
        }

        private async void Unirse_Click(object sender, RoutedEventArgs e)
        {
            if (salaSeleccionada == null || Contraseña.Password == null || Contraseña.Password == "" || Ip.Text == null || Ip.Text == "")
            {
                //TODO - Todos los campos deben tener valores
                return;
            }

            var request = new RestRequest("salas/{nombre}", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);
            request.AddParameter("nombre", salaSeleccionada, ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                return;
            }

            Sala sala = Newtonsoft.Json.JsonConvert.DeserializeObject<Sala>(response.Content);

            if(sala.password == Encryption.EncodePasswordToBase64(Contraseña.Password))
            {
                Constants.Sala = sala;
            }
            else
            {
                //TODO - Contraseña Incorrecta
                return;
            }

            var request2 = new RestRequest("personajes/usuario/{email}/sala/{salaId}/all", Method.GET);
            request2.AddHeader("Content-type", "application/json");
            request2.AddHeader("Authorization", Constants.Token);
            request2.AddParameter("email", Constants.Usuario.email, ParameterType.UrlSegment);
            request2.AddParameter("salaId", Constants.Sala.salaId, ParameterType.UrlSegment);

            var response2 = await client.ExecuteAsync(request2);

            if (!response2.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                //return;
                Constants.Personaje = null;
            }
            else
            {
                Constants.Personaje = Newtonsoft.Json.JsonConvert.DeserializeObject<Personaje>(response2.Content);
            }

            if (Constants.Sala.propietario == Constants.Usuario.usuarioId)
            {
                MenuGM menuGM = new MenuGM();
                menuGM.Show();
            }
            else
            {
                //Cambio de pagina a Ventana
                MenuPlayer menu = new MenuPlayer();
                menu.Show();
            }

            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.Close();
        }
    }
}

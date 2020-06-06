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

        public Join()
        {
            InitializeComponent();        }

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

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateJoin());
        }

        private void Unirse_Click(object sender, RoutedEventArgs e)
        {
            //Cambio de pagina a Ventana
            MenuPlayer menu = new MenuPlayer();
            menu.Show();
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.Close();
        }
    }
}

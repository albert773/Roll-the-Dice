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
using RestSharp;
using Roll_the_Dice.Utils;
using Roll_the_Dice.Models;
using System.Diagnostics;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para AsignarCosasPlayers.xaml
    /// </summary>
    public partial class AsignarCosasPlayers : Window
    {
        RestClient client;
        List<Personaje> personajes;
        public AsignarCosasPlayers()
        {
            client = new RestClient(Constants.IP);
            InitializeComponent();
            personajeList();
        }

        public async void personajeList()
        {
            var request = new RestRequest("personajessala/{salaId}", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            request.AddParameter("salaId",Constants.Sala.salaId,ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            personajes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Personaje>>(response.Content);

            foreach (var nom in personajes)
            {
                TextBlock text = new TextBlock();
                text.Foreground = new SolidColorBrush(Colors.Black);
                text.TextAlignment = TextAlignment.Left;
                text.Text = nom.nombre.ToString();
                PersonajeBox.Items.Add(text);
            }
        }
    }
}

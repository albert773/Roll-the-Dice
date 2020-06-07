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
    /// Lógica de interacción para CreacionArma.xaml
    /// </summary>
    public partial class CreacionArma : Page
    {
        RestClient client;
        List<Rareza> rarezas;
        List<Elemento> elementos;
        public CreacionArma()
        {
            client = new RestClient(Constants.IP);
            InitializeComponent();
        }

        private void CrearArma_CLick(Object sender, EventArgs e) {
            //Acabar de mirar
            MenuGM.armas.Add(nombreArma.Text);
            //MenuGM menu = new MenuGM();
            //menu.reloadListCrear();
        }

        public async void rarezaCombo()
        {
            var request = new RestRequest("rarezas", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            rarezas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rareza>>(response.Content);

            foreach (var nom in rarezas)
            {
                //clase;
                TextBlock text = new TextBlock();
                text.Foreground = new SolidColorBrush(Colors.Black);
                text.TextAlignment = TextAlignment.Left;
                text.Text = nom.nombre.ToString();
                rarezaBox.Items.Add(text);
            }
        }

        public async void elementoCombo()
        {
            var request = new RestRequest("rarezas", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            elementos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Elemento>>(response.Content);

            foreach (var nom in elementos)
            {
                //clase;
                TextBlock text = new TextBlock();
                text.Foreground = new SolidColorBrush(Colors.Black);
                text.TextAlignment = TextAlignment.Left;
                text.Text = nom.nombre.ToString();
                elementosBox.Items.Add(text);
            }
        }
    }
}

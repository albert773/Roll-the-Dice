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
        List<NombreArma> nombresarma;
        public CreacionArma()
        {
            client = new RestClient(Constants.IP);
            InitializeComponent();
            rarezaCombo();
            elementoCombo();
            getNombreArma();
        }

        private async void CrearArma_CLick(Object sender, EventArgs e) {

            postNombreArma();

            var request = new RestRequest("armas", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            request.AddJsonBody(new Arma {alcance = int.Parse(alcance.Text), bonus = int.Parse(bonus.Text), daño = int.Parse(daño.Text), 
                defensa = int.Parse(defensa.Text), descripcion = descripcion.Text, durabilidad = 100, elemento = elementos.FirstOrDefault(q => q.nombre.Equals(elementosBox.Text)).elementoId,
                equipado = false, esquiva = int.Parse(esquiva.Text), estadistica = 1, rareza = rarezas.FirstOrDefault(q => q.nombre.Equals(rarezaBox.Text)).rarezaId,
                nombre = nombresarma.FirstOrDefault(q => q.nombre.Equals(nombreArmaPer.Text)).nombreArmaId
            });

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
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
            var request = new RestRequest("elementos", Method.GET);
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

        public async void getNombreArma()
        {
            var request = new RestRequest("nombreArmas", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            nombresarma = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NombreArma>>(response.Content);
        }

        public async void postNombreArma() {

            var request = new RestRequest("nombreArmas", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            request.AddJsonBody(new NombreArma
            {
                nombre = nombreArmaPer.Text
            });

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
        }
    }
}

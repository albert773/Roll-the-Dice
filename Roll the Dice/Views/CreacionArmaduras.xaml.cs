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
    /// Lógica de interacción para CreacionArmaduras.xaml
    /// </summary>
    public partial class CreacionArmaduras : Page
    {
        RestClient client;
        List<Rareza> rarezas;
        List<Elemento> elementos;
        List<NombreArmadura> nombrearmadura;
        public CreacionArmaduras()
        {
            client = new RestClient(Constants.IP);
            InitializeComponent();
            rarezaCombo();
            elementoCombo();
        }

        public async void crearArmadura_Click(Object sender, EventArgs e) {

            postNombreArmadura();
            getNombreArmadura();

            var request = new RestRequest("armaduras", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            decimal bonusArmadura;
            try
            {
                bonusArmadura = decimal.Parse(bonus.Text);
            }
            catch (Exception except)
            {
                bonusArmadura = 1;
            }

            if (!elementosBox.Text.Equals("") || elementosBox.Text != null)
            {
                //TODO - crear armadura
                Armadura a = new Armadura
                {
                    estadistica = 3,
                    bonus = bonusArmadura,
                    contundente = int.Parse(contundente.Text),
                    corte = int.Parse(corteArmadura.Text),
                    defFisica = int.Parse(defFisica.Text),
                    defMagica = int.Parse(defMag.Text),
                    descripcion = descripcion.Text,
                    durabilidad = 100,
                    equipado = false,
                    nombre = nombrearmadura.FirstOrDefault(q => q.nombre.Equals(nombreArmaduraPer.Text)).nombreArmaduraId,
                    penetracion = int.Parse(penetracion.Text),
                    rareza = rarezas.FirstOrDefault(q => q.nombre.Equals(rarezaBox.Text)).rarezaId
                };
                request.AddJsonBody(a);
            }
            else {
                request.AddJsonBody(new Armadura
                {
                    estadistica = 3,
                    bonus = bonusArmadura,
                    contundente = int.Parse(contundente.Text),
                    corte = int.Parse(corteArmadura.Text),
                    defFisica = int.Parse(defFisica.Text),
                    defMagica = int.Parse(defMag.Text),
                    descripcion = descripcion.Text,
                    durabilidad = 100,
                    elemento = elementos.FirstOrDefault(q => q.nombre.Equals(elementosBox.Text)).elementoId,
                    equipado = false,
                    nombre = nombrearmadura.FirstOrDefault(q => q.nombre.Equals(nombreArmaduraPer.Text)).nombreArmaduraId,
                    penetracion = int.Parse(penetracion.Text),
                    rareza = rarezas.FirstOrDefault(q => q.nombre.Equals(rarezaBox.Text)).rarezaId
                });
            }

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

        public void postNombreArmadura()
        {

            var request = new RestRequest("nombreArmaduras", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            request.AddJsonBody(new NombreArmadura
            {
                nombre = nombreArmaduraPer.Text
            });

            //request.AddParameter(ParameterType.UrlSegment);

            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
        }

        public void getNombreArmadura()
        {
            var request = new RestRequest("nombreArmaduras", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            //request.AddParameter(ParameterType.UrlSegment);

            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            nombrearmadura = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NombreArmadura>>(response.Content);
        }
    }
}

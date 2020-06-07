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
    /// Lógica de interacción para CreacionMonstruo.xaml
    /// </summary>
    public partial class CreacionMonstruo : Page
    {
        RestClient client;
        List<Raza> razas;
        List<Habilidad> habilidades;
        public CreacionMonstruo()
        {
            client = new RestClient(Constants.IP);
            InitializeComponent();
            razaCombo();
            habilCombo();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {

        }

        public async void razaCombo()
        {
            var request = new RestRequest("razas", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            razas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Raza>>(response.Content);

            foreach (var nom in razas)
            {
                //clase;
                TextBlock text = new TextBlock();
                text.Foreground = new SolidColorBrush(Colors.Black);
                text.TextAlignment = TextAlignment.Left;
                text.Text = nom.nombre.ToString();
                razaBox.Items.Add(text);
            }
        }

        public async void habilCombo()
        {
            var request = new RestRequest("habilidades", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            habilidades = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Habilidad>>(response.Content);

            foreach (var nom in habilidades)
            {
                //clase;
                ListBoxItem text = new ListBoxItem();
                text.Foreground = new SolidColorBrush(Colors.Black);
                text.Content = nom.nombre.ToString();
                listHab.Items.Add(text);
            }
        }
    }
}

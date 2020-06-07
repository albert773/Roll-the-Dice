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
    /// Lógica de interacción para CreacionNPC.xaml
    /// </summary>
    
    public partial class CreacionNPC : Page
    {
        RestClient client;
        List<Raza> razas;
        List<Habilidad> habilidades;
        public CreacionNPC()
        {
            client = new RestClient(Constants.IP);
            InitializeComponent();
            razaCombo();
            habilCombo();
        }

        public async void crearNPC_Click(object sender, RoutedEventArgs e) {
            var request = new RestRequest("NPCs", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            validateEntradas();

            NPC npc = new NPC
            {
                clase = 1,
                edad = 20,
                experiencia = 0,
                misionOculta = historia.Text,
                raza = razas.FirstOrDefault(q => q.nombre.Equals(razaBox.Text)).razaId,
                sexo = sexoBox.Text,
                cobre = int.Parse(cobre.Text),
                vida = int.Parse(vida.Text),
                nivel = int.Parse(lvl.Text),
                nombre = nombreNpc.Text,
                oro = int.Parse(oro.Text),
                plata = int.Parse(plata.Text),
                sala = Constants.Sala.salaId,
                turnos = int.Parse(turno.Text),
                cansancio = 0
            };

            switch (nombreNpc.Text)
            {
                case "alfredo":
                    npc.posicion = 8;
                    break;

                case "alfonso":
                    npc.posicion = 9;
                    break;

                default:
                    break;
            }

            request.AddJsonBody(npc);

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
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
                listhab.Items.Add(text);
            }
        }

        public void validateEntradas()
        {
            if (nombreNpc.Text.Equals("")) return;
            if (razaBox.Text.Equals("") || razaBox.Text == null) return;
            if (fue.Text.Equals("") || fue.Text == null) return;
            if (car.Text.Equals("") || car.Text == null) return;
            if (intel.Text.Equals("") || intel.Text == null) return;
            if (sab.Text.Equals("") || sab.Text == null) return;
            if (des.Text.Equals("") || des.Text == null) return;
            if (con.Text.Equals("") || con.Text == null) return;
        }
    }
}

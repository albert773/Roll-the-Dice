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
        List<Estadistica> listaEstadisticas;
        List<UnionEstatMonst> listaEstats;
        List<Monstruo> monstruos;
        public CreacionMonstruo()
        {
            client = new RestClient(Constants.IP);
            InitializeComponent();
            razaCombo();
            habilCombo();
        }

        private async void crearMonstruo_Click(object sender, RoutedEventArgs e)
        {
            var request = new RestRequest("monstruos", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            validateEntradas();

            Monstruo m = new Monstruo
            {
                cobre = int.Parse(cobre.Text),
                nivel = int.Parse(lvl.Text),
                nombre = nombreMons.Text,
                oro = int.Parse(oro.Text),
                plata = int.Parse(plata.Text),
                sala = Constants.Sala.salaId,
                turnos = int.Parse(turno.Text),
                vida = int.Parse(vida.Text),
            };

            switch (nombreMons.Text)
            {
                case "peter":
                    m.posicion = 6;
                    break;

                case "victor":
                    m.posicion = 7;
                    break;

                default:
                    break;
            }

            request.AddJsonBody(m);

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
        }

        //TODO- añadir habilidades seleccionadas al monstruo

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

        public void validateEntradas() {
            if (nombreMons.Text.Equals("")) return;
            if (razaBox.Text.Equals("") || razaBox.Text == null) return;
            if (fue.Text.Equals("") || fue.Text == null) return;
            if (car.Text.Equals("")  || car.Text == null) return;
            if (intel.Text.Equals("") ||  intel.Text == null) return;
            if (sab.Text.Equals("") || sab.Text == null) return;
            if (des.Text.Equals("") || des.Text == null) return;
            if (con.Text.Equals("") || con.Text == null) return;
        }

        public List<UnionEstatMonst> valorPersonaje(int idMonstruo)
        {
            for (int i = 0; i < listaEstadisticas.Count; i++)
            {
                UnionEstatMonst union = new UnionEstatMonst();
                union.monstruoId = idMonstruo;
                union.estadisticaId = listaEstadisticas[i].estadisticaId;
                union.bonus = Convert.ToDecimal(1.5);
                switch (listaEstadisticas[i].nombre)
                {
                    case "Fuerza":
                        union.valorBase = Int32.Parse(fue.Text);
                        break;

                    case "Inteligencia":
                        union.valorBase = Int32.Parse(intel.Text);
                        break;

                    case "Destreza":
                        union.valorBase = Int32.Parse(des.Text);
                        break;

                    case "Constitucion":
                        union.valorBase = Int32.Parse(con.Text);
                        break;

                    case "Carisma":
                        union.valorBase = Int32.Parse(car.Text);
                        break;

                    case "Sabiduria":
                        union.valorBase = Int32.Parse(sab.Text);
                        break;
                }
                listaEstats.Add(union);
            }
            return listaEstats;
        }

        public async void recoger() {

            var request3 = new RestRequest("estadisticas", Method.GET);
            request3.AddHeader("Content-type", "application/json");
            request3.AddHeader("Authorization", Constants.Token);

            var response3 = await client.ExecuteAsync(request3);

            if (!response3.IsSuccessful)
            {
                return;
            }

            listaEstadisticas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Estadistica>>(response3.Content);
        }

        public async void recogerMonstruo()
        {

            var request3 = new RestRequest("monstruos", Method.GET);
            request3.AddHeader("Content-type", "application/json");
            request3.AddHeader("Authorization", Constants.Token);

            var response3 = await client.ExecuteAsync(request3);

            if (!response3.IsSuccessful)
            {
                return;
            }

            monstruos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Monstruo>>(response3.Content);
        }

        public async void postMonstruo() {
            var requestStats = new RestRequest("estadisticas/all", Method.POST);
            requestStats.AddHeader("Content-type", "application/json");
            requestStats.AddHeader("Authorization", Constants.Token);

            recoger();

            List<UnionEstatMonst> luep = valorPersonaje(monstruos.FirstOrDefault(q => q.nombre.Equals(nombreMons.Text)).monstruoId);

            requestStats.AddJsonBody(luep);

            var responseStats = await client.ExecuteAsync(requestStats);

            if (!responseStats.IsSuccessful)
            {
                return;
            }
        }
    }
}

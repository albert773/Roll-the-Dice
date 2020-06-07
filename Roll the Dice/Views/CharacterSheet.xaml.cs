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
    /// Lógica de interacción para CharacterShe.xaml
    /// </summary>
    public partial class CharacterShe : Window
    {
        RestClient client;
        List<Clase> clases;
        List<Raza> razas;
        List<UnionEstatPerso> listaEstats = new List<UnionEstatPerso>();
        List<Estadistica> listaEstadisticas = new List<Estadistica>();
        public CharacterShe()
        {
            InitializeComponent();
            client = new RestClient(Constants.IP);
            clasesCombo();
            razasCombo();
        }


        public async void Crear_Click(object sender, RoutedEventArgs e)
        {
            //Post Personaje
            Personaje per = new Personaje();

            if (NombrePer.Text == "") return;
            if (raza.Text == "" || raza.Text == null) return;
            if (clase.Text == "" || clase.Text == null) return;
            if (sexo.Text == "" || sexo.Text == null) return;
            if (fue.Text == "" || fue.Text == null) return;
            if (car.Text == "" || car.Text == null) return;
            if (intel.Text == "" || intel.Text == null) return;
            if (sab.Text == "" || sab.Text == null) return;
            if (des.Text == "" || des.Text == null) return;
            if (con.Text == "" || con.Text == null) return;
            if (historia.Text == "") return;

            per.nombre = NombrePer.Text;
            per.misionOculta = historia.Text;
            per.experiencia = 0;
            per.cansancio = 0;
            per.clase = clases.FirstOrDefault(q => q.nombre.Equals(clase.Text)).claseId;
            per.raza = razas.FirstOrDefault(q => q.nombre.Equals(raza.Text)).razaId;
            per.nivel = 0;
            per.oro = 0;
            per.plata = 0;
            per.cobre = 0;
            per.edad = 0;

            switch (NombrePer.Text)
            {
                case "peter":
                    per.posicion = 2;
                    break;

                case "victor":
                    per.posicion = 4;
                    break;

                case "jose":
                    per.posicion = 3;
                    break;

                case "albert":
                    per.posicion = 5;
                    break;

                default:
                    break;
            }
            /*per.posicion = 0;*/
            per.sexo = sexo.Text;
            per.sala = Constants.Sala.salaId;
            per.usuario = Constants.Usuario.usuarioId;
            per.vida = calculoVida(clase.Text, Int32.Parse(con.Text), Int32.Parse(fue.Text));
            per.turnos = calcluloTurnos(Int32.Parse(des.Text));

            var request = new RestRequest("personajes", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            request.AddJsonBody(per);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful) {
                return;
            }
            //FIN Post Personaje

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

            //Get All Estadisticas
            var request3 = new RestRequest("estadisticas", Method.GET);
            request3.AddHeader("Content-type", "application/json");
            request3.AddHeader("Authorization", Constants.Token);

            var response3 = await client.ExecuteAsync(request3);

            if (!response3.IsSuccessful)
            {
                return;
            }

            listaEstadisticas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Estadistica>>(response3.Content);
            //FIN Get All Estadisticas

            // Post UnionEstatsPers
            var requestStats = new RestRequest("estatPerso/all", Method.POST);
            requestStats.AddHeader("Content-type", "application/json");
            requestStats.AddHeader("Authorization", Constants.Token);

            valorPersonaje();

            requestStats.AddJsonBody(listaEstats);

            var responseStats = await client.ExecuteAsync(request);

            if (!responseStats.IsSuccessful)
            {
                return;
            }
            //FIN Post UnionEstatsPers

            

            //Post inventario

            var request4 = new RestRequest("inventarios", Method.POST);
            request4.AddHeader("Content-type", "application/json");
            request4.AddHeader("Authorization", Constants.Token);

            Models.Inventario inv = new Models.Inventario();
            inv.propietario = Constants.Personaje.personajeId;
            inv.capacidad = 50;

            request4.AddJsonBody(inv);

            var response4 = await client.ExecuteAsync(request4);

            if (!response4.IsSuccessful)
            {
                return;
            }

            //FIN Post Inventario

            Close();
        }

        public async void clasesCombo() {
            var request = new RestRequest("clases", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            //request.AddParameter(ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            clases = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Clase>>(response.Content);

            foreach (var nom in clases) {
                //clase;
                TextBlock text = new TextBlock();
                text.Foreground = new SolidColorBrush(Colors.Black);
                text.TextAlignment = TextAlignment.Left;
                text.Text = nom.nombre.ToString();
                clase.Items.Add(text);
            }
        }

        public async void razasCombo()
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
            Debug.WriteLine(response.Content);

            razas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Raza>>(response.Content);

            foreach (var nom in razas)
            {
                TextBlock text = new TextBlock();
                text.Foreground = new SolidColorBrush(Colors.Black);
                text.TextAlignment = TextAlignment.Left;
                text.Text = nom.nombre.ToString();
                raza.Items.Add(text);
            }
        }

        public int calculoVida(String clase, int cons, int fuerza) {
            if (clase.Equals("Mago")) return 4 * cons;
            if (clase.Equals("Guerrero")) return 12 * cons;
            if (clase.Equals("Mistico")) return 10 * cons;
            if (clase.Equals("Arquero")) return 8 * cons;
            if (clase.Equals("Asesino")) return 6 * cons;
            return (fuerza + cons)*2;
        }

        public int calcluloTurnos(int destreza) {
            if (destreza < 10) return 2;
            return (destreza % 10) + 2;
        }

        public void valorPersonaje() {
            for (int i = 0; i < listaEstadisticas.Count; i++)
            {
                UnionEstatPerso union = new UnionEstatPerso();
                union.personajeId = Constants.Personaje.personajeId;
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
        }
    }
}
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
        public CharacterShe()
        {
            InitializeComponent();
            client = new RestClient(Constants.IP);
            clasesCombo();
            razasCombo();

            /*System.Windows.Resources.StreamResourceInfo streamInfo = Application.GetResourceStream(new Uri("/Images/arrow.png", UriKind.Relative));
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;
            Crear.Background = brush;*/

        }


        public async void Crear_Click(object sender, RoutedEventArgs e)
        {

            Personaje per = new Personaje();

            //TODO validaciones

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
            per.posicion = 0;
            per.sexo = sexo.Text;
            per.estadosAlterados = 0;
            per.sala = Constants.Sala.salaId;
            per.usuario = Constants.Usuario.usuarioId;
            per.vida = calculoVida(clase.Text, Int32.Parse(con.Text), Int32.Parse(fue.Text));
            per.turnos = calcluloTurnos(Int32.Parse(des.Text));


            var request = new RestRequest("personajes", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            //request.AddParameter("id", Constants.Usuario.usuarioId, ParameterType.UrlSegment);
            request.AddJsonBody(per) ;
            //new Personaje{nombre = NombrePer.Text, ....}

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful) {
                return;
            }

            var requestStats = new RestRequest("estadisticas/all", Method.POST);
            requestStats.AddHeader("Content-type", "application/json");
            requestStats.AddHeader("Authorization", Constants.Token);

            

            //request.AddJsonBody();
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
            //Eror no se porque
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
            if (clase.Equals("Mago")) return 4*cons;
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
    }
}
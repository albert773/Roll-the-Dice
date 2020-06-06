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
        }


        public async void Crear_Click()
        {

            Personaje per = new Personaje();

            per.nombre = NombrePer.Text;
            per.misionOculta = historia.Text;
            per.experiencia = 0;
            per.cansancio = 0;
            //per.clase;

            var request = new RestRequest("{id}", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            request.AddParameter("id", Constants.Usuario.usuarioId, ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            //var param = new Arma {daño =  }
            //{ Email = Email.Text, Password = Encryption.EncodePasswordToBase64(Contraseña.Password) };
            //request.AddJsonBody(param);

            //sword.Foreground = new SolidColorBrush(Colors.White);
            Inventario invent = Newtonsoft.Json.JsonConvert.DeserializeObject<Inventario>(response.Content);
            Debug.WriteLine(invent.Name);

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

            //Eror no se porque
            /*razas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Raza>>(response.Content);

            foreach (var nom in razas)
            {
                TextBlock text = new TextBlock();
                text.Foreground = new SolidColorBrush(Colors.Gray);
                text.TextAlignment = TextAlignment.Left;
                text.Text = nom.nombre.ToString();
                raza.Items.Add(text);
            }*/
        }

        public async void SexoCombo()
        {
            //poner el sexo
        }

        public async void verificar()
        {
            //TODO crear metodo post
        }
    }
}
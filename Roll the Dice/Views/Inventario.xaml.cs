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
    /// Lógica de interacción para Inventario.xaml
    /// </summary>
    public partial class Inventario : Window
    {
        RestClient client;
        List<Models.Item> Listaitem;
        List<Models.Arma> listaArma;
        public Inventario()
        {
            if(Constants.Usuario.email == "jose@gmail.com")
            {
                Arma.Items.Add("espada");
                Armdura.Items.Add("armadura de tela");
            }

            InitializeComponent();
            client = new RestClient(Constants.IP);
            InicializarItems();
        }

        public async void Actualizar_Clicked() {
            var request = new RestRequest("inventario/usuario/{id}/sala/{salaId}", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            request.AddParameter("id", Constants.Usuario.usuarioId, ParameterType.UrlSegment);
            request.AddParameter("salaId", Constants.Sala.salaId, ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            Inventario invent = Newtonsoft.Json.JsonConvert.DeserializeObject<Inventario>(response.Content);
            Debug.WriteLine(invent.Name);
            Console.WriteLine(invent.Name);
        }

        public async void InicializarItems() {
            var request = new RestRequest("items", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            //request.AddParameter("id", Constants.Usuario.usuarioId, ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            //var param = new Arma {daño =  }
            //{ Email = Email.Text, Password = Encryption.EncodePasswordToBase64(Contraseña.Password) };
            //request.AddJsonBody(param);

            //sword.Foreground = new SolidColorBrush(Colors.White);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            Listaitem = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.Item>>(response.Content);

            foreach (var items in Listaitem) {
                TextBlock text = new TextBlock();
                text.Foreground = new SolidColorBrush(Colors.Black);
                text.TextAlignment = TextAlignment.Left;
                text.Text = items.nombre.ToString();
                ItemBox.Items.Add(text);
            }
            
        }

        public async void descripcionItem_Click(object sender, SelectionChangedEventArgs e) {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            foreach (var item in Listaitem) {
                if (item.nombre.Equals(text)) {
                    descripcionItem.Text = item.descripcion.ToString();
                }
            }
        }

        public async void descripcionArma_Click(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            foreach (var item in listaArma)
            {
                if (item.nombre.Equals(text))
                {
                    Rareza.Text = item.rareza.ToString();
                    Elemento.Text = item.elemento.ToString();
                    Defensa.Text = item.defensa.ToString();
                    Esquiva.Text = item.esquiva.ToString();
                    Daño.Text = item.daño.ToString();
                }
            }
        }

        public async void descripcionArmadura_Click(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            foreach (var item in listaArma)
            {
                if (item.nombre.Equals(text))
                {
                    RarezaArmadura.Text = item.rareza.ToString();
                    ElementoArmadura.Text = item.elemento.ToString();
                    DefensaArmadura.Text = item.defensa.ToString();
                }
            }
        }

        public async void usar_Click(object sender, SelectionChangedEventArgs e)
        {
            //TODO Post
        }

        public async void soltar_Click(object sender, SelectionChangedEventArgs e)
        {
            //TODO Post
        }

        public async void equipar_Click(object sender, SelectionChangedEventArgs e)
        {
            //TODO Post
        }

    }
}

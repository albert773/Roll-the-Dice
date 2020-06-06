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
        public Inventario()
        {
            InitializeComponent();
            client = new RestClient(Constants.IP);
            InicializarItems();
        }

        public async void Actualizar_Clicked() {
            var request = new RestRequest("inventario/personaje/{id}", Method.GET);
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
            Console.WriteLine(invent.Name);
        }

        public async void InicializarItems() {
            var request = new RestRequest("inventario/personaje/{id}", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            request.AddParameter("id", Constants.Usuario.usuarioId, ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            //var param = new Arma {daño =  }
            //{ Email = Email.Text, Password = Encryption.EncodePasswordToBase64(Contraseña.Password) };
            //request.AddJsonBody(param);

            //sword.Foreground = new SolidColorBrush(Colors.White);
            Inventario invent = Newtonsoft.Json.JsonConvert.DeserializeObject<Inventario>(response.Content);
            Debug.WriteLine(invent);
        }
    }
}

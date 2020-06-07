using RestSharp;
using Roll_the_Dice.Models;
using Roll_the_Dice.Utils;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        RestClient client;

        public LogIn()
        {
            InitializeComponent();
            client = new RestClient(Constants.IP);
            //Constrants.IP
            //https://roll-the-dice-service.conveyor.cloud/api/
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            errorMail.Visibility = Visibility.Hidden;
            errorPass.Visibility = Visibility.Hidden;
            borderMessageCorreo.Visibility = Visibility.Hidden;
            borderMessagePass.Visibility = Visibility.Hidden;
            correoMessageError.Visibility = Visibility.Hidden;
            textErrorPass.Visibility = Visibility.Hidden;

            if (!Validations.IsValidEmail(Email.Text))
            {
                errorMail.Visibility = Visibility.Visible;
                return;
            }

            if(Contraseña.Password == null || Contraseña.Password == "")
            {
                errorPass.Visibility = Visibility.Visible;
                return;
            }

            var request = new RestRequest("auth/login", Method.POST);
            request.AddHeader("Content-type", "application/json");
            //request.AddHeader("Authorization", Constants.Token);

            var param = new RegisterRequest { Email = Email.Text, Password = Encryption.EncodePasswordToBase64(Contraseña.Password) };
            request.AddJsonBody(param);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            Constants.Token = "Bearer " + response.Content.Substring(1, response.Content.Length - 2);

            var request2 = new RestRequest("usuarios/email/{email}/", Method.GET);
            request2.AddHeader("Content-type", "application/json");
            request2.AddHeader("Authorization", Constants.Token);
            request2.AddParameter("email", Email.Text, ParameterType.UrlSegment);
            var response2 = await client.ExecuteAsync(request2);

            if (!response2.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            Constants.Usuario = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(response2.Content);

            NavigationService.Navigate(new CreateJoin());
        }

        private void Registrarse_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registrarse());
        }

        private void Contraseña_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ForgotPassword());
        }
    }
}

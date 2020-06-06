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
        Boolean confirm = true;

        public LogIn()
        {
            InitializeComponent();
            client = new RestClient("https://roll-the-dice-service.conveyor.cloud/api/");   
            //Constrants.IP
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            errorMail.Visibility = Visibility.Hidden;
            errorPass.Visibility = Visibility.Hidden;
            borderMessageCorreo.Visibility = Visibility.Hidden;
            borderMessagePass.Visibility = Visibility.Hidden;
            correoMessageError.Visibility = Visibility.Hidden;
            textErrorPass.Visibility = Visibility.Hidden;

            /*if (Email.Text.Equals("")) {
                NavigationService.Navigate(new CreateJoin());
            }*/

            /*if (correoText.Text.Equals(""))
            {
                confirm = false;
                errorMail.Visibility = Visibility.Visible;
            }*/
            //if (true) confirm = false;
            //if(confirm)

            if (!Validations.IsValidEmail(Email.Text))
            {
                //TODO - Email no valido
                return;
            }

            if(Contraseña.Password == null || Contraseña.Password == "")
            {
                //TODO - Debes introducir una contraseña
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

            Constants.Token = "Bearer " + response.Content.Substring(2, response.Content.Length - 2);

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

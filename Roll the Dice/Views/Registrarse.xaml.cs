using RestSharp;
using Roll_the_Dice.Models;
using Roll_the_Dice.Utils;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para Registrarse.xaml
    /// </summary>
    public partial class Registrarse : Page
    {

        RestClient client;

        public Registrarse()
        {
            InitializeComponent();
            client = new RestClient(Constants.IP);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIn());
        }

        private async void Registrarse_Clicked(object sender, RoutedEventArgs e)
        {
            if (!Validations.IsValidEmail(Email.Text))
            {
                //TODO - El Email no es valido
                errorMail.Visibility = Visibility.Visible;
                return;
            }

            if (!Regex.IsMatch(Contraseña.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,16}$"))
            {
                //TODO - La contraseña no es valida
                errorPass.Visibility = Visibility.Visible;
                textErrorPass.Text = "La contraseña no es valida";
                return;
            }

            if (!Regex.IsMatch(ContraseñaRepetida.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,16}$"))
            {
                //TODO - La contraseña no es valida
                errorIconValidatePass.Visibility = Visibility.Visible;
                textValidatePass.Text = "La contraseña no es valida";
                return;
            }

            if (Contraseña.Password != ContraseñaRepetida.Password)
            {
                //TODO - Las contraseñas no coinciden
                errorIconValidatePass.Visibility = Visibility.Visible;
                textValidatePass.Text = "La contraseña no coincide con la anterior";
                return;
            }

            RegisterRequest register = new RegisterRequest();
            register.Email = Email.Text;
            register.Nickname = Nickname.Text;
            register.Password = Contraseña.Password;

            var request = new RestRequest("auth/register", Method.POST);
            request.AddHeader("Content-type", "application/json");

            var param = new RegisterRequest { Email = Email.Text, Nickname = Nickname.Text, Password = Encryption.EncodePasswordToBase64(Contraseña.Password) };
            request.AddJsonBody(param);
            
            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - No se ha podido insertar el usuario
                return;
            }
            
            NavigationService.Navigate(new LogIn());
        }

        private void VisibleErrorValidate_Click(object sender, RoutedEventArgs e)
        {
            borderValidatePass.Visibility = Visibility.Visible;
            textValidatePass.Visibility = Visibility.Visible;
        }

        private void VisibleErrorEmail_Click(object sender, RoutedEventArgs e)
        {
            borderMessagePass.Visibility = Visibility.Visible;
            textErrorPass.Visibility = Visibility.Visible;
        }

        private void VisibleErrorRePass_Click(object sender, RoutedEventArgs e)
        {
            borderMessageCorreo.Visibility = Visibility.Visible;
            correoMessageError.Visibility = Visibility.Visible;
        }

    }
}

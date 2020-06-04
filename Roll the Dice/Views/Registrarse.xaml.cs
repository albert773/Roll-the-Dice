using RestSharp;
using Roll_the_Dice.Models;
using Roll_the_Dice.Utils;
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
            client = new RestClient("https://roll-the-dice-service.conveyor.cloud/api/");
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIn());
        }

        private void Registrarse_Clicked(object sender, RoutedEventArgs e)
        {
            if (!Validations.IsValidEmail(Email.Text))
            {
                //RODO - El Email no es valido
                return;
            }

            if (!Regex.IsMatch(Contraseña.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,16}$"))
            {
                //TODO - La contraseña no es valida
                return;
            }

            if (!Regex.IsMatch(ContraseñaRepetida.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,16}$"))
            {
                //TODO - La contraseña no es valida
                return;
            }

            if (Contraseña.Password != ContraseñaRepetida.Password)
            {
                //TODO - Las contraseñas no coinciden
                return;
            }

            RegisterRequest register = new RegisterRequest();
            register.Email = Email.Text;
            register.Nickname = Nickname.Text;
            register.Password = Contraseña.Password;

            var request = new RestRequest("auth/register", Method.POST);
            request.AddParameter("Email", Email.Text);
            request.AddParameter("Nickname", Nickname.Text);
            request.AddParameter("Password", Contraseña.Password);

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                //TODO - No se ha podido insertar el usuario
                return;
            }

            MessageBox.Show(response.Content);
        }

        private void VisibleErrorValidate_Click(object sender, RoutedEventArgs e)
        {
            borderValidatePass.Visibility = Visibility.Visible;
            textValidatePass.Visibility = Visibility.Visible;
        }

    }
}

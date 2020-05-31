using System;
using System.Windows;
using System.Windows.Controls;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        Boolean confirm = true;
        public LogIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            errorMail.Visibility = Visibility.Hidden;
            errorPass.Visibility = Visibility.Hidden;
            borderMessageCorreo.Visibility = Visibility.Hidden;
            borderMessagePass.Visibility = Visibility.Hidden;
            correoMessageError.Visibility = Visibility.Hidden;
            textErrorPass.Visibility = Visibility.Hidden;


            /*if (correoText.Text.Equals(""))
            {
                confirm = false;
                errorMail.Visibility = Visibility.Visible;
            }*/
            //if (true) confirm = false;
            //if(confirm)
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

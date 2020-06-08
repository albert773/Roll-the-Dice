using MaterialDesignThemes.Wpf;
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
using System.Threading;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para MenuPlayer.xaml
    /// </summary>
    public partial class MenuPlayer : Window
    {
        public static Mapa mapa { get; set; } = new Mapa();
        MainWindow main = new MainWindow();
        //TicketCharacter perso = new TicketCharacter();
        Inventario inv = new Inventario();
        int diceNum { get; set; } = 10;
        RestClient client;

        public MenuPlayer()
        {
            InitializeComponent();
            frameMap.Content = mapa;
            Thread t = new Thread(ThreadGUI.threadGO);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            Ip.Text = Constants.IP.Substring(0, Constants.IP.Length - 4);
            client = new RestClient(Constants.IP);
            //passworw.Background = Brushes.White;
            //passworw.Foreground = Brushes.Black;
            
            if (Constants.Sala.propietario != Constants.Usuario.usuarioId && !usuarioHasPersonaje())
            {
                CharacterShe caracter = new CharacterShe();
                caracter.Show();
                caracter.Activate();
                caracter.Focus();
                caracter.Topmost = true;
            }

        }
        public void mapaSetterPos()
        {
            this.Dispatcher.Invoke(() =>
            {
                mapa.mapaStartOnMenu();
            });
        }

        private bool usuarioHasPersonaje()
        {
            //TODO - Acabar de revisar si funciona o no
            var request = new RestRequest("personajes/usuario/{email}/sala/{salaId}", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);
            request.AddParameter("email", Constants.Usuario.email, ParameterType.UrlSegment);
            request.AddParameter("salaId", Constants.Sala.salaId, ParameterType.UrlSegment);

            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return false;
            }

            
            return true;
        }

        private void Defensa_Click(object sender, RoutedEventArgs e)
        {
            //Recoger info daño

            //var request = new RestRequest("", Method.POST);
            
            //si el dado es superior a 80 lo defiendes entero
            /*Si es inferior es:
             mirar si tiene elemento
                defensa contra elemento
            mirar que tipo de ataque
                defensa contra el tipo de ataque
             */


        }

        private void Esquiva_Click(object sender, RoutedEventArgs e)
        {
            mapa.setMover();
        }

        private void Ataq_Click(object sender, RoutedEventArgs e)
        {
            mapa.setAtaque();
        }

        private void Perso_Click(object sender, RoutedEventArgs e)
        {
            /*if (perso.ShowActivated) {
                perso.Close();
            }
            this.perso = new TicketCharacter();
            perso.Show();*/
           
        }

        private void Invetario_Click(object sender, RoutedEventArgs e)
        {
            if (inv.ShowActivated)
            {
                inv.Close();
            }
            this.inv = new Inventario();
            inv.Show();
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            diceChange();
            Number.Text = randomDice();

        }
        private string randomDice()
        {
            
            string s="";
            int max = diceNum + 1;
            Random random = new Random();
            s+= random.Next(1, max);
            return s;
        }

        public void diceChange()
        {
            //Cuando el game master cambie el dice llama a esto en todos los jugadores
            switch (diceNum)
            {
                case 6:
                    dice.Kind = PackIconKind.Dice6;
                    break;

                case 12:
                    dice.Kind = PackIconKind.DiceD12;
                    break;
                case 10:
                    dice.Kind = PackIconKind.DiceD10;
                    break;
                case 3:
                    dice.Kind = PackIconKind.Dice3;
                    break;
                case 20:
                    dice.Kind = PackIconKind.DiceD20;
                    break;
                case 8:
                    dice.Kind = PackIconKind.DiceD8;
                    break;
                case 4:
                    dice.Kind = PackIconKind.Dice4;
                    break;
                case 5:
                    dice.Kind = PackIconKind.Dice5;
                    break;
            }
        }
 

        private void cerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            main.Show();

        }
        public async void UpdateDice()
        {
            var request = new RestRequest("singleton/dados", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);
            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
            this.diceNum = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(response.Content);

            diceChange();
        }
    }
}

using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using RestSharp;
using Roll_the_Dice.Utils;
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

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para MenuGM.xaml
    /// </summary>
    public partial class MenuGM : Window
    {
        MainWindow main;
        CreacionDeCosas crea;
        AsignarCosasPlayers eliminar;
        CharacterShe caraceter;
        Mapa mapa = new Mapa();
        RestClient client;

        public static List<string> armas = new List<string>();
        static List<Object> armaduras = new List<object>();
        static List<Object> items = new List<object>();
        static List<Object> npcMonstruos = new List<Object>();
        static List<Object> players = new List<object>();
        //TODO - Modificar
        //TicketCharacter perso = new TicketCharacter();
        private int DiceNum { get; set; }=6;

        public MenuGM()
        {
            TurnosGM turnos = new TurnosGM();
            turnos.Show();
            turnos.Activate();
            turnos.Focus();
            turnos.Topmost = true;
            InitializeComponent();
            ip.Text = Constants.IP.Substring(Constants.IP.Length-4);
            //reloadListCrear();
            frameMap.Content = mapa;
            client = new RestClient(Constants.IP);
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            crea = new CreacionDeCosas();
            if (crea == null)
            {
                this.crea = new CreacionDeCosas();
                crea.Show();
            }
            else if (!crea.IsActive && crea.ShowActivated)
            {
                crea.Close();
                this.crea = new CreacionDeCosas();
                crea.Show();
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            eliminar = new AsignarCosasPlayers();
            if (crea == null)
            {
                this.eliminar = new AsignarCosasPlayers();
                eliminar.Show();
            }
            else if (!eliminar.IsActive && eliminar.ShowActivated)
            {
                eliminar.Close();
                this.eliminar = new AsignarCosasPlayers();
                eliminar.Show();
            }
        }

        public void reloadListCrear() {
            foreach (Object obj in armas)
            {
                listCreados.Items.Add(obj);
            }
        }
        private void Perso_Click(object sender, RoutedEventArgs e)
        {
            perso = new TicketCharacter();
            if (perso == null)
            {
                this.perso = new TicketCharacter();
                perso.Show();
            }
            else if (!perso.IsActive && perso.ShowActivated)
            {
                perso.Close();
                this.perso = new TicketCharacter();
                perso.Show();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            caraceter = new CharacterShe();
            if (caraceter == null)
            {
                this.caraceter = new CharacterShe();
                caraceter.Show();
            }
            else if (!caraceter.IsActive && caraceter.ShowActivated)
            {
                caraceter.Close();
                this.caraceter = new CharacterShe();
                caraceter.Show();
            }
        }


        private string randomDice()
        {

            string s = "";
            int max = DiceNum + 1;
            Random random = new Random();
            s += random.Next(1, max);
            return s;
        }
        public void diceChange()
        {
            //Cuando el game master cambie el dice llama a esto en todos los jugadores
            switch (DiceNum)
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
            main = new MainWindow();
            main.Show();

        }

        private void moviment_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mapa.setMover();
        }

        private void sword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mapa.setAtaque();
            
        }

        public void recibirDaño(int daño, int enemigo) { 
            

        }

        private void diceController_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((diceController.Text == "" )||(diceController.Text == null))
            {
                return;
            }
            int dice=int.Parse(diceController.Text);
            diceSetterAsync(dice);

        }
        public async void diceSetterAsync(int dice)
        {
            int[] dicePost = { dice };
            var request = new RestRequest("singleton/dados", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);
            request.AddJsonBody(dicePost);
            var response = await client.ExecuteAsync(request);
            
            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
            UpdateDice();

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
            this.DiceNum = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(response.Content);
           
            diceChange();
        }

        private void dice_MouseDown(object sender, MouseButtonEventArgs e)
        {
            diceChange();
            Random random = new Random();

            Number.Text = randomDice();
        }
    }
}

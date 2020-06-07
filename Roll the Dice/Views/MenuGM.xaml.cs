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
        MainWindow main = new MainWindow();
        CreacionDeCosas crea= new CreacionDeCosas();
        AsignarCosasPlayers eliminar = new AsignarCosasPlayers();
        CharacterShe caraceter = new CharacterShe();
        Mapa mapa = new Mapa();
        public static List<string> armas = new List<string>();
        static List<Object> armaduras = new List<object>();
        static List<Object> items = new List<object>();
        static List<Object> npcMonstruos = new List<Object>();
        static List<Object> players = new List<object>();
        TicketCharacter perso = new TicketCharacter();
        private int DiceNum { get; set; }=6;

        public MenuGM()
        {
            TurnosGM turnos = new TurnosGM();
            turnos.Show();
            turnos.Activate();
            turnos.Focus();
            turnos.Topmost = true;
            InitializeComponent();
            //reloadListCrear();
            frameMap.Content = mapa;
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (crea.ShowActivated)
            {
                crea.Close();
            }
            this.crea = new CreacionDeCosas();
            crea.Show();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (eliminar.ShowActivated)
            {
                eliminar.Close();
            }
            this.eliminar = new AsignarCosasPlayers();
            eliminar.Show();
        }

        public void reloadListCrear() {
            foreach (Object obj in armas)
            {
                listCreados.Items.Add(obj);
            }
        }
        private void Perso_Click(object sender, RoutedEventArgs e)
        {
            if (perso.ShowActivated)
            {
                perso.Close();
            }
            this.perso = new TicketCharacter();
            perso.Show();

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (caraceter.ShowActivated)
            {
                caraceter.Close();
            }
            this.caraceter = new CharacterShe();
            caraceter.Show();

        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            diceChange();
            Random random = new Random();
         
                Number.Text = randomDice();
            
           

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
    }
}

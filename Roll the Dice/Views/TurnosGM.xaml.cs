using RestSharp;
using Roll_the_Dice.Models;
using Roll_the_Dice.Utils;
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

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para TurnosGM.xaml
    /// </summary>
    public partial class TurnosGM : Window
    {
        List<Usuario> playerList;
        List<ComboBox> comboboxes = new List<ComboBox>();
        RestClient client;
        List<int> orden = new List<int>();

        public TurnosGM()
        {
            InitializeComponent();
            dynamicCheckboxList();
        }

        private async void dynamicCheckboxList()
        {
            client = new RestClient(Constants.IP);
            var request = new RestRequest("usuarios/sala/{salaId}", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);
            request.AddParameter("salaId", Constants.Sala.salaId, ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            playerList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Usuario>>(response.Content);

            if (playerList.Count == 0)
            {
                //TODO - No existe ningun Usuario dentro de la sala
                return;
            }

            playerList.Add(Constants.Usuario);

            for (int i = 0; i < playerList.Count(); i++)
            {
                ComboBox combo = new ComboBox();
                combo.HorizontalContentAlignment = HorizontalAlignment.Center;

                foreach (var player in playerList) {
                    TextBlock text = new TextBlock();
                    text.Foreground = new SolidColorBrush(Colors.DarkGray);
                    text.Width = 70;
                    text.TextAlignment = TextAlignment.Left;
                    text.Text = player.nickname;
                    combo.Items.Add(text);
                }

                Grid grid = new Grid();
                ColumnDefinition col1 = new ColumnDefinition();
                col1.Width = new GridLength(40);
                ColumnDefinition col2 = new ColumnDefinition();
                col2.Width = new GridLength(80);
                ColumnDefinition col3 = new ColumnDefinition();
                col2.Width = new GridLength(250);
                grid.ColumnDefinitions.Add(col1);
                grid.ColumnDefinitions.Add(col2);
                grid.ColumnDefinitions.Add(col3);

                RowDefinition row1 = new RowDefinition();
                grid.RowDefinitions.Add(row1);

                Grid.SetRow(combo, 0);
                Grid.SetColumn(combo , 1);
                Grid.SetColumnSpan(combo, 2);
                grid.Children.Add(combo);

                Label label = new Label();
                label.Content = (i + 1) + " - ";
                label.Foreground = new SolidColorBrush(Colors.White);

                Grid.SetRow(label, 0);
                Grid.SetColumn(label , 0);
                grid.Children.Add(label);

                turnosList.Items.Add(grid);
                comboboxes.Add(combo);
            }
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            playerList.Clear();
            this.Close();
            TurnosGM turnos = new TurnosGM();
            turnos.Show();
            dynamicCheckboxList();
        }

        private async void Confirmar_Click(object sender, RoutedEventArgs e)
        {
            if (comboboxes.Any(q => q.Text == "")) return;
            foreach (ComboBox combobox in comboboxes)
            {
                orden.Add(playerList.FirstOrDefault(q => q.nickname == combobox.Text).usuarioId);
            }
            
            var request = new RestRequest("singleton/orden", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);

            request.AddJsonBody(orden.ToArray());

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Error en Peticion
                return;
            }

            Close();
        }
    }
}

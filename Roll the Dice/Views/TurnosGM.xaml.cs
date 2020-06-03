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
        List<String> itemList = new List<String>() { "1.-", "2.-", "3.-","4.-"};
        List<String> playerList = new List<String>() { "Ben", "Pepe", "Marta", "Veronica" };
        public TurnosGM()
        {
            InitializeComponent();
            dinamicCheckboxList();
        }

        private void dinamicCheckboxList()
        {
            //Acabar de mirar
            //var itemList = MenuGM.armas.ToList();
            foreach (var item in itemList)
            {
                ComboBox combo = new ComboBox();
                combo.HorizontalContentAlignment = HorizontalAlignment.Left;

                foreach (var player in playerList) {
                    TextBlock text = new TextBlock();
                    text.Foreground = new SolidColorBrush(Colors.Gray);
                    text.Width = 70;
                    text.TextAlignment = TextAlignment.Left;
                    text.Text = player.ToString();
                    combo.Items.Add(text);
                }

                Grid grid = new Grid();
                ColumnDefinition col1 = new ColumnDefinition();
                col1.Width = new GridLength(20);
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
                label.Content = item.ToString();
                label.Foreground = new SolidColorBrush(Colors.White);

                Grid.SetRow(label, 0);
                Grid.SetColumn(label , 0);
                grid.Children.Add(label);

                turnosList.Items.Add(grid);
            }
        }
    }
}

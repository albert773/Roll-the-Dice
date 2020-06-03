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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para Mapa.xaml
    /// </summary>
    public partial class Mapa : Page
    {
        List<ColumnDefinition> colList = new List<ColumnDefinition>();
        List<RowDefinition> rowList = new List<RowDefinition>();
        List<Button> buttonList = new List<Button>();
        List<Rectangle> rectangleList = new List<Rectangle>();
        const int X = 15;
        public Mapa()
        {
            InitializeComponent();
           
            for(int i=0; i< X; i++)
            {
                colList.Add(new ColumnDefinition());
                rowList.Add(new RowDefinition());
            }
            for (int i=0; i<colList.Count(); i++)
            {
                mapa.ColumnDefinitions.Add(colList[i]);
                mapa.RowDefinitions.Add(rowList[i]);
            }
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < X; y++)
                {
                    Button but = new Button();
                    but.Name = "b"+x+"b"+y;
                    but.Background = null;
                    but.Height = Double.NaN;
                    but.Width = Double.NaN;
                    but.Click += textSwap;
                    buttonList.Add(but);
                    Rectangle rec = new Rectangle();
                    rec.Name = "r" + x + "r" + y;
                    rec.Opacity = 0.3;
                    rec.Fill = Brushes.Red;
                    rec.Height = Double.NaN;
                    rec.Width = Double.NaN;
                    rectangleList.Add(rec);
                }
            }
            int buttonPos = 0;
            for(int x=0; x<X; x++)
            {
                for(int y=0; y<X; y++)
                {

                        Grid.SetColumn(rectangleList[buttonPos], x);
                        Grid.SetRow(rectangleList[buttonPos], y);
                        Grid.SetColumn(buttonList[buttonPos], x);
                        Grid.SetRow(buttonList[buttonPos], y);
                        buttonPos++;

                    
                }
            }
            for(int i=0; i<(X*X); i++)
            {
                mapa.Children.Add(rectangleList[i]);
                mapa.Children.Add(buttonList[i]);
            }

        }
        public void textSwap(object sender, RoutedEventArgs e)
        {
            var but = (Button)sender;
            but.Content = but.Name;
        }
    }
}

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
        int posX { get; set; }=5;
        int posY { get; set; }=5;
        int range = 5;
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
                    rectangleCreate(x, y);
                    buttonCreate(x, y);  
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
            rangePerso();

        }
        public void buttonCreate(int x, int y)
        {
            Button but = new Button();
            but.Name = "b" + x + "b" + y;
            but.Background = null;
            but.Height = Double.NaN;
            but.Width = Double.NaN;
           
            buttonList.Add(but);
        }
        public void rectangleCreate(int x, int y)
        {
            Rectangle rec = new Rectangle();
            rec.Name = "r" + x + "r" + y;
            rec.Opacity = 0.3;
            rec.Fill = null;
            rec.Height = Double.NaN;
            rec.Width = Double.NaN;
            rectangleList.Add(rec);
        }
        public void textSwap(object sender, RoutedEventArgs e)
        {
            var but = (Button)sender;
            but.Content = but.Name;
        }
        public void rangePerso()
        {
            int ubi = indexGetter(posX, posY);
            paintSquareYellow(ubi);
            for(int i=1; i<range+1; i++)
            {
                int p1, p2, p3, p4, p5, p6, p7, p8;
                p1=indexGetter(posX - i, posY);
                p2=indexGetter(posX, posY - i);
                p3=indexGetter(posX + i, posY);
                p4=indexGetter(posX, posY + i);
                p5=indexGetter(posX + i, posY + i);
                p6=indexGetter(posX - i, posY - i);
                p7= indexGetter(posX - i, posY + i);
                p8= indexGetter(posX + i, posY - i);
                int[] pList = { p1, p2, p3, p4, p5, p6, p7, p8 };
                for(int j = 0; j < pList.Length; j++)
                {
                    if (!(pList[j] < 0))
                    {
                        paintSquareRed(pList[j]);
                    }
                }
            }
        }
        public int indexGetter(int x, int y)
        {
            return ((y * 15) + x);

        }
        public void paintSquareYellow(int i)
        {
            rectangleList[i].Fill = Brushes.Yellow;
        }
        public void paintSquareRed(int i)
        {
            rectangleList[i].Fill = Brushes.Red;
        }

    }
}

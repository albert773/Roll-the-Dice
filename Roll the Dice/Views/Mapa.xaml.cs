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
        int disponibleMovement = 0;
        int posX { get; set; }=0;
        int posY { get; set; }=14;
        int range = 1;
        bool ataque = false;
        bool mover = false;
        bool habilidad = false;
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
            but.Name = "b" + indexGetter(x, y);
            but.Background = null;
            but.Height = Double.NaN;
            but.Width = Double.NaN;
            buttonList.Add(but);
        }
        public void rectangleCreate(int x, int y)
        {
            Rectangle rec = new Rectangle();
            rec.Name = "r"+indexGetter(x,y);
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
        public void paintSquareBlue(int i)
        {
            rectangleList[i].Fill = Brushes.Blue;
        }
        public void painterMachineRange(Boolean move)
        {
            for (int i = 1; i < range + 1; i++)
            {
            
                int p1, p2, p3, p4, p5, p6, p7, p8;
                if (posX - i >= 0)
                {
                    p1 = indexGetter(posX - i, posY);
                    if (move)
                    {
                        paintSquareBlue(p1);
                    }
                    else
                    {
                        paintSquareRed(p1);
                    }
                    
                }
                if (posY - i >= 0)
                {
                    p2 = indexGetter(posX, posY - i);
                    if (move)
                    {
                        paintSquareBlue(p2);
                    }
                    else
                    {
                        paintSquareRed(p2);
                    }
                }
                if (posX + i < 15)
                {
                    p3 = indexGetter(posX + i, posY);
                    if (move)
                    {
                        paintSquareBlue(p3);
                    }
                    else
                    {
                        paintSquareRed(p3);
                    }
                }
                if (posY + i < 15)
                {
                    p4 = indexGetter(posX, posY + i);
                    if (move)
                    {
                        paintSquareBlue(p4);
                    }
                    else
                    {
                        paintSquareRed(p4);
                    }
                }
                if (posX + i < 15 && posY + i < 15)
                {
                    p5 = indexGetter(posX + i, posY + i);
                    if (move)
                    {
                        paintSquareBlue(p5);
                    }
                    else
                    {
                        paintSquareRed(p5);
                    }
                }
                if (posX - i >= 0 && posY - i >= 0)
                {
                    p6 = indexGetter(posX - i, posY - i);
                    if (move)
                    {
                        paintSquareBlue(p6);
                    }
                    else
                    {
                        paintSquareRed(p6);
                    }
                }
                if (posX - i >= 0 && posY + i < 15)
                {
                    p7 = indexGetter(posX - i, posY + i);
                    if (move)
                    {
                        paintSquareBlue(p7);
                    }
                    else
                    {
                        paintSquareRed(p7);
                    }
                }
                if (posX + i < 15 && posY - i >= 0)
                {
                    p8 = indexGetter(posX + i, posY - i);
                    if (move)
                    {
                        paintSquareBlue(p8);
                    }
                    else
                    {
                        paintSquareRed(p8);
                    }
                }
            }
        }
        

        //CLICK PARA EL ICONO DE ATACAR
        public void setAtaque()
        {
            cleanRectangle();
            if (mover)
            {
                mover = false;
            }
            if (habilidad)
            {
                habilidad = false;
            }
            if (ataque)
            {
                ataque = false;
            }
            else
            {
                ataque = true;
                painterMachineRange(false);
            }
        }
        //CLICK PARA EL ICONO DE MOVER
        public void setMover()
        {
            cleanRectangle();
            if (ataque)
            {
                ataque = false;
            }
            if (habilidad)
            {
                habilidad = false;
            }
            if (mover)
            {
                mover = false;
            }
            else
            {
                mover = true;
                painterMachineRange(true);
            }
        }
        //CLICK PARA EL ICONO DE HABILIDAD
        public void setHabilidad()
        {
            cleanRectangle();
            if (ataque)
            {
                ataque = false;
            }
            if (mover)
            {
                mover = false;
            }
            if (habilidad)
            {
                habilidad = false;
            }
            else
            {
                habilidad = true;
                painterMachineRange(false);
            }
        }

        public void cleanRectangle()
        {
            for(int i=0; i<rectangleList.Count; i++)
            {
                rectangleList[i].Fill = null;
            }
        }

        public void isTurn()
        {
            disponibleMovement = 2;
        }

        public void hacerAtaque(int x, int y)
        {

        }
        public void tirarHabilidad(int x, int y)
        {

        }
        public void theButtonClicked(object sender, RoutedEventArgs e)
        {
            var but = (Button)sender;
            int index = int.Parse(but.Name);
            int x, y;
            if (!mover && !ataque && !habilidad)
            {

            }
            else
            {
                if (mover)
                {
                    if (rectangleList[index].Fill == Brushes.Blue)
                    {
                        y = 0; x = 0;
                        while (index % 15 == 0)
                        {
                            y++;
                            index = index - 15;
                        }
                        x = index;
                        posX = x; posY = y;
                        disponibleMovement--;
                        if (disponibleMovement > 0)
                        {
                            cleanRectangle();
                            painterMachineRange(true);
                        }
                    }
                }
                else if (ataque)
                {
                    if (rectangleList[index].Fill == Brushes.Red)
                    {
                        y = 0; x = 0;
                        while (index % 15 == 0)
                        {
                            y++;
                            index = index - 15;
                        }
                        x = index;
                        hacerAtaque(x, y);

                    }

                }
                else
                {
                    y = 0; x = 0;
                    while (index % 15 == 0)
                    {
                        y++;
                        index = index - 15;
                    }
                    x = index;
                    tirarHabilidad(x, y);
                }
            }
        }
    }
}

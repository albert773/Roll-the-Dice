using System.Windows;
using System.Windows.Navigation;

namespace Roll_the_Dice
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Main.Content = new Views.LogIn();
            Main.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
    }
}

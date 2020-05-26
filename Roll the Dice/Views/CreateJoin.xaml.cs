using System.Windows;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para CreateJoin.xaml
    /// </summary>
    public partial class CreateJoin : Window
    {
        public CreateJoin()
        {
            InitializeComponent();
        }

        private void ReturnLogin_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new LogIn(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }

        private void CreateSala_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Join(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }
    }
}

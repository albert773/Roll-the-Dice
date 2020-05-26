using System.Windows;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para Join.xaml
    /// </summary>
    public partial class Join : Window
    {
        public Join()
        {
            InitializeComponent();
        }

        private void CreateJoin_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new CreateJoin(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }
    }
}

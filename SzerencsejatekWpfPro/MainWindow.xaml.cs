using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SzerencsejatekWpfPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Container.Content = new Home();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Container.Content = new LogIn();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to exit the application?","Exit tha application",MessageBoxButton.YesNo,MessageBoxImage.Question);
            
        }
    }
}
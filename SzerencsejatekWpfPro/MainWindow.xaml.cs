using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
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
        List<Bettors> fogadok = new();
        public string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=fogadasok";
        private MySqlConnection connection;
        
        public MainWindow()
        {
            InitializeComponent();
            loadUsers();
            
        }

        private void loadUsers()
        {
            fogadok = new List<Bettors>();

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string lekerdezesSzoveg = "SELECT * FROM bettors ORDER BY BettorsID";

                MySqlCommand lekerdezes = new MySqlCommand(lekerdezesSzoveg, connection);
                lekerdezes.CommandTimeout = 60;
                MySqlDataReader reader = lekerdezes.ExecuteReader();
                while (reader.Read())
                {
                    fogadok.Add(new Bettors(reader));
                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
            MessageBox.Show("Are you sure you want to exit the application?","Exit the application",MessageBoxButton.YesNo,MessageBoxImage.Question);
            
        }
    }
}
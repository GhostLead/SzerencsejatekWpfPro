using MySql.Data.MySqlClient;
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

namespace SzerencsejatekWpfPro
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        List<Bettors> fogadok = new();
        public string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=fogadasok";
        private MySqlConnection? connection;
        public LogIn()
        {
            InitializeComponent();
            loadUsers();
            txtUsername.KeyDown += new KeyEventHandler(input_KeyDown);
            passPassword.KeyDown += new KeyEventHandler(input_KeyDown);
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
        private void checkUser()
        {
            bool vanNev = false;
            bool vanJelszo = false;
            bool isAdmin = false;
            bool isOrganizer = false;
            foreach (var user in fogadok)
            {
                if (user.username == txtUsername.Text && user.password == passPassword.Password)
                {
                    vanNev = true;
                    vanJelszo = true;
                    if (user.username == "admin")
                    {
                        isAdmin = true;
                    }
                    else if (user.username == "organizer")
                    {
                        isOrganizer = true;
                    }
                    break;

                }
                else if (user.username == txtUsername.Text && user.password != passPassword.Password)
                {
                    vanNev = true;
                    break;

                }
                else if (user.username != txtUsername.Text && user.password == passPassword.Password)
                {
                    vanJelszo = true;
                    break;

                }


            }
            if (isAdmin)
            {
                MessageBox.Show("Ügyi vagy admin");
                ApplicationWindow win = new ApplicationWindow();
                MainWindow mainwin = new MainWindow();
                win.Show();
                Application.Current.MainWindow.Close();
            }
            else if (isOrganizer)
            {
                MessageBox.Show("Ügyi vagy Ork");
                ApplicationWindow win = new ApplicationWindow();
                MainWindow mainwin = new MainWindow();
                win.Show();
                Application.Current.MainWindow.Close();
            }
            else if (vanNev && vanJelszo)
            {
                ApplicationWindow win = new ApplicationWindow();
                MainWindow mainwin = new MainWindow();
                win.Show();
                Application.Current.MainWindow.Close();
            }
            else if (vanNev && !vanJelszo)
            {
                MessageBox.Show("Hibás a jelszó!");
            }
            else if (!vanNev && vanJelszo)
            {
                MessageBox.Show("Hibás a felhasználónév!");
            }
            else
            {
                MessageBox.Show("Nincs regisztálva ilyen fiók!");
            }
        }
        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                checkUser();
            }
        }
        private void btnBejelentkezes_Click(object sender, RoutedEventArgs e)
        {
            checkUser();
        }
    }
    
}

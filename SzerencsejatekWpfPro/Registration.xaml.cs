using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace SzerencsejatekWpfPro
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=fogadasok";
        private MySqlConnection connection;
        List<Bettors> bettors;
        bool vanHiba = false;
        string hibaÜzenet = "";
        string nev = "";
        string email = "";
        string jelszo = "";
        public Registration()
        {
            InitializeComponent();
            loadUsers();
            txtUsername.KeyDown += new KeyEventHandler(input_KeyDown);
            passPassword.KeyDown += new KeyEventHandler(input_KeyDown);
            txtEmail.KeyDown += new KeyEventHandler(input_KeyDown);
        }
        private void userUpload()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string lekerdezesSzoveg = "INSERT INTO `bettors`(`Username`, `Password`, `Balance`, `Email`, `IsActive`) VALUES (@nev,@jelszo,'100',@email,true)";

                    using (var lekerdezes = new MySqlCommand(lekerdezesSzoveg, connection))
                    {
                        lekerdezes.CommandTimeout = 60;

                        // Paraméterek hozzáadása
                        lekerdezes.Parameters.AddWithValue("@nev", nev);
                        lekerdezes.Parameters.AddWithValue("@jelszo", jelszo);
                        lekerdezes.Parameters.AddWithValue("@email", email);


                        lekerdezes.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void loadUsers()
        {
            bettors = new List<Bettors>();

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
                    bettors.Add(new Bettors(reader));
                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void checkRegistration()
        {
            nev = txtUsername.Text;
            email = txtEmail.Text;
            jelszo = passPassword.Password;            
            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            List<string> nevek = new();
            List<string> emailCimek = new();
            hibaÜzenet = "";
            vanHiba = false;
            foreach (var item in bettors)
            {
                nevek.Add(item.username);
                emailCimek.Add(item.email);

            }
            if (nevek.Contains(nev) || nev == "")
            {
                hibaÜzenet += "\nMár van ilyen felhasználónév!";
                txtUsername.Focus();
                txtUsername.BorderBrush = Brushes.Red;
                vanHiba = true;
            }
            if (jelszo.Length < 8)
            {
                hibaÜzenet += "\nLegalább 8 karakternek kell lennie a jelszónak!";
                passPassword.Focus();
                passPassword.BorderBrush = Brushes.Red;
                vanHiba = true;
            }
            if (emailCimek.Contains(email) || email == "")
            {
                hibaÜzenet += "\nMár van ilyen email cím hozzárendelve egy fiókhoz!";
                txtEmail.Focus();
                txtEmail.BorderBrush = Brushes.Red;
                vanHiba = true;

            }
            if (!Regex.IsMatch(email, emailPattern))
            {
                hibaÜzenet += "\nHibás az email formátuma!";
                txtEmail.Focus();
                txtEmail.BorderBrush = Brushes.Red;
                vanHiba = true;
            }
            if (vanHiba)
            {
                MessageBox.Show(hibaÜzenet);
            }
            else {
                userUpload();
                MessageBox.Show("Köszönjük a regisztrálását!\nKöszönetünk jeleként jóváírtunk 100$ kezdő összeget a fiókján!");
                ApplicationWindow appwin = new ApplicationWindow();
                MainWindow win = new MainWindow();
                appwin.Show();
                Application.Current.MainWindow.Close();
            }

        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                checkRegistration();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            checkRegistration();
        }
    }
}

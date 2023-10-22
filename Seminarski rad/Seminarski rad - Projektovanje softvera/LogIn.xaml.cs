using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Seminarski_rad___Projektovanje_softvera
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
       
        public LogIn()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignIn window = new SignIn();
            window.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush b = new SolidColorBrush();
            b.Color = Colors.White;
            txtBlockPoruka.Foreground = b;
            
        }

        private void txtBlockPoruka_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush b = new SolidColorBrush();
            b.Color = Color.FromRgb(216,187,195);
            txtBlockPoruka.Foreground = b;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string ime=txtIme.Text;
            string password = passBoxPassword.Password.ToString();
            bool admin;
            bool Uspeo = false;
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT Username,Password,Admin FROM Korisnik", con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (ime == reader["Username"].ToString())
                    {
                        if(password==reader["Password"].ToString())
                        {
                            admin = Convert.ToBoolean(reader["Admin"]);
                            MainWindow window = new MainWindow(ime,admin);
                            window.Show();
                            Uspeo = true;
                            this.Close();
                            
                        }
                    }
                }
                if (Uspeo ==false)
                MessageBox.Show("Kombinacija imena i passworda ne postoji. Pokusajte ponovo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            
            
        }

        
    }
}

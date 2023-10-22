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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string ime = txtIme.Text;
            string password = passBoxPassword.Password.ToString();
            bool admin;
            bool postoji = false;
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
                        postoji = true;
                        MessageBox.Show("Ovaj username vec postoji!");
                    }
                }
              
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

            if (postoji == false)
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand("INSERT INTO Korisnik(Username,Password,Admin) VALUES('"+ime+"','"+password+"','"+false+"')", con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MainWindow window = new MainWindow(ime, false);
                    window.Show();
                    this.Close();

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

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LogIn window = new LogIn();
            window.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void txtBlockPoruka_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush b = new SolidColorBrush();
            b.Color = Colors.White;
            txtBlockPoruka.Foreground = b;

        }

        private void txtBlockPoruka_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush b = new SolidColorBrush();
            b.Color = Color.FromRgb(216, 187, 195);
            txtBlockPoruka.Foreground = b;
        }

       
    }
}

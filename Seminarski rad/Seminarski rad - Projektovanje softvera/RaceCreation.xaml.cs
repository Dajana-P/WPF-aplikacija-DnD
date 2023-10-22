using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace Seminarski_rad___Projektovanje_softvera
{
    /// <summary>
    /// Interaction logic for RaceCreation.xaml
    /// </summary>
    public partial class RaceCreation : Window
    {
        string username;
        bool admin;

        int BonusID;
        public RaceCreation(string username, bool admin)
        {
            InitializeComponent();
            this.username = username;
            this.admin = admin;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SQLMethods.PopuniTabelu(tabela, "Rasa");
            SQLMethods.PopuniCMB(cmbBonus, "Bonus", "Naziv");
            cmbBonus.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            CharacterCreationMenu CCMenu = new CharacterCreationMenu(username, admin);
            CCMenu.Show();
            this.Close();
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabela.SelectedIndex != -1)
                try
                {
                    DataRowView row = (DataRowView)tabela.SelectedItem;
                    txtRasaID.Text = row[0].ToString();
                    txtNaziv.Text = row[1].ToString();
                    BonusID = Convert.ToInt32(row[3]);
                    txtOpis.Text = row[2].ToString();
                    cmbBonus.SelectedItem = SQLMethods.PronadjiNestoPrekoID("Bonus", "BonusID", "Naziv", BonusID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Podaci nisu dobro uneti");
                }

        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "DELETE FROM Rasa WHERE RasaID='" + Convert.ToInt32(txtRasaID.Text) + "'";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podaci nisu dobro uneti");
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            SQLMethods.PopuniTabelu(tabela, "Rasa");
            IsprazniPolja();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "Update Rasa SET Naziv='" + txtNaziv.Text + "',Opis='" + txtOpis.Text + "',BonusID='" + BonusID + "' WHERE RasaID='" + Convert.ToInt32(txtRasaID.Text) + "'";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podaci nisu dobro uneti");
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            SQLMethods.PopuniTabelu(tabela, "Rasa");
            IsprazniPolja();
        }

        private void btnUnesi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "INSERT INTO Rasa(RasaID,Naziv,Opis,BonusID) VALUES('" + Convert.ToInt32(txtRasaID.Text) + "','" + txtNaziv.Text + "','" + txtOpis.Text + "','" + BonusID + "')";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podaci nisu dobro uneti");
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            SQLMethods.PopuniTabelu(tabela, "Rasa");
            IsprazniPolja();
        }

        private void txtOpis_TextChanged(object sender, TextChangedEventArgs e)
        {
            int brKaraktera = txtOpis.Text.Length;
            txtBrKaraktera.Text = "(" + (200 - brKaraktera).ToString() + ")";
        }

        private void txtRaceID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }


        private void txtOpis_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int brKaraktera = txtOpis.Text.Length;
            if (brKaraktera == 200 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }




        private void cmbBonus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BonusID = SQLMethods.PronadjiIDNecega("Bonus", "Naziv", cmbBonus.SelectedItem.ToString(), "BonusID");
        }

        private void IsprazniPolja()
        {
            txtRasaID.Text = "";
            txtNaziv.Text = "";
            cmbBonus.SelectedIndex = 0;
            txtOpis.Text = "";
        }
    }
}

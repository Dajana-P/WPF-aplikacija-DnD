using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ClassCreation.xaml
    /// </summary>
    public partial class ClassCreation : Window
    {
        string username;
        bool admin;
        int BonusID;
        public ClassCreation(string username, bool admin)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.username = username;
            this.admin = admin;

            cmbResurs.Items.Add("Mana");
            cmbResurs.Items.Add("Stamina");

            cmbSpecialAttack.Items.Add("Smite");
            cmbSpecialAttack.Items.Add("SniperShot");
            cmbSpecialAttack.Items.Add("Unrelenting Will");
            cmbSpecialAttack.Items.Add("Arcane Blast");
            cmbSpecialAttack.Items.Add("Sundering Strike");

            cmbBonus.SelectedIndex = 0;
            cmbResurs.SelectedIndex = 0;
            cmbSpecialAttack.SelectedIndex = 0;
            SQLMethods.PopuniTabelu(tabela, "Klasa");
            SQLMethods.PopuniCMB(cmbBonus, "Bonus", "Naziv");
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

        private void txtKolicina_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }


        private void btnUnesi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "INSERT INTO Klasa(KlasaID,Naziv,SpecialAttackName,Energija,KolicinaEnergije,BonusID) VALUES('" + Convert.ToInt32(txtID.Text) + "','" + txtNaziv.Text + "','" + cmbSpecialAttack.SelectedItem.ToString() + "', '" + cmbResurs.SelectedItem.ToString() + "','" + Convert.ToInt32(txtKolicina.Text) + "','" + BonusID + "')";
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
            SQLMethods.PopuniTabelu(tabela, "Klasa");
            IsprazniPolja();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "UPDATE Klasa SET Naziv='" + txtNaziv.Text + "',SpecialAttackName='" + cmbSpecialAttack.SelectedItem + "',Energija='" + cmbResurs.SelectedItem + "',KolicinaEnergije='" + Convert.ToInt32(txtKolicina.Text) + "',BonusID='" + BonusID + "' WHERE KlasaID='" + Convert.ToInt32(txtID.Text) + "'";
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
            SQLMethods.PopuniTabelu(tabela, "Klasa");
            IsprazniPolja();
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "DELETE FROM Klasa WHERE KlasaID='" + Convert.ToInt32(txtID.Text) + "'";
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
            SQLMethods.PopuniTabelu(tabela, "Klasa");
            IsprazniPolja();
        }

        private void txtID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void tabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabela.SelectedIndex != -1)
                try
                {
                    DataRowView row = (DataRowView)tabela.SelectedItem;
                    txtID.Text = row[0].ToString();
                    txtNaziv.Text = row[1].ToString();
                    cmbResurs.SelectedItem = row[2].ToString();
                    txtKolicina.Text = row[3].ToString();
                    cmbSpecialAttack.SelectedItem = row[4].ToString().Trim();
                    BonusID = Convert.ToInt32(row[5]);
                    cmbBonus.SelectedItem = SQLMethods.PronadjiNestoPrekoID("Bonus", "BonusID", "Naziv", BonusID);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
 
        private void cmbBonus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BonusID = SQLMethods.PronadjiIDNecega("Bonus","Naziv",cmbBonus.SelectedItem.ToString(),"BonusID");
        }

        private void IsprazniPolja()
        {
            txtID.Text = "";
            txtNaziv.Text = "";
            cmbBonus.SelectedIndex = 0;
            cmbResurs.SelectedIndex = 0;
            txtKolicina.Text = "";
            cmbSpecialAttack.SelectedIndex = 0;
        }
        
    }
}

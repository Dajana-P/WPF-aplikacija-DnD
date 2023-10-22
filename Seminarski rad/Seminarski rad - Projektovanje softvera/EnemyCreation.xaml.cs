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
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace Seminarski_rad___Projektovanje_softvera
{
    /// <summary>
    /// Interaction logic for EnemyCreation.xaml
    /// </summary>
    public partial class EnemyCreation : Window
    {
        string username;
        bool admin;
        private string pol;
        public EnemyCreation(string username, bool admin)
        {
            InitializeComponent(); 
            this.username = username;
            this.admin = admin;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> tipovi = new List<string>();
            tipovi.Add("Warrior");
            tipovi.Add("Mage");
            tipovi.Add("Beast");
            tipovi.Add("Paladin");
            tipovi.Add("Monster");
            tipovi.Add("Vampire");
            cmbTip.ItemsSource = tipovi;
            cmbTip.SelectedIndex = 0;
            rbMusko.IsChecked = true;
            string workingDirectory = Environment.CurrentDirectory;
            string[] fileArray = Directory.GetFiles(Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Images\Characters", "*.png");
            foreach (string putanja in fileArray)
            {
                string naziv = System.IO.Path.GetFileName(putanja);
                cmbSlika.Items.Add(naziv.Substring(0, naziv.Length - 4).Trim());

            }
            cmbSlika.SelectedIndex = 0;
            
            SQLMethods.PopuniTabelu(tabela, "Enemy");
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

        private void txtOpis_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            int brKaraktera = txtOpis.Text.Length;

            txtBrKaraktera.Text = "(" + (200 - brKaraktera).ToString() + ")";
        }

        private void rbMusko_Checked(object sender, RoutedEventArgs e)
        {
            pol = "Muško";
        }

        private void rbZensko_Checked(object sender, RoutedEventArgs e)
        {
            pol = "Žensko"; 
        }

        private void rbDrugo_Checked(object sender, RoutedEventArgs e)
        {
            pol = "Drugo";
        }

        private void txtEnemyID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void txtHealth_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void txtDefense_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void txtDamage_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void txtLevel_PreviewKeyDown(object sender, KeyEventArgs e)
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
                cmd.CommandText = "INSERT INTO Enemy(EnemyID,Ime,Pol,Tip,Slika,Health,Damage,Level,Opis,Defense) VALUES('" + Convert.ToInt32(txtEnemyID.Text) + "','" + txtIme.Text + "','" + pol + "','" + cmbTip.SelectedItem + "','" + cmbSlika.SelectedItem.ToString() + "','" + Convert.ToInt32(txtHealth.Text) + "','" + Convert.ToInt32(txtDamage.Text) + "','" + Convert.ToInt32(txtLevel.Text) + "','" + txtOpis.Text + "','" + Convert.ToInt32(txtDefense.Text) + "')";
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
            SQLMethods.PopuniTabelu(tabela, "Enemy");
            IsprazniPolja();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "UPDATE Enemy SET Ime='" + txtIme.Text + "',Pol='" + pol + "',Tip='" + cmbTip.SelectedItem.ToString() + "',Slika='" + cmbSlika.SelectedItem.ToString() + "',Health='" + Convert.ToInt32(txtHealth.Text) + "',Opis='" + txtOpis.Text + "',Defense='" + Convert.ToInt32(txtDefense.Text) + "' WHERE EnemyID='" + txtEnemyID.Text + "'";
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
            SQLMethods.PopuniTabelu(tabela, "Enemy");
            IsprazniPolja();
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "DELETE FROM Enemy WHERE EnemyID='" + Convert.ToInt32(txtEnemyID.Text) + "'";
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
            SQLMethods.PopuniTabelu(tabela, "Enemy");
            IsprazniPolja();
        }

        private void cmbSlika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommonMethods.LoadImage(imgEnemy, cmbSlika.SelectedItem.ToString());
        }

        private void tabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabela.SelectedIndex != -1)
                try
                {
                    DataRowView row = (DataRowView)tabela.SelectedItem;
                    txtEnemyID.Text = row[0].ToString();
                    txtIme.Text = row[1].ToString();
                    switch (row[2].ToString())
                    {
                        case "Muško": rbMusko.IsChecked = true; break;

                        case "Žensko": rbZensko.IsChecked = true; break;

                        case "Drugo": rbDrugo.IsChecked = true; break;
                    }
                    cmbTip.SelectedItem = row[3].ToString();
                    cmbSlika.SelectedItem = row[4].ToString().Trim();
                    txtHealth.Text = row[5].ToString();
                    txtDamage.Text = row[6].ToString();
                    txtLevel.Text = row[7].ToString();
                    txtOpis.Text = row[8].ToString();
                    txtDefense.Text = row[9].ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void txtOpis_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            int brKaraktera = txtOpis.Text.Length;
            if (brKaraktera == 200 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void IsprazniPolja()
        {
            txtEnemyID.Text = "";
            txtIme.Text = "";
            cmbTip.SelectedIndex = 0;
            txtHealth.Text = "";
            txtDefense.Text = "";
            txtDamage.Text = "";
            txtLevel.Text = "";
            txtOpis.Text = "";
            cmbSlika.SelectedIndex = 0;
            rbMusko.IsChecked = true;
        }
    }
}

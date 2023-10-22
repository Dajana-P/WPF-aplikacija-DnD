using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Seminarski_rad___Projektovanje_softvera
{
    /// <summary>
    /// Interaction logic for ItemCreation.xaml
    /// </summary>
    
    public partial class ItemCreation : Window
    {
        public List<string> ItemTipovi = new List<string>();
        public List<string> itemSlike = new List<string>();
        string username;
        bool admin;
        public ItemCreation(string username, bool admin)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.username = username;
            this.admin = admin;
            ItemTipovi.Add("Sword");
            ItemTipovi.Add("Staff");
            ItemTipovi.Add("Potion of Healing");
            ItemTipovi.Add("Gauntlet");
            ItemTipovi.Add("Potion of Power");
            ItemTipovi.Add("Bow");
            ItemTipovi.Add("Hammer");
            ItemTipovi.Add("Armor");
            string workingDirectory = Environment.CurrentDirectory;
            string[] fileArray = Directory.GetFiles(Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Images\Items", "*.png");
            foreach (string putanja in fileArray)
            {
                string naziv = System.IO.Path.GetFileName(putanja);
                cmbSlika.Items.Add(naziv.Substring(0, naziv.Length - 4).Trim());

            }
            cmbTip.ItemsSource = ItemTipovi;
            cmbSlika.SelectedIndex = 0;
            cmbTip.SelectedIndex = 0;
            SQLMethods.PopuniTabelu(tabela, "Item");
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

        private void slCena_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtCena.Text = Math.Round(slCena.Value).ToString();
        }

        private void txtCena_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int cena;
                cena = Convert.ToInt32(txtCena.Text);
                if (cena > 100)
                {
                    cena = 100;
                    slCena.Value = cena;
                    txtCena.Text = cena.ToString();
                }
                else if (cena < 0)
                {
                    cena = 0;
                    slCena.Value = cena;
                    txtCena.Text = cena.ToString();
                }
                else
                {
                    slCena.Value = cena;
                }
            }
            catch (Exception ex)
            {
                if (txtCena.Text.Length == 1 || txtCena.Text.Length == 0)
                {
                    txtCena.Text = "";
                }
                else
                {
                    txtCena.Text = txtCena.Text.Remove(txtCena.Text.Length - 1);
                }
            }
        }

        private void txtCena_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void txtOpis_TextChanged(object sender, TextChangedEventArgs e)
        {
            int brKaraktera = txtOpis.Text.Length;
            txtBrKaraktera.Text = "(" + (200 - brKaraktera).ToString() + ")";
        }

        private void txtID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void txtVrednost_PreviewKeyDown(object sender, KeyEventArgs e)
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
                cmd.CommandText = "INSERT INTO Item(ItemID,Naziv,Tip,Vrednost,Slika,Opis,Cena,Potrosnost) VALUES('" + Convert.ToInt32(txtID.Text) + "','" + txtNaziv.Text + "','" + cmbTip.SelectedItem.ToString() + "','" + Convert.ToInt32(txtVrednost.Text) + "','" + cmbSlika.SelectedItem.ToString() + "','" + txtOpis.Text + "','" + Convert.ToInt32(txtCena.Text) + "','" + checkPotrosnost.IsChecked + "')";
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
            SQLMethods.PopuniTabelu(tabela,"Item");
            IsprazniPolja();
        }

        private void cmbSlika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommonMethods.LoadImage(imgItem, cmbSlika.SelectedItem.ToString());
        }

        private void tabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabela.SelectedIndex != -1)
                try
            {
                DataRowView row = (DataRowView)tabela.SelectedItem;
                txtID.Text = row[0].ToString();
                txtNaziv.Text = row[1].ToString();
                cmbTip.SelectedItem = row[2].ToString();
                txtVrednost.Text= row[3].ToString();
                cmbSlika.SelectedItem = row[4].ToString().Trim();
                txtOpis.Text = row[5].ToString();
                txtCena.Text = row[6].ToString();
                checkPotrosnost.IsChecked =(bool) row[7];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "UPDATE Item SET Naziv='" + txtNaziv.Text + "',Tip='" + cmbTip.SelectedItem.ToString() + "',Vrednost='" + Convert.ToInt32(txtVrednost.Text) + "',Slika='" + cmbSlika.SelectedItem.ToString() + "',Opis='" + txtOpis.Text + "',Cena='" + Convert.ToInt32(txtCena.Text) + "',Potrosnost='" + checkPotrosnost.IsChecked + "' WHERE ItemID='" + txtID.Text + "'";
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
            SQLMethods.PopuniTabelu(tabela, "Item");
            IsprazniPolja();
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "DELETE FROM Item WHERE ItemID='" + Convert.ToInt32(txtID.Text) + "'";
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
            SQLMethods.PopuniTabelu(tabela, "Item");
            IsprazniPolja();
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
            txtID.Text = "";
            txtNaziv.Text = "";
            cmbTip.SelectedIndex = 0;
            txtVrednost.Text = "";
            txtCena.Text = "0";
            txtOpis.Text = "";
            cmbSlika.SelectedIndex = 0;
        }
    }
}

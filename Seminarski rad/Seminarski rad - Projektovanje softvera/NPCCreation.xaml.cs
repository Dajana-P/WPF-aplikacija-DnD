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
using System.Data;
using System.IO;

namespace Seminarski_rad___Projektovanje_softvera
{
    /// <summary>
    /// Interaction logic for NPCCreation.xaml
    /// </summary>
    public partial class NPCCreation : Window
    {
        string username;
        bool admin;
        private string pol;
        public NPCCreation(string username, bool admin)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.username = username;
            this.admin = admin;

            List<string> delatnosti = new List<string>();
            delatnosti.Add("Blacksmith");
            delatnosti.Add("Merchant");
            delatnosti.Add("Quest Giver");
            rbMusko.IsChecked = true;
            string workingDirectory = Environment.CurrentDirectory;
            string[] fileArray = Directory.GetFiles(Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Images\Characters", "*.png");
            foreach (string putanja in fileArray)
            {
                string naziv = System.IO.Path.GetFileName(putanja);
                cmbSlika.Items.Add(naziv.Substring(0, naziv.Length - 4).Trim());

            }
            cmbDelatnost.ItemsSource = delatnosti;
            cmbSlika.SelectedIndex = 0;
            SQLMethods.PopuniTabelu(tabela, "NPC");
            cmbDelatnost.SelectedIndex = 0;
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
                if(cena > 100)
                {
                    cena = 100;
                    slCena.Value = cena;
                    txtCena.Text = cena.ToString();
                }
                else if(cena < 0)
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

        private void txtNPCID_PreviewKeyDown(object sender, KeyEventArgs e)
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
                cmd.CommandText = "INSERT INTO NPC(NPCID,Ime,Prezime,Pol,Delatnost,Slika,Opis,Cena) VALUES('" + txtNPCID.Text + "','" + txtIme.Text + "','" + txtPrezime.Text + "','" + pol + "','" + cmbDelatnost.SelectedItem + "','" + cmbSlika.SelectedItem.ToString() + "','" + txtOpis.Text + "','" + Convert.ToInt32(txtCena.Text) + "')";
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
            SQLMethods.PopuniTabelu(tabela, "NPC");
            IsprazniPolja();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "UPDATE NPC SET Ime='" + txtIme.Text + "',Prezime='" + txtPrezime.Text + "',Pol='" + pol + "',Delatnost='" + cmbDelatnost.SelectedItem + "',Slika='" + cmbSlika.SelectedItem.ToString() + "',Opis='" + txtOpis.Text + "',Cena='" + Convert.ToInt32(txtCena.Text) + "' WHERE NPCID='" + txtNPCID.Text + "'";
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
            SQLMethods.PopuniTabelu(tabela, "NPC");
            IsprazniPolja();
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "DELETE FROM NPC WHERE NPCID='" + Convert.ToInt32(txtNPCID.Text) + "'";
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
            SQLMethods.PopuniTabelu(tabela, "NPC");
            IsprazniPolja();
        }

        private void cmbSlika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommonMethods.LoadImage(imgChar, cmbSlika.SelectedItem.ToString());
        }

        private void tabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabela.SelectedIndex != -1)
                try
                {
                    DataRowView row = (DataRowView)tabela.SelectedItem;
                    txtNPCID.Text = row[0].ToString();
                    txtIme.Text = row[1].ToString();
                    txtPrezime.Text = row[2].ToString();
                    switch(row[3].ToString())
                    {
                        case "Muško": rbMusko.IsChecked = true;break;

                        case "Žensko": rbZensko.IsChecked = true;break;

                        case "Drugo": rbDrugo.IsChecked = true;break;
                    }
                    cmbDelatnost.SelectedItem = row[4].ToString();
                    cmbSlika.SelectedItem = row[5].ToString().Trim();
                    txtOpis.Text = row[6].ToString();
                    txtCena.Text = row[7].ToString();
                    
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
            txtNPCID.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            cmbDelatnost.SelectedIndex = 0;
            txtCena.Text = "0";
            txtOpis.Text = "";
            cmbSlika.SelectedIndex = 0;
            rbMusko.IsChecked = true;
        }
    }
    
}

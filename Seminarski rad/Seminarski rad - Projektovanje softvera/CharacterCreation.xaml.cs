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
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Seminarski_rad___Projektovanje_softvera
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
   
    public partial class CharacterCreation : Window
    {
        int RaceBonusID;
        int ClassBonusID;
        int UkupanBrojPoena;
        int IskoriscenBrojPoena;
        string pol;

        string username;
        bool admin;

        public CharacterCreation(string username,bool admin)
        {
            InitializeComponent();
            this.username = username;
            this.admin = admin;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SQLMethods.PopuniCMB(cmbKlasa, "Klasa", "Naziv");
            SQLMethods.PopuniCMB(cmbRace, "Rasa", "Naziv");
            rbMusko.IsChecked = true;
            string workingDirectory = Environment.CurrentDirectory;
            string[] fileArray = Directory.GetFiles(Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Images\Characters", "*.png");
            foreach (string putanja in fileArray)
            {
                string naziv = System.IO.Path.GetFileName(putanja);
                cmbSlika.Items.Add(naziv.Substring(0, naziv.Length - 4).Trim());

            }
            cmbSlika.SelectedIndex = 0;
            SQLMethods.PopuniTabelu(tabela, "Karakter");
            UkupanBrojPoena = 8;
            IskoriscenBrojPoena = 0;
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

        private void btnUnesi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "INSERT INTO Karakter(KarakterID,Ime,Prezime,Pol,Starost,Opis,Slika,Strength,Athletics,Wisdom,Charisma,Username,RasaID,KlasaID) VALUES('" + Convert.ToInt32(txtCharID.Text) + "','" + txtIme.Text + "','" + txtPrezime.Text + "','" + pol + "','" + Convert.ToInt32(txtStarost.Text) + "','" + txtOpis.Text + "','" + cmbSlika.Text.ToString() + "','" + Convert.ToInt32(txtSTR.Text) + "','" + Convert.ToInt32(txtATH.Text) + "','" + Convert.ToInt32(txtWIS.Text) + "'," + Convert.ToInt32(txtCHA.Text) + ",'" + username + "','" + Convert.ToInt32(RaceBonusID) + "','" + ClassBonusID + "')";
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
            SQLMethods.PopuniTabelu(tabela, "Karakter");
            IsprazniPolja();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "SELECT Username FROM Karakter WHERE KarakterID='" + Convert.ToInt32(txtCharID.Text) + "'";
                cmd.Connection = con;
                con.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string tempUsername = reader["Username"].ToString();
                cmd.Dispose();
                reader.Close();
                if (username == tempUsername || admin == true)
                {
                    cmd.CommandText = "UPDATE Karakter SET Ime='" + txtIme.Text + "',Prezime='" + txtPrezime.Text + "',Pol='" + pol + "',Starost='" + Convert.ToInt32(txtStarost.Text) + "',Opis='" + txtOpis.Text + "',Slika='" + cmbSlika.SelectedItem.ToString() + "',Strength='" + Convert.ToInt32(txtSTR.Text) + "',Athletics='" + Convert.ToInt32(txtATH.Text) + "',Wisdom='" + Convert.ToInt32(txtWIS.Text) + "',Charisma='" + Convert.ToInt32(txtCHA.Text) + "',RasaID='" + RaceBonusID + "',KlasaID='" + ClassBonusID + "' WHERE KarakterID='" + Convert.ToInt32(txtCharID.Text) + "'";
                    cmd.ExecuteScalar();
                }
                else
                {
                    MessageBox.Show("Nemate dozvolu da menjate ovog karaktera!");
                }
             
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
           
            SQLMethods.PopuniTabelu(tabela, "Karakter");
            IsprazniPolja();
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SELECT Username FROM Karakter WHERE KarakterID='" + Convert.ToInt32(txtCharID.Text) + "'";
                cmd.Connection = con;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string tempUsername = reader["Username"].ToString();
                cmd.Dispose();
                reader.Close();
                if (username == tempUsername || admin == true)
                {
                    cmd.CommandText = "DELETE FROM Karakter WHERE KarakterID='" + Convert.ToInt32(txtCharID.Text) + "'";
                    cmd.ExecuteScalar();
                }
                else
                {
                    MessageBox.Show("Nemate dozvolu da brišete ovog karaktera!");
                }
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
            SQLMethods.PopuniTabelu(tabela, "Karakter");
            IsprazniPolja();
          
        }

        private void tabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabela.SelectedIndex != -1)
                try
                {
                    DataRowView row = (DataRowView)tabela.SelectedItem;
                    txtCharID.Text = row[0].ToString();
                    txtIme.Text = row[1].ToString();
                    txtPrezime.Text = row[2].ToString();
                    switch (row[3].ToString())
                    {
                        case "Muško": rbMusko.IsChecked = true; break;

                        case "Žensko": rbZensko.IsChecked = true; break;

                        case "Drugo": rbDrugo.IsChecked = true; break;
                    }
                    txtStarost.Text = row[4].ToString();
                    txtOpis.Text = row[5].ToString();
                    cmbSlika.SelectedItem = row[6].ToString();
                    txtSTR.Text = row[7].ToString();
                    txtATH.Text = row[8].ToString();
                    txtWIS.Text = row[9].ToString();
                    txtCHA.Text = row[10].ToString();
                    IskoriscenBrojPoena = Convert.ToInt32(row[7]) + Convert.ToInt32(row[8]) + Convert.ToInt32(row[9]) + Convert.ToInt32(row[10]);
                    txtBlockPoruka.Text = "Preostali broj poena: " + (8 - IskoriscenBrojPoena);

                    int KlasaID = Convert.ToInt32(row[12]);
                    int RasaID = Convert.ToInt32(row[13]);
                    cmbRace.SelectedItem = SQLMethods.PronadjiNestoPrekoID("Rasa", "RasaID", "Naziv", RasaID);
                    cmbKlasa.SelectedItem = SQLMethods.PronadjiNestoPrekoID("Klasa", "KlasaID", "Naziv", KlasaID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        
        private void PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void txtStarost_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int starost = Convert.ToInt32(txtStarost.Text);
                if (starost > 1000)
                    txtStarost.Text = "1000";
            }
            catch(Exception ex)
            {

            }
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

        private void cmbSlika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommonMethods.LoadImage(imgKarakter, cmbSlika.SelectedItem.ToString());
        }

     

        private void txtWIS_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txtOpis_TextChanged(object sender, TextChangedEventArgs e)
        {

            int brKaraktera = txtOpis.Text.Length;
            txtBrKaraktera.Text = "(" + (200 - brKaraktera).ToString() + ")";
        }
        private void txtOpis_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int brKaraktera = txtOpis.Text.Length;
            if (brKaraktera == 200 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void cmbKlasa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClassBonusID = SQLMethods.PronadjiIDNecega("Klasa", "Naziv", cmbKlasa.SelectedItem.ToString(), "KlasaID");
        }

        private void cmbRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaceBonusID = SQLMethods.PronadjiIDNecega("Rasa", "Naziv", cmbRace.SelectedItem.ToString(), "RasaID");
        }

        private void btnIncreaseATH_Click(object sender, RoutedEventArgs e)
        {
            PovecajAtribut(txtATH);
        }

        private void btnIncreaseCHA_Click(object sender, RoutedEventArgs e)
        {
            PovecajAtribut(txtCHA);
        }

        private void btnIncreaseWIS_Click(object sender, RoutedEventArgs e)
        {
            PovecajAtribut(txtWIS);
        }

        private void btnIncreaseSTR_Click(object sender, RoutedEventArgs e)
        {
            PovecajAtribut(txtSTR);
        }

        private void btnDecreaseSTR_Click(object sender, RoutedEventArgs e)
        {
            SmanjiAtribut(txtSTR);
        }

        private void btnDecreaseATH_Click(object sender, RoutedEventArgs e)
        {
            SmanjiAtribut(txtATH);
        }

        private void btnDecreaseCHA_Click(object sender, RoutedEventArgs e)
        {
            SmanjiAtribut(txtCHA);
        }

        private void btnDecreaseWIS_Click(object sender, RoutedEventArgs e)
        {
            SmanjiAtribut(txtWIS);
        }

        private void PovecajAtribut(TextBox txt)
        {
            if(IskoriscenBrojPoena<UkupanBrojPoena)
            {
                IskoriscenBrojPoena++;
                txt.Text = (Convert.ToInt32(txt.Text) + 1).ToString();
                txtBlockPoruka.Text = "Preostali broj poena: " + (8 - IskoriscenBrojPoena);
            }
        }

        private void SmanjiAtribut(TextBox txt)
        {
            if((Convert.ToInt32(txt.Text)>0))
            {
                IskoriscenBrojPoena--;
                txt.Text = (Convert.ToInt32(txt.Text) - 1).ToString();
                txtBlockPoruka.Text = "Preostali broj poena: " + (8 - IskoriscenBrojPoena);
            }
        }

        private void IsprazniPolja()
        {
            txtCharID.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtStarost.Text = "";
            txtSTR.Text = "0";
            txtATH.Text = "0";
            txtWIS.Text = "0";
            txtCHA.Text = "0";
            cmbKlasa.SelectedIndex = 0;
            cmbRace.SelectedIndex = 0;
            cmbSlika.SelectedIndex = 0;
            txtOpis.Text = "";
            IskoriscenBrojPoena = 0;
            txtBlockPoruka.Text= "Preostali broj poena: " + (8 - IskoriscenBrojPoena);
            rbMusko.IsChecked = true;
        }
    }
}

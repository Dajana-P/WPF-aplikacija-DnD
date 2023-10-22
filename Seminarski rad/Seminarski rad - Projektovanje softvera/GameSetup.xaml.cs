using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for GameSetup.xaml
    /// </summary>
    public partial class GameSetup : Window
    {
        string username;
        bool admin;
        public GameSetup(string username,bool admin)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.username = username;
            this.admin = admin;
            cmbTezina.Items.Add("Easy");
            cmbTezina.Items.Add("Normal");
            cmbTezina.Items.Add("Hard");
            SQLMethods.PopuniTabeluKarakteraZaUsername(tabela, username);
            cmbTezina.SelectedIndex = 0;
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            int KlasaBonusID = 0;
            int RasaBonusID = 0;
            if (tabela.SelectedIndex != -1)
            {
                SqlConnection con = new SqlConnection(SQLMethods.ConnString);
                SqlCommand cmd = new SqlCommand();
                try
                {
                    DataRowView row = (DataRowView)tabela.SelectedItem;
                    int hp = 0;
                    switch (cmbTezina.SelectedItem)
                    {
                        case "Easy": hp = 45; break;
                        case "Normal": hp = 30; break;
                        case "Hard": hp = 20; break;
                    }
                    string connectionString = SQLMethods.ConnString;


                    cmd.CommandText = "select Naziv,Energija,KolicinaEnergije,SpecialAttackName,BonusID from Klasa WHERE KlasaID='" + Convert.ToInt32(row[13]) + "'";
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    Klasa klasa = new Klasa(reader["Naziv"].ToString(), reader["SpecialAttackName"].ToString(), reader["Energija"].ToString(), Convert.ToInt32(reader["KolicinaEnergije"]));
                    KlasaBonusID = Convert.ToInt32(reader["BonusID"]);
                    cmd.Dispose();
                    reader.Close();
                    Igrac igrac = new Igrac(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), Convert.ToInt32(row[4]), klasa, row[5].ToString(), row[6].ToString(), row[3].ToString(), Convert.ToInt32(row[7]), Convert.ToInt32(row[8]), Convert.ToInt32(row[9]), Convert.ToInt32(row[10]), hp);
                    cmd.CommandText = "select Naziv,Kolicina from Bonus WHERE BonusID='" + KlasaBonusID + "'";
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    switch (reader["Naziv"].ToString())
                    {
                        case "Health": igrac.MaxHP += Convert.ToInt32(reader["Kolicina"]); igrac.HP += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Defense": igrac.defense += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Strenght": igrac.STR += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Athletics": igrac.ATH += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Wisdom": igrac.WIS += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Charisma": igrac.CHA += Convert.ToInt32(reader["Kolicina"]); break;
                    }
                    cmd.Dispose();
                    reader.Close();
                    cmd.CommandText = "select Naziv,BonusID from Rasa WHERE RasaID='" + Convert.ToInt32(row[12]) + "'";
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    igrac.rasa = reader["Naziv"].ToString();
                    RasaBonusID = Convert.ToInt32(reader["BonusID"]);
                    cmd.Dispose();
                    reader.Close();
                    cmd.CommandText = "select Naziv,Kolicina from Bonus WHERE BonusID='" + RasaBonusID + "'";
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    switch (reader["Naziv"].ToString())
                    {
                        case "Health": igrac.MaxHP += Convert.ToInt32(reader["Kolicina"]); igrac.HP += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Defense": igrac.defense += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Strenght": igrac.STR += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Athletics": igrac.ATH += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Wisdom": igrac.WIS += Convert.ToInt32(reader["Kolicina"]); break;
                        case "Charisma": igrac.CHA += Convert.ToInt32(reader["Kolicina"]); break;
                    }

                    Game window = new Game(igrac,username,admin);
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
            else
            {
                MessageBox.Show("Molimo vas izaberite karaktera!");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(username,admin);
            window.Show();
            this.Close();
        }

    }
}

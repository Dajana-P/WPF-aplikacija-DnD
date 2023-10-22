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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
       
        public Igrac igrac;
        public Enemy protivnik;
        public string username;
        public bool admin;
           
        public Game(Igrac igrac,string username,bool admin)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.username = username;
            this.admin = admin;
            this.igrac = igrac;
            UpdatePlayerInfo();
            CommonMethods.LoadImage(imgSlikaKaraktera, igrac.slika);
            Item startingBlade = new Item("Obican mač","Sword",3, "Najobičniji mač", 10,false);
            Item startingArmor = new Item("Kožna jakna", "Armor", 1, "Bolje išta nego ništa", 5, false);
            igrac.Items.Add(startingBlade);
            igrac.Items.Add(startingArmor);
            igrac.EquipedWeapon = igrac.Items[0];
            igrac.EquipedArmor = igrac.Items[1];
            StvoriEnemija();
            contentControl.Content = new CombatUserControl(protivnik, igrac, this);
        }
        public void UpdatePlayerInfo()
        {
            lbIme.Text = igrac.ime + " " + igrac.prezime;
            lbHP.Text = igrac.HP.ToString();
            lbDefense.Text = igrac.defense.ToString();
            lbMoney.Text = igrac.money.ToString();
            lbStrenght.Text = igrac.STR.ToString();
            lbWisdom.Text = igrac.WIS.ToString();
            lbCharisma.Text = igrac.CHA.ToString();
            lbAtheltics.Text = igrac.ATH.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void StvoriEnemija()
        {
            List<int> EnemyIDs = new List<int>();
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select EnemyID from Enemy";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                EnemyIDs.Add(Convert.ToInt32(reader["EnemyID"]));
                cmd.Dispose();
                reader.Close();
                Random rand = new Random();
                if (EnemyIDs.Count != 0)
                {
                    int ID = EnemyIDs[rand.Next(0, EnemyIDs.Count)];
                    cmd.CommandText = "select Ime,Pol,Tip,Slika,Health,Damage,Level,Opis,Defense,Slika from Enemy WHERE EnemyID='" + ID + "'";
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    protivnik = new Enemy(ID, reader["Ime"].ToString(), Convert.ToInt32(reader["Health"]), Convert.ToInt32(reader["Defense"]), Convert.ToInt32(reader["Damage"]), Convert.ToInt32(reader["Level"]), reader["Opis"].ToString(), reader["Pol"].ToString(), reader["Tip"].ToString(), reader["Slika"].ToString());
                }
                else
                {
                    protivnik = new Enemy(-1, "Obican ratnik", 25, 15, 3, 1, "Obican ratnik, jer nema nijednog ubacenog enemy", "Muško", "Warrior", "Garen");
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
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(username, admin);
            window.Show();
            this.Close();
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Seminarski_rad___Projektovanje_softvera
{
    /// <summary>
    /// Interaction logic for CombatUserControl.xaml
    /// </summary>
    public partial class CombatUserControl : UserControl
    {
        private DispatcherTimer timer = new DispatcherTimer();
        Random rand = new Random();

        private const int CritDamageMultiplier = 2;
        private const int DefenseValue = 3;
        private const int DefenseDamageReduction = 3;
        private bool DefenseUsed = false;

        Game GameWindow;
        Igrac igrac;
        Enemy protivnik;
        public CombatUserControl(Enemy protivnik, Igrac igrac, Game GameWindow)
        {
            InitializeComponent();
            lbHP.Text = protivnik.HP.ToString();
            this.igrac = igrac;
            this.protivnik = protivnik;
            this.GameWindow = GameWindow;
            CommonMethods.LoadImage(imgEnemyPic, protivnik.slika);
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            Action("Attack");
        }

        private void btnDefense_Click(object sender, RoutedEventArgs e)
        {
            Action("Defense");
        }
        void Action(string ActionType)
        {
            if (ActionType == "Attack")
                Attack();
            else if (ActionType == "Defense")
                Defense();

            GameWindow.UpdatePlayerInfo();
            FreezeGameState();
            if (protivnik.HP <= 0)
            {
                protivnik.HP = 0;
                GameWindow.listBoxLinije.Items.Add(protivnik.ime + " je umro");
                if(MessageBox.Show("Pobedili ste protivnika. Hvala vam što ste igrali demo verziju igre.","Kraj",MessageBoxButton.OK)==MessageBoxResult.OK)
                {
                    MainWindow window = new MainWindow(GameWindow.username, GameWindow.admin);
                    window.Show();
                    GameWindow.Close();
                }
                //UnFreezeGameState();
            }
            else
            {
                timerForAttack();
            }
            lbHP.Text = protivnik.HP.ToString();
        }
        private void Attack()
        {
            int Bonus = 0;
            if (igrac.EquipedWeapon.tip == "Sword" || igrac.EquipedWeapon.tip == "Hammer" || igrac.EquipedWeapon.tip == "Bow")
                Bonus = igrac.STR;
            else if (igrac.EquipedWeapon.tip == "Staff" || igrac.EquipedWeapon.tip == "SpellBook")
                Bonus = igrac.WIS;

            int roll = rand.Next(1, 21);
            if (roll + Bonus >= protivnik.defense)
            {
                int damage = Bonus + igrac.EquipedWeapon.vrednost + rand.Next(1, 7);
                if (roll == 20)
                {
                    damage *= CritDamageMultiplier;
                    GameWindow.listBoxLinije.Items.Add("Napad je bio veoma efektivan");
                }
                protivnik.HP -= damage;
                GameWindow.listBoxLinije.Items.Add(igrac.ime + " je uradi" + GenderPronouns.KrajReci(igrac.pol) + " " + damage + " damage");
            }
            else
            {
                GameWindow.listBoxLinije.Items.Add(igrac.ime + " je promasi" + GenderPronouns.KrajReci(igrac.pol) + " napad");
            }
        }
        void Defense()
        {
            igrac.defense += DefenseValue;
            GameWindow.listBoxLinije.Items.Add(igrac.ime + " se pripremi" + GenderPronouns.KrajReci(igrac.pol) + " za protivnicki napad");
            DefenseUsed = true;

        }
        void timer_Tick(object sender, EventArgs e)
        {
            EnemyAttack();
            timer.Stop();
            timer = new DispatcherTimer();
            UnFreezeGameState();
        }
        private void timerForAttack()
        {

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        public void FreezeGameState()
        {
            btnAttack.IsEnabled = false;
            btnDefense.IsEnabled = false;
       //     btnSpecialAttack.IsEnabled = false; DEMO
        }
        public void UnFreezeGameState()
        {
            btnAttack.IsEnabled = true;
            btnDefense.IsEnabled = true;
        //    btnSpecialAttack.IsEnabled = true; DEMO
        }
        private void EnemyAttack()
        {
            
            if (rand.Next(1, 21) + protivnik.damage >= igrac.defense+igrac.EquipedArmor.vrednost)
            {
                int damage = protivnik.damage + rand.Next(1, 7);

                
                if (DefenseUsed == true)
                {
                    damage -= DefenseDamageReduction;
                }
                igrac.HP -= damage;
                GameWindow.listBoxLinije.Items.Add(protivnik.ime + " je uradi" + GenderPronouns.KrajReci(protivnik.pol) + " " + damage + " damage");


                if (igrac.HP <= 0)
                {
                    igrac.HP = 0;
                    PlayerDeath();
                }
                GameWindow.lbHP.Text = igrac.HP.ToString();
            }
            else
            {
                GameWindow.listBoxLinije.Items.Add(protivnik.ime + " je promasi" + GenderPronouns.KrajReci(protivnik.pol) + " napad");
            }

            if (DefenseUsed == true)
            {
                igrac.defense -= DefenseValue;
                DefenseUsed = false;
            }
            GameWindow.UpdatePlayerInfo();
        }
        void PlayerDeath()
        {
            //Kad igrac umre
            if (MessageBox.Show("Nažalost ste umrli. Hvala vam što ste igrali demo verziju igre.", "Kraj", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                MainWindow window = new MainWindow(GameWindow.username, GameWindow.admin);
                window.Show();
                GameWindow.Close();
            }
        }

        private void btnSpecialAttack_Click(object sender, RoutedEventArgs e)
        {
            //Nije uradjeno u demo verziji
        }
    }


}

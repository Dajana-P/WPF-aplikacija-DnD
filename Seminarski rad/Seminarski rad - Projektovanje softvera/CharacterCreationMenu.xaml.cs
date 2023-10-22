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
using System.Windows.Threading;

namespace Seminarski_rad___Projektovanje_softvera
{
    /// <summary>
    /// Interaction logic for CharacterCreationMenu.xaml
    /// </summary>
    public partial class CharacterCreationMenu : Window
    {
        string username;
        bool admin;
        public DispatcherTimer timer = new DispatcherTimer();
        public CharacterCreationMenu(string username,bool admin)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            CommonMethods.LoadImage(imgPreview,"Ahri");
            this.username = username;
            this.admin = admin;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MWindow = new MainWindow(username,admin);
            MWindow.Show();
            this.Close();
        }

        private void btnCharCreation_MouseEnter(object sender, MouseEventArgs e)
        {
            CommonMethods.LoadImage(imgPreview,"Star Guardian KaiSa");
            timer.Stop();
            
        }

        private void btnRace_MouseEnter(object sender, MouseEventArgs e)
        {
            CommonMethods.LoadImage(imgPreview,"Yuubee");
            timer.Stop();
        }

        private void btnEnemy_MouseEnter(object sender, MouseEventArgs e)
        {
            CommonMethods.LoadImage(imgPreview,"Blackfrost Sion");
            timer.Stop();
        }

        private void btnNPC_MouseEnter(object sender, MouseEventArgs e)
        {
            CommonMethods.LoadImage(imgPreview,"Elderwood Ornn");
            timer.Stop();
        }

        private void btnItem_MouseEnter(object sender, MouseEventArgs e)
        {
            CommonMethods.LoadImage(imgPreview,"Deaths Dance");
            timer.Stop();
        }

        private void btnCharCreation_Click(object sender, RoutedEventArgs e)
        {
            CharacterCreation CCreation = new CharacterCreation(username, admin);
            CCreation.Show();
            this.Close();
        }

        private void btnRace_Click(object sender, RoutedEventArgs e)
        {
            RaceCreation RCreation = new RaceCreation(username, admin);
            RCreation.Show();
            this.Close();
        }

        private void btnEnemy_Click(object sender, RoutedEventArgs e)
        {
            EnemyCreation ECreation = new EnemyCreation(username, admin);
            ECreation.Show();
            this.Close();
        }

        private void btnNPC_Click(object sender, RoutedEventArgs e)
        {
            NPCCreation NPCCreation = new NPCCreation(username, admin);
            NPCCreation.Show();
            this.Close();
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {
            ItemCreation ICreation = new ItemCreation(username, admin);
            ICreation.Show();
            this.Close();
        }
        private void timerForPicture()
        {
            //DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
		{
            CommonMethods.LoadImage(imgPreview,"Ahri");
        }

        private void btnCharCreation_MouseLeave(object sender, MouseEventArgs e)
        {
            timerForPicture();
        }

        private void btnRace_MouseLeave(object sender, MouseEventArgs e)
        {
            timerForPicture();
        }

        private void btnEnemy_MouseLeave(object sender, MouseEventArgs e)
        {
            timerForPicture();
        }

        private void btnNPC_MouseLeave(object sender, MouseEventArgs e)
        {
            timerForPicture();
        }

        private void btnItem_MouseLeave(object sender, MouseEventArgs e)
        {
            timerForPicture();
        }

        private void btnKlasa_Click(object sender, RoutedEventArgs e)
        {
            ClassCreation KCreation = new ClassCreation(username, admin);
            KCreation.Show();
            this.Close();
        }

        private void btnKlasa_MouseLeave(object sender, MouseEventArgs e)
        {
            timerForPicture();
        }

        private void btnKlasa_MouseEnter(object sender, MouseEventArgs e)
        {
            CommonMethods.LoadImage(imgPreview, "Garen");
            timer.Stop();
        }
    }
}

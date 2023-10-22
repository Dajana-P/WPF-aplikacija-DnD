using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Seminarski_rad___Projektovanje_softvera
{
    class CommonMethods
    {
        public static void LoadImage(Image img,string imageName)
        {
            try
            {
                img.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/Characters/" + imageName + ".png", UriKind.Absolute));
            }
            catch (Exception ex)
            {
                img.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/Items/" + imageName + ".png", UriKind.Absolute));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SzerencsejatekWpfPro
{
    /// <summary>
    /// Interaction logic for ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        public ApplicationWindow()
        {
            InitializeComponent();
            btnFogadas_Click(this, new RoutedEventArgs(Button.ClickEvent));
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnFiok_Click(object sender, RoutedEventArgs e)
        {
            

            DropShadowEffect shadowEffect = new DropShadowEffect
            {
                Color = Colors.LightBlue,
                BlurRadius = 10,
                ShadowDepth = 0,
                Direction = 0,
                Opacity = 1
            };

            // Apply the effect to the button
            btnFiok.Effect = shadowEffect;
            btnFogadas.Effect = null;
            btnPenzFeltoltes.Effect = null;

            Container.Content = new AccountPage();


        }

        private void btnFogadas_Click(object sender, RoutedEventArgs e)
        {
            

            DropShadowEffect shadowEffect = new DropShadowEffect
            {
                Color = Colors.LightBlue,
                BlurRadius = 10,
                ShadowDepth = 0,
                Direction = 0,
                Opacity = 1
            };

            // Apply the effect to the button
            btnFogadas.Effect = shadowEffect;
            btnFiok.Effect = null;
            btnPenzFeltoltes.Effect = null;

            Container.Content = new BetPage();
        }

        private void btnPenzFeltoltes_Click(object sender, RoutedEventArgs e)
        {
            DropShadowEffect shadowEffect = new DropShadowEffect
            {
                Color = Colors.LightBlue,
                BlurRadius = 10,
                ShadowDepth = 0,
                Direction = 0,
                Opacity = 1
            };

            // Apply the effect to the button
            btnPenzFeltoltes.Effect = shadowEffect;
            btnFogadas.Effect = null;
            btnFiok.Effect = null;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

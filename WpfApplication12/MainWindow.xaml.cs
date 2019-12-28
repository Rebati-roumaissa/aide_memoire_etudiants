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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media.Animation;

namespace WpfApplication12
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 1;
            
            cav.BeginAnimation(OpacityProperty, da);
        }

        private void watermarkedTxt_gotfocus(object sender, EventArgs e)
        {
            pseudo2.Visibility = System.Windows.Visibility.Collapsed;
            pseudo.Visibility = System.Windows.Visibility.Visible;
            pseudo.Focus();
        }
        private void userInput_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pseudo.Text))
            {
                pseudo.Visibility = System.Windows.Visibility.Collapsed;
                pseudo2.Visibility = System.Windows.Visibility.Visible;

            }

        }
        private void pass_gotfocus(object sender, EventArgs e)
        {
            pass2.Visibility = System.Windows.Visibility.Collapsed;
            pass.Visibility = System.Windows.Visibility.Visible;
            pass.Focus();
        }
        private void pass_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pass.Password))
            {
                pass.Visibility = System.Windows.Visibility.Collapsed;
                pass2.Visibility = System.Windows.Visibility.Visible;

            }

        }

        private void inscr_Click(object sender, RoutedEventArgs e)
        {
            inscrire wind = new inscrire();
            wind.Show();
            this.Close();
        }

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            methodes app = new methodes();
            utilisateur user = app.login(pseudo.Text, pass.Password);
            if (user!= null)
            {
                acceuil windo = new acceuil(user);
                 windo.Show();
                 this.Close();         
            }
            else
            {
                error.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            a_propos win = new a_propos();
            win.Show();
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"aide_en_ligne\templates\admin\help.html");
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WpfApplication12
{
    /// <summary>
    /// Logique d'interaction pour User_Affichage.xaml
    /// </summary>
    public partial class User_Affichage : Page
    {
        utilisateur user;
        string motpass;
        public User_Affichage(utilisateur use)
        {
            this.user = use;
            InitializeComponent();


            Nom2.Text = user.getnom();
            Prenom2.Text = user.getprenom();
            Pseudo2.Text = user.getpseudo();
            motpass = user.getmotdepasse();
            Enrigstrer.Visibility = Visibility.Collapsed;
            Annuler.Visibility = Visibility.Collapsed;
            Nouveau_mot_de_passe.Visibility = System.Windows.Visibility.Collapsed;
            Ancien_mot_de_passe.Visibility = System.Windows.Visibility.Collapsed;
            Password.Visibility = System.Windows.Visibility.Collapsed;
            Password2.Visibility = System.Windows.Visibility.Collapsed;
       
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
           

            // Modifier.Visibility = System.Windows.Visibility.Collapsed;

            Nom2.Visibility = System.Windows.Visibility.Visible;
            Prenom2.Visibility = System.Windows.Visibility.Visible;
            Pseudo2.Visibility = System.Windows.Visibility.Visible;
            Enrigstrer.Visibility = Visibility.Visible;
       
            Annuler.Visibility = Visibility.Visible;
      
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            methodes m = new methodes();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From Utilisateurs Where Id_utilisateur ='" + user.getid_utilis() + "'", con);
            SqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.Read())
            {
                user.setnom(myReader["Nom"].ToString());
                user.setprenom(myReader["Prenom"].ToString());
                user.setpseudo(myReader["Pseudo"].ToString());
                user.setmotdepasse(myReader["Mpasse"].ToString());
            }
            con.Close();
            Nom2.Text = user.getnom();
            Prenom2.Text = user.getprenom();
            Pseudo2.Text = user.getpseudo();
            
        }

        private void Enrigstrer_Click(object sender, RoutedEventArgs e)
        {
            methodes m = new WpfApplication12.methodes();
            string motdepass = this.user.getmotdepasse();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            con.Open();
            SqlDataReader adapter;

            SqlCommand cmd = new SqlCommand("Select * From Utilisateurs Where Pseudo='" + Pseudo2.Text + "'", con);
         
            adapter = cmd.ExecuteReader();
            if (adapter.Read() && (int)(adapter["id_utilisateur"]) != user.getid_utilis())
            {
                pseu_ext.Visibility = System.Windows.Visibility.Visible;

            }
            else

            {
                if ((Password.Password != "") && (Password2.Password != ""))
                {
                    if (Password.Password == user.getmotdepasse())
                    {
                        MessageBoxResult reslt = MessageBox.Show("Voulez-vous vraiment modifier vos informations", "Confirmation", MessageBoxButton.YesNo);
                        if (reslt == MessageBoxResult.Yes)
                        {
                            motdepass = Password2.Password;
                            user.Modifer_utilisateur(this.user, Nom2.Text, Prenom2.Text, motdepass, Pseudo2.Text);
                            user.modifier_utilis(user, this.user.getid_utilis());

                            con.Close();
                        }
                    }
                    else
                    {
                        incorect.Visibility = Visibility.Visible;
                    }
                    
                }
                else
                {
                    MessageBoxResult reslt = MessageBox.Show("Voulez-vous vraiment modifier vos informations", "Confirmation", MessageBoxButton.YesNo);
                    if (reslt == MessageBoxResult.Yes)
                    {
                        user.Modifer_utilisateur(this.user, Nom2.Text, Prenom2.Text, motdepass, Pseudo2.Text);
                        user.modifier_utilis(user, this.user.getid_utilis());

                        con.Close();
                    }
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Annuler.Margin = new Thickness(290, 390, 0, 0);
            Enrigstrer.Margin = new Thickness(290, 390, 0, 0);
        }

        private void Modifier_nom_Click(object sender, RoutedEventArgs e)
        {
            Annuler.Visibility = System.Windows.Visibility.Visible;
            Enrigstrer.Visibility = System.Windows.Visibility.Visible;
        }

        private void Modifier_prenom_Click(object sender, RoutedEventArgs e)
        {
            Annuler.Visibility = System.Windows.Visibility.Visible;
            Enrigstrer.Visibility = System.Windows.Visibility.Visible;
        }

        private void Modifier_Pseudo_Click(object sender, RoutedEventArgs e)
        {
            Annuler.Visibility = System.Windows.Visibility.Visible;
            Enrigstrer.Visibility = System.Windows.Visibility.Visible;
        }

        private void change(object sender, TextChangedEventArgs e)
        {
            Annuler.Visibility = System.Windows.Visibility.Visible;
            Enrigstrer.Visibility = System.Windows.Visibility.Visible;

        }

        private void Modifier_mot_depasse_Click(object sender, RoutedEventArgs e)
        {

            Annuler.Margin = new Thickness(140, 490, 0, 0);
            Enrigstrer.Margin = new Thickness(400, 490, 0, 0);

            Nouveau_mot_de_passe.Visibility = System.Windows.Visibility.Visible;
            Ancien_mot_de_passe.Visibility = System.Windows.Visibility.Visible;
            Password.Visibility = System.Windows.Visibility.Visible;
            Password2.Visibility = System.Windows.Visibility.Visible;
            Annuler.Visibility = System.Windows.Visibility.Visible;
            Enrigstrer.Visibility = System.Windows.Visibility.Visible;

        }

        private void Pseudo2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Annuler.Visibility = System.Windows.Visibility.Visible;
            Enrigstrer.Visibility = System.Windows.Visibility.Visible;
        }
    }
}

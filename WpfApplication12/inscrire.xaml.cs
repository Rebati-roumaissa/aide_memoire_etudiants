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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication12
{
    /// <summary>
    /// Interaction logic for inscrire.xaml
    /// </summary>
    public partial class inscrire : Window
    {
        public inscrire()
        {
            InitializeComponent();
        }
        private void prenom_gotfocus(object sender, EventArgs e)
        {
            prenom2.Visibility = System.Windows.Visibility.Collapsed;
            prenom.Visibility = System.Windows.Visibility.Visible;
            prenom.Focus();
        }
        private void prenom_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(prenom.Text))
            {
                prenom.Visibility = System.Windows.Visibility.Collapsed;
                prenom2.Visibility = System.Windows.Visibility.Visible;

            }

        }
        private void nom_gotfocus(object sender, EventArgs e)
        {
            nom2.Visibility = System.Windows.Visibility.Collapsed;
            nom.Visibility = System.Windows.Visibility.Visible;
            nom.Focus();
        }
        private void nom_lostfocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nom.Text))
            {
                nom.Visibility = System.Windows.Visibility.Collapsed;
                nom2.Visibility = System.Windows.Visibility.Visible;
              

            }

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
        private void confirm_gotfocus(object sender, EventArgs e)
        {
            confirm2.Visibility = System.Windows.Visibility.Collapsed;
            confirm.Visibility = System.Windows.Visibility.Visible;
            confirm.Focus();
        }
        private void confirm_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(confirm.Password))
            {
                confirm.Visibility = System.Windows.Visibility.Collapsed;
                confirm.Visibility = System.Windows.Visibility.Visible;

            }

        }
        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void prenom2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void prenom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nom.Text != "" && prenom.Text != "" && pass.Password != "" && pseudo.Text != "")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                    SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Utilisateurs Where Pseudo='" + pseudo.Text + "'", con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows[0][0].ToString() == "1")
                    {
                        //afficher acueil
                        pseu_ext.Visibility = System.Windows.Visibility.Visible;


                    }
                    else
                    {
                        if (string.IsNullOrEmpty(nom.Text))
                        {
                            champs.Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            if (pass.Password.Equals(confirm.Password))
                            {

                                String query = "INSERT INTO Utilisateurs(Nom,Prenom,Pseudo,Mpasse)output INSERTED.Id_utilisateur VALUES ('" + nom.Text + "','" + prenom.Text + "','" + pseudo.Text + "','" + pass.Password + "')";
                                con.Open();

                                SqlCommand cmd = new SqlCommand(query, con);
                                int id = 0;
                                id = (int)cmd.ExecuteScalar();
                                if (con.State == System.Data.ConnectionState.Open)
                                    con.Close();
                                utilisateur user = new utilisateur(id, nom.Text, prenom.Text, pseudo.Text);
             
                                acceuil win = new acceuil(user);
                                win.Show();
                                this.Close();
                            }
                            else confirmation.Visibility = System.Windows.Visibility.Visible;
                        }

                    }

                }
                else
                {
                    champs.Visibility = Visibility.Visible;
                }

            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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

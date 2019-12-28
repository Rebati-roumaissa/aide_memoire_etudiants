using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Input;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Media;
using System.Globalization;
using System.Diagnostics;
using System.Windows;

namespace WpfApplication12
{
    public class utilisateur
    {
       private int id_utilis;
       private string nom;
       private string prenom;
       private string mot_de_passe;
       private string pseudo;

      public utilisateur(int id,string nom,string prenom,string pseudo)
        {
            this.id_utilis = id;
            this.nom =nom;
            this.prenom = prenom;
            this.pseudo = pseudo;
        }
      
        public int getid_utilis()
        { return this.id_utilis; }
        public void setiduilis(int id_utilis)
        { this.id_utilis = id_utilis; }
        public String getnom()
        { return this.nom; }
        public void setnom(String nom)
        { this.nom = nom; }
        public String getprenom()
        { return this.prenom; }
        public void setprenom(String prenom)
        { this.prenom = prenom; }
        public void setmotdepasse(String mot_de_passe)
        { this.mot_de_passe = mot_de_passe; }
        public String getmotdepasse()
        { return this.mot_de_passe; }
        public void setpseudo(String pseudo)
        { this.pseudo = pseudo; }
        public String getpseudo()
        { return this.pseudo; }
        private bool exist(String pseudo)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\c#\login\WpfApplication12\bdd.mdf;Integrated Security=True");
                //la chaine de connexion recupérée à partir des propriétés de Dataset
                SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Utilisateurs Where Pseudo='" +pseudo + "'", con); 
                DataTable table = new DataTable();
                adapter.Fill(table);//table d'une seule ligne qui contient le nombre d'élément retourné par la requete
                if (table.Rows[0][0].ToString() != "0")
                {//il existe au moins un élément
                    return true;
                }
                else

                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
       

        public void Modifer_utilisateur(utilisateur user, string nom, string prenom, string mot_de_passe, string pseudo)
        {
            user.setnom(nom);
            user.setprenom(prenom);
            user.setmotdepasse(mot_de_passe);
            user.setpseudo(pseudo);
        }
       /* public void Modifier_pseudo(utilisateur_class user, string pseudo)
        {
            user.setpseudo(pseudo);
        }
        public void Modifier_motdepasse(utilisateur_class user, string mot_de_passe)
        {
            user.setmotdepasse(mot_de_passe);
        }*/
        public void modifier_utilis(utilisateur user,int id_utilis)
        { 
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "update Utilisateurs set Nom=@nom,Prenom=@prenom,Pseudo=@pseudo,Mpasse=@motdepasse WHERE Id_utilisateur=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id_utilis.ToString());
            cmd.Parameters.AddWithValue("@nom", user.getnom());
            cmd.Parameters.AddWithValue("@prenom", user.getprenom());
            cmd.Parameters.AddWithValue("@pseudo", user.getpseudo());
            cmd.Parameters.AddWithValue("@motdepasse",user.getmotdepasse());
            cmd.ExecuteNonQuery();
          
            con.Close();
        }        
    }
}

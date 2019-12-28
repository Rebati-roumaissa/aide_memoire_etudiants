using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Data.SqlClient;
using System.Media;
using System.Globalization;
using System.Windows.Input;
using System.Diagnostics;

namespace WpfApplication12
{
    public class alerte_class
    {
       private int id_alerte;
        private String son;
        private int id_utilis;
        private int id_évèn;
        private int id_tach;
        private DateTime temps;
        private bool activer;
       public alerte_class(int id_alerte,String son,int id_utilis,int id_évèn,int id_tach,DateTime temps,bool activer)
        {
            this.id_alerte = id_alerte;
            this.id_tach = id_tach;
            this.id_utilis = id_utilis;
            this.id_évèn = id_évèn;
            this.son = son;
            this.temps = temps;
            this.activer = activer;
        }
        public alerte_class(String son, int id_utilis, int id_tach, DateTime temps, bool activer)
        {
            this.id_tach = id_tach;
            this.id_utilis = id_utilis;
            this.son = son;
            this.temps = temps;
            this.activer = activer;
        }
        public alerte_class()
        {

        }
        public alerte_class(String son, int id_utilis, DateTime temps, bool activer, int id_évèn)
        {
            this.id_utilis = id_utilis;
            this.id_évèn = id_évèn;
            this.son = son;
            this.temps = temps;
            this.activer = activer;
        }

        public int getidalerte()
        { return this.id_alerte; }
        public void  setidalerte(int id_alerte)
        { this.id_alerte=id_alerte; }
        public int getidtach()
        { return this.id_tach; }
        public void setidtach(int id_tach)
        { this.id_tach = id_tach; }
        public int getidévèn()
        { return this.id_évèn; }
        public void setidévèn(int id_évèn)
        { this.id_évèn = id_évèn; }
        public int getidutilis()
        { return this.id_utilis; }
        public void setidutilis(int id_utilis)
        { this.id_utilis = id_utilis; }
        public DateTime gettemps()
        { return this.temps; }
        public void settemps(DateTime temps)
        { this.temps= temps; }
        public String getson()
        { return this.son; }
        public void setson(String son)
        { this.son = son; }
        public bool getactiver()
        { return this.activer; }
        public void setactiver(bool activer)
        { this.activer = activer; }
        private bool exist_courant()
        {
            try
            {
                DateTime curent = DateTime.Now;
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                //la chaine de connexion recupérée à partir des propriétés de Dataset
                SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Alertes Where temps='" + curent.ToString("G", culture) + "AND Active='" + "True" + "'", con);
                //"G" pour écrire sous la forme MM/dd/yyyy HH:mm:ss 
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
        private bool exist(DateTime temps)
        {
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                //la chaine de connexion recupérée à partir des propriétés de Dataset
                SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Alertes Where temps='" + temps.ToString("G", culture) + "'", con);
                //"G" pour écrire sous la forme MM/dd/yyyy HH:mm:ss 
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
        public int inserer_alerte(/*DateTime temp, string id_tache, String id_éven, String id_user, String Son, Boolean activ*/alerte_class alerte)
        {
            int id_alerte = 0;
            try
            {
               
                    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                    String query = "INSERT INTO Alertes(temps,id_tach,id_évèn,id_utilis,activer,son) output INSERTED.id_alerte VALUES ('" + /*temp*/alerte.gettemps().ToString("G", culture) + "','" + /*id_tache*/alerte.getidtach().ToString() + "','" + /*id_éven*/alerte.getidévèn().ToString() + "','" + /*id_user*/alerte.getidutilis().ToString() + "','" + /*activ*/alerte.getactiver() + "','" + /*Son*/alerte.getson() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                  
                    id_alerte = (int)cmd.ExecuteScalar();
                    con.Close();
                   
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Concat("Erreur : ", e.Message));
            }
            setidalerte(id_alerte);
            return id_alerte;
        }
        public int inserer_alerte_tache(alerte_class alerte)
        {
            int id_alerte = 0;
            try
            {
               
                    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                    // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|bdd.mdf;Integrated Security=True");
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");

                    String query = "INSERT INTO Alertes(temps,id_tach,activer,son,id_utilis) output INSERTED.id_alerte VALUES ('" + /*temp*/alerte.gettemps().ToString("G", culture) + "','" + /*id_tache*/alerte.getidtach().ToString()+ "','"  + /*activ*/alerte.getactiver() + "','" + alerte.getson() + "','" + alerte.getidutilis() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    id_alerte = (int)cmd.ExecuteScalar();
                    con.Close();
                  
                
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Concat("Erreur : ", e.Message));
            }
            setidalerte(id_alerte);
            return id_alerte;
        }
        public int inserer_alerte_even(alerte_class alerte)
        {
            int id_alerte = 0;
            try
            {
                
                    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                    String query = "INSERT INTO Alertes(temps,id_évèn,activer,son,id_utilis) output INSERTED.id_alerte VALUES ('" + alerte.gettemps().ToString("G", culture) +  "','" + alerte.getidévèn().ToString() + "','" + /*activ*/alerte.getactiver() + "','" + alerte.getson() + "','" + alerte.getidutilis() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    id_alerte = (int)cmd.ExecuteScalar();
                    con.Close();
                    MessageBox.Show("Données enregistrées");
                
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Concat("Erreur : ", e.Message));
            }
            setidalerte(id_alerte);
            return id_alerte;
        }

        public void Modifer_alerte(alerte_class alerte, DateTime temp, int id_tache, int id_éven, int id_user, String Son,bool activ)
        {
            alerte.settemps(temp);
            alerte.setson(Son);
            alerte.setidévèn(id_évèn);
            alerte.setidutilis(id_utilis);
            alerte.setidtach(id_tach);
            alerte.setactiver(activ);
        }
        public void rechercher_par_tache(int id_tache)
        {

        }
        public void Modifier(int id_alerte,alerte_class alerte)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "update Alertes set temps=@temps,id_tach=@id_tach,id_évèn=@id_even,id_utilis=@id_utilis,Son=@son,activer=@activer WHERE id_alerte=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id_alerte.ToString());
            cmd.Parameters.AddWithValue("@temps", alerte.gettemps().ToString("G", culture));
            cmd.Parameters.AddWithValue("@id_tach",alerte.getidtach().ToString());
            cmd.Parameters.AddWithValue("@id_even",alerte.getidévèn().ToString());
            cmd.Parameters.AddWithValue("@id_utilis",alerte.getidutilis().ToString());
            cmd.Parameters.AddWithValue("@son", alerte.getson());
            cmd.Parameters.AddWithValue("@activer",alerte.getactiver());
            cmd.ExecuteNonQuery();
            con.Close();
        }
      
        public void supprimer(alerte_class alerte)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "Delete from Alertes WHERE Id_alerte='"+alerte.getidalerte()+"'AND id_utilis ='" + alerte.getidutilis()+"'" ;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void supprimer_alerte_tache(int id_user, int id_tache)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "Delete from Alertes WHERE id_tach='" + id_tache + "'AND id_utilis ='" + id_user;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void supprimer_alerte_event(int id_user, int id_event)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "Delete from Alertes WHERE id_évèn='" + id_event + "'AND id_utilis ='" + id_user;
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Modifier_aler_tache_bdd(int id_alerte, alerte_class alerte)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "update Alertes set temps=@temps,id_tach=@id_tach,id_utilis=@id_utilis,Son=@son WHERE id_alerte=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id_alerte.ToString());
            cmd.Parameters.AddWithValue("@temps", alerte.gettemps().ToString("G", culture));
            cmd.Parameters.AddWithValue("@id_tach", alerte.getidtach().ToString());
            cmd.Parameters.AddWithValue("@id_utilis", alerte.getidutilis().ToString());
            cmd.Parameters.AddWithValue("@son", alerte.getson());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Modifier_aler_even_bdd(int id_alerte, alerte_class alerte)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "update Alertes set temps=@temps,id_évèn=@id_évèn,id_utilis=@id_utilis,Son=@son WHERE id_alerte=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id_alerte.ToString());
            cmd.Parameters.AddWithValue("@temps", alerte.gettemps().ToString("G", culture));
            cmd.Parameters.AddWithValue("@id_évèn", alerte.getidévèn().ToString());
            cmd.Parameters.AddWithValue("@id_utilis", alerte.getidutilis().ToString());
            cmd.Parameters.AddWithValue("@son", alerte.getson());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update_alert(DateTime d,string son)
        {
            this.temps = d;
            this.son = son;
        }
    }
}

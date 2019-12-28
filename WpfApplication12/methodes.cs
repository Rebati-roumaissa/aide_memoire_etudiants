using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Media;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;
using WpfApplication12;
using System.Security.AccessControl;

namespace WpfApplication12
{
    public class methodes
    {
        //methde pour utilisateur
        public utilisateur login(string pseudo, string pass)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Utilisateurs Where Pseudo='" + pseudo + "'AND Mpasse='" + pass + "'", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows[0][0].ToString() == "0")
            {
                return null;
            }
            else
            {
                String qry = "SELECT * FROM Utilisateurs Where Pseudo='" + pseudo + "'AND Mpasse='" + pass + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader objReader = cmd.ExecuteReader();
                if (objReader.HasRows)
                {
                    if (objReader.Read())
                    {
                        int id = objReader.GetInt32(objReader.GetOrdinal("Id_utilisateur"));
                        string nom = objReader["Nom"].ToString();
                        string prenom = objReader["Prenom"].ToString();
                        utilisateur user = new utilisateur(id, nom, prenom, pseudo);
                        user.setmotdepasse(pass);
                        return user;
                    }
                    else return null;
                }
                else return null;
            }
        }
        //methodes pour contact et carnet d adresse
        public int save_contact(string name, string adr, string tel, string mail, string site, int id_user)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "INSERT INTO Contacts(Nom,Adresse,Tel,Email,Sweb,Id_utilis) output INSERTED.Id_Contact VALUES ('"
            + name + "','" + adr + "','" + tel + "','" + mail + "','" + site + "','" + id_user + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int id = 0;
            id = (int)cmd.ExecuteScalar();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return id;
        }
        public void modif_contact(contact selected_contact, string nom, string adr, string tl, string mail, string web)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "UPDATE Contacts SET Nom=@nom, Adresse=@adr,Tel=@telphn,Email=@mail,Sweb=@web " + " WHERE Id_Contact='" + selected_contact.get_id() + "' AND Id_utilis='" + selected_contact.get_id_user() + "'";
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@nom", nom);
            command.Parameters.AddWithValue("@adr", adr);
            command.Parameters.AddWithValue("@telphn", tl);
            command.Parameters.AddWithValue("@mail", mail);
            command.Parameters.AddWithValue("@web", web);
            command.ExecuteNonQuery();
            con.Close();
        }
        public void delete_contact(contact selected_contact)
        {

            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\bdd.mdf;Integrated Security=True"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Contacts " +
                                "WHERE Id_Contact= '" + selected_contact.get_id() + "' AND Id_utilis='" + selected_contact.get_id_user() + "'", conn))
                        {

                            int rows = cmd.ExecuteNonQuery();

                            //rows number of record got deleted
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("erreur"+ex);
                }
            }
        }
        public List<contact> look_list(string info, int index, int id_user)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            List<contact> list_contact = new List<contact>();
            switch (index)
            {
                case 1:
                    String qry = "SELECT * FROM Contacts Where Adresse LIKE'" + info + "%' AND Id_utilis LIKE '" + id_user + "'";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("Id_Contact"));
                        string nom = myReader["Nom"].ToString();
                        string adr = myReader["Adresse"].ToString();
                        string tel = myReader["Tel"].ToString();
                        string mail = myReader["Email"].ToString();
                        string web = myReader["Sweb"].ToString();
                        contact c = new contact(id, nom, adr, tel, mail, web, id_user);
                        list_contact.Add(c);
                    }
                 
                    break;
                case 2:
                    qry = "SELECT * FROM Contacts Where Tel LIKE'" + info + "%' AND Id_utilis='" + id_user + "'";
                    cmd = new SqlCommand(qry, con);
                    con.Open();
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("Id_Contact"));
                        string nom = myReader["Nom"].ToString();
                        string adr = myReader["Adresse"].ToString();
                        string tel = myReader["Tel"].ToString();
                        string mail = myReader["Email"].ToString();
                        string web = myReader["Sweb"].ToString();
                        contact c = new contact(id, nom, adr, tel, mail, web, id_user);
                        list_contact.Add(c);
                    }
                    
                    break;
                case 3:
                    qry = "SELECT * FROM Contacts Where Email LIKE'" + info + "%' AND Id_utilis='" + id_user + "'";
                    cmd = new SqlCommand(qry, con);
                    con.Open();
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("Id_Contact"));
                        string nom = myReader["Nom"].ToString();
                        string adr = myReader["Adresse"].ToString();
                        string tel = myReader["Tel"].ToString();
                        string mail = myReader["Email"].ToString();
                        string web = myReader["Sweb"].ToString();
                        contact c = new contact(id, nom, adr, tel, mail, web, id_user);
                        list_contact.Add(c);
                    }
                    
                    break;
                case 4:
                    qry = "SELECT * FROM Contacts Where Sweb LIKE'" + info + "%' AND Id_utilis='" + id_user + "'";
                    cmd = new SqlCommand(qry, con);
                    con.Open();
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("Id_Contact"));
                        string nom = myReader["Nom"].ToString();
                        string adr = myReader["Adresse"].ToString();
                        string tel = myReader["Tel"].ToString();
                        string mail = myReader["Email"].ToString();
                        string web = myReader["Sweb"].ToString();
                        contact c = new contact(id, nom, adr, tel, mail, web, id_user);
                        list_contact.Add(c);
                    }
                    
                    break;
                default:
                    qry = "SELECT * FROM Contacts Where Nom LIKE'" + info + "%'AND Id_utilis='" + id_user + "'";
                    cmd = new SqlCommand(qry, con);
                    con.Open();
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("Id_Contact"));
                        string nom = myReader["Nom"].ToString();
                        string adr = myReader["Adresse"].ToString();
                        string tel = myReader["Tel"].ToString();
                        string mail = myReader["Email"].ToString();
                        string web = myReader["Sweb"].ToString();
                        contact c = new contact(id, nom, adr, tel, mail, web, id_user);
                        list_contact.Add(c);
                    }
                   
                    break;
                   

            }
            return list_contact;
        }
        //methode pour etat des taches 
        public  List<tache> etat(int id_utilis,DateTime date)
        {
            
            List<tache> list = new List<tache>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM Tâche Where id_utilis='" + id_utilis + "' AND cast (date as Date) = CONVERT(date,GETDATE())" ;
            
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                while (myReader.Read())
                {
                    int id = myReader.GetInt32(myReader.GetOrdinal("Id_tache"));
                    int id_activ = myReader.GetInt32(myReader.GetOrdinal("id_activ"));
                    string nom = myReader["designation"].ToString();
                    string p = myReader["priorité"].ToString();
                    DateTime value = (DateTime)myReader["date"];
                    DateTime fin = (DateTime)myReader["fin"];
                    string e = myReader["etat"].ToString();
                    tache c = new tache(id, nom, p, value, fin, e, id_activ, id_utilis);
                    list.Add(c);
                }

            }
            return list;
        }
        // mise à jour de l etat
        public void update_etat(int id_tach,int id_user,string etat)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");

                String query = "UPDATE Tâche SET etat=@etat WHERE Id_tache='" + id_tach + "' and id_utilis='" + id_user + "'";
                cnx.Open();
                SqlCommand cmd = new SqlCommand(query, cnx);
               
                cmd.Parameters.AddWithValue("@etat", etat);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            catch (SqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
        // recherche des taches en retard 
        public List<tache> tache_nonrealise(int id_utilis, DateTime date)
        {
            List<tache> list = new List<tache>();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM Tâche Where id_utilis='" + id_utilis + "' AND fin<'" + date.ToString("G",culture)+ "'AND (etat='" + "non réalisée" + "'OR etat='" + "en cours" + "')";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                while (myReader.Read())
                {
                    int id = myReader.GetInt32(myReader.GetOrdinal("Id_tache"));
                    int id_act = myReader.GetInt32(myReader.GetOrdinal("id_activ"));
                    string nom = myReader["designation"].ToString();
                    string p = myReader["priorité"].ToString();
                    DateTime value = (DateTime)myReader["date"];
                    DateTime fin = (DateTime)myReader["fin"];
                    string e = myReader["etat"].ToString();
                    tache c = new tache(id, nom, p, value, fin, e, id_act, id_utilis);
                    list.Add(c);
                }

            }
            return list;
        }

        // methodes activité 


        public void modif_Activ(activ_class a, string designation, string type)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "UPDATE Activité SET designation=@nom, type=@type " + " WHERE id_activité='" + a.get_id() + "' AND id_utilis='" + a.get_id_user() + "'";
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@nom", designation);
            command.Parameters.AddWithValue("@type", type);

            command.ExecuteNonQuery();
            con.Close();

        }

        /* ********* insertion ******** */

        
        public int insert_Activite(string des, string type,int id_user)
        {
            int id_Activ;

            SqlConnection cnc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnc;
            cnc.Open();
            cmd.CommandText = "insert into Activité(designation,type,id_utilis) output inserted.id_activité Values('" + des + "','" + type + "','" + id_user + "')";
            id_Activ = (int)cmd.ExecuteScalar();
            cnc.Close();
            return id_Activ;
        }




        /* ****** void delete ***** */
        public void delete_activ(activ_class a)
        {
            List<tache> taches = Afficher_Tache(a.get_id(), a.get_id_user());
            foreach (tache t in taches)
            {
                Delete_Tache(t);
            }
           
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            conn.Open();
               
                String qry = " DELETE FROM Activité WHERE id_activité = '" + a.get_id() + "' AND id_utilis = '" + a.get_id_user() + "'";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();          
            
        }
         public void delete_tacheofactivity(activ_class a)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            conn.Open();

                String qry = " DELETE FROM Tâche WHERE id_activ = '" + a.get_id() + "' AND id_utilis = '" + a.get_id_user() + "'";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();          
            
        }
        //liste des activité
        public List<activ_class> list_activ(int id_utilis)
        {
            List<activ_class> list_Activ = new List<activ_class>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM Activité Where id_utilis=" + id_utilis ;
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                while (myReader.Read())
                {
                    int id = myReader.GetInt32(myReader.GetOrdinal("id_activité"));
                    string nom_Activ = myReader["designation"].ToString();
                    string type = myReader["type"].ToString();
                    activ_class c = new activ_class(id, nom_Activ, type, id_utilis);
                    list_Activ.Add(c);
                }

            }
            return list_Activ;

        }
        // rechercher des activité
        public List<activ_class> look_activ(string info, int index, int id_user)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            List<activ_class> list_contact = new List<activ_class>();
            switch (index)
            {

                case 1:
                    string qry = "SELECT * FROM Activité Where type LIKE'" + info + "%' AND id_utilis='" + id_user + "'";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("id_activité"));
                        string nom_Activ = myReader["designation"].ToString();
                        string type = myReader["type"].ToString();
                        activ_class c = new activ_class(id, nom_Activ, type, id_user);
                        list_contact.Add(c);
                    }

                    break;


                default:
                    qry = "SELECT * FROM Activité Where designation LIKE'" + info + "%'AND id_utilis='" + id_user + "'";
                    cmd = new SqlCommand(qry, con);
                    con.Open();
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("id_activité"));
                        string nom_Activ = myReader["designation"].ToString();
                        string type = myReader["type"].ToString();
                        activ_class c = new activ_class(id, nom_Activ, type, id_user);
                        list_contact.Add(c);
                    }

                    break;


            }
            return list_contact;
        }

        // methodes pour tache
        public int Save_Tache(string design, string prio, DateTime temps, DateTime fin, string etat, int id_act, int id_user)
        {
            int id_tache = 0;
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");

                String query = "INSERT INTO Tâche(designation,priorité,date,fin,etat,id_activ,id_utilis) output INSERTED.id_tache VALUES ('"
                             + design + "','" + prio + "','" + temps.ToString("G", culture) + "','" + fin.ToString("G", culture) + "','" + etat + "','" + id_act + "','" + id_user + "')";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cnx.Open();
                id_tache = (int)cmd.ExecuteScalar();
                cnx.Close();

            }
            catch (SqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }

            return id_tache;
        }

        public void Delete_Tache(tache Tâche)
        {

            try
            {
                SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                supprimer_alerte_planifiée(Tâche.get_des());
                supprimer_alerte_tache(Tâche.get_id_user(), Tâche.get_id());
                supprimer_doc_tache(Tâche.get_id_user(), Tâche.get_id());
                String query = "DELETE FROM Tâche WHERE id_tache ='" + Tâche.get_id() + "'and id_activ='" + Tâche.get_idactiv() + "'and id_utilis='" + Tâche.get_id_user() + "'";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            catch (SqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }

        }
        public void Update_Tache(tache Tâche, string design, string prio, DateTime temps, DateTime fin, string etat)
        {
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");

                String query = "UPDATE Tâche SET designation =@design , priorité=@prio, date=@temps,fin=@fin, etat=@etat WHERE id_tache='" + Tâche.get_id() + "'and id_activ='" + Tâche.get_idactiv() + "' and id_utilis='" + Tâche.get_id_user() + "'";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cnx.Open();
                cmd.Parameters.AddWithValue("@design", design);
                cmd.Parameters.AddWithValue("@prio", prio);
                cmd.Parameters.AddWithValue("@temps", temps.ToString("G", culture));
                cmd.Parameters.AddWithValue("@fin", fin.ToString("G", culture));
                cmd.Parameters.AddWithValue("@etat", etat);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            catch (SqlException ex)
            {
               System.Windows.MessageBox.Show(ex.ToString());
            }

        }
        //recherche dans lase de donné s il existe des taches ou des evenements dans le meme temps
        public bool Exist(DateTime temps, DateTime fin, int id_user)
        {
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");

                //la chaine de connexion recupérée à partir des propriétés de Dataset
                SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Tâche Where ((date>='" + temps.ToString("G", culture) + "'AND date<='" + fin.ToString("G", culture) + "') OR (fin>='" + temps.ToString("G", culture) + "'AND fin<='" + fin.ToString("G", culture) + "')OR (date<='" + temps.ToString("G", culture) + "'AND fin>='" + fin.ToString("G", culture) + "')) AND (id_utilis='" + id_user + "')", con);
                //"G" pour écrire sous la forme MM/dd/yyyy HH:mm:ss 
                DataTable table = new DataTable();
                adapter.Fill(table);//table d'une seule ligne qui contient le nombre d'élément retourné par la requete
                if (table.Rows[0][0].ToString() != "0")
                {//il existe au moins un élément
                    return true;
                }
                else

                {
                    adapter = new SqlDataAdapter("Select Count(*) From évènement Where ((date>='" + temps.ToString("G", culture) + "'AND date<='" + fin.ToString("G", culture) + "') OR (fin>='" + temps.ToString("G", culture) + "'AND fin<='" + fin.ToString("G", culture) + "')OR (date<='" + temps.ToString("G", culture) + "'AND fin>='" + fin.ToString("G", culture) + "')) AND (id_utilis='" + id_user + "')", con);
                    //"G" pour écrire sous la forme MM/dd/yyyy HH:mm:ss 
                    table = new DataTable();
                    adapter.Fill(table);//table d'une seule ligne qui contient le nombre d'élément retourné par la requete
                    if (table.Rows[0][0].ToString() != "0")
                    {//il existe au moins un élément
                        return true;
                    }
                    else
                    { return false; }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("exist", ex.Message);
                return false;
            }
        }

        public bool Exist_modif_tach(DateTime temps, DateTime fin, int id_tache, int id_user)
        {

            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                //la chaine de connexion recupérée à partir des propriétés de Dataset
                SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Tâche Where ((date>='" + temps.ToString("G", culture) + "'AND date<='" + fin.ToString("G", culture) + "') OR (fin>='" + temps.ToString("G", culture) + "'AND fin<='" + fin.ToString("G", culture) + "')OR (date<='" + temps.ToString("G", culture) + "'AND fin>='" + fin.ToString("G", culture) + "')) AND (id_utilis='" + id_user + "') AND (Id_tache <>'" + id_tache + "')", con);

                //"G" pour écrire sous la forme MM/dd/yyyy HH:mm:ss 
                DataTable table = new DataTable();
                adapter.Fill(table);//table d'une seule ligne qui contient le nombre d'élément retourné par la requete
                if (table.Rows[0][0].ToString() != "0")
                {//il existe au moins un élément
                    return true;
                }
                else
                {
                    adapter = new SqlDataAdapter("Select Count(*) From évènement Where ((date>='" + temps.ToString("G", culture) + "'AND date<='" + fin.ToString("G", culture) + "') OR (fin>='" + temps.ToString("G", culture) + "'AND fin<='" + fin.ToString("G", culture) + "') OR (date<='" + temps.ToString("G", culture) + "'AND fin>='" + fin.ToString("G", culture) + "'))AND (id_utilis='" + id_user + "')", con);
                    //"G" pour écrire sous la forme MM/dd/yyyy HH:mm:ss 
                    table = new DataTable();
                    adapter.Fill(table);//table d'une seule ligne qui contient le nombre d'élément retourné par la requete
                    if (table.Rows[0][0].ToString() != "0")
                    {//il existe au moins un élément
                        return true;
                    }
                    else
                    { return false; }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("exist", ex.Message);
                return false;
            }

        }

        public bool Exist_modif_event(DateTime temps, DateTime fin, int id_event, int id_user)
        {
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                //la chaine de connexion recupérée à partir des propriétés de Dataset
                SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From évènement Where ((date>='" + temps.ToString("G", culture) + "'AND date<='" + fin.ToString("G", culture) + "') OR (fin>='" + temps.ToString("G", culture) + "'AND fin<='" + fin.ToString("G", culture) + "')OR (date<='" + temps.ToString("G", culture) + "'AND fin>='" + fin.ToString("G", culture) + "')) AND (id_utilis='" + id_user + "') AND (Id_évènement <>'" + id_event + "')", con);

                //"G" pour écrire sous la forme MM/dd/yyyy HH:mm:ss 
                DataTable table = new DataTable();
                adapter.Fill(table);//table d'une seule ligne qui contient le nombre d'élément retourné par la requete
                if (table.Rows[0][0].ToString() != "0")
                {//il existe au moins un élément
                    return true;
                }
                else
                {
                    adapter = new SqlDataAdapter("Select Count(*) From Tâche Where ((date>='" + temps.ToString("G", culture) + "'AND date<='" + fin.ToString("G", culture) + "') OR (fin>='" + temps.ToString("G", culture) + "'AND fin<='" + fin.ToString("G", culture) + "') OR (date<='" + temps.ToString("G", culture) + "'AND fin>='" + fin.ToString("G", culture) + "'))AND (id_utilis='" + id_user + "')", con);
                    //"G" pour écrire sous la forme MM/dd/yyyy HH:mm:ss 
                    table = new DataTable();
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
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("exist", ex.Message);
                return false;
            }
        }

    //recherche les taches d une activité

        public List<tache> Afficher_Tache(int id_act, int id_user)
        {

            List<tache> list_tache = new List<tache>();
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                String qry = "SELECT * FROM Tâche Where id_activ='" + id_act + "'and id_utilis='" + id_user + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                using (SqlDataReader myReader = cmd.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("Id_tache"));
                        string design = myReader["designation"].ToString();
                        string prio = myReader["priorité"].ToString();
                        string temps = myReader["date"].ToString();
                        string fin = myReader["fin"].ToString();
                        string etat = myReader["etat"].ToString();

                        tache t = new tache(id, design, prio, Convert.ToDateTime(temps), Convert.ToDateTime(fin), etat, id_act, id_user);
                        alerte_class a = alerte_of_tache(id, id_user);
                        t.set_alert(a);

                        
                        list_tache.Add(t);

                    }

                    }
                               

            }
            catch (SqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            return list_tache;

        }
        public List<tache> Rech_Tache(string info, int index, int id_act, int id_user)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
            List<tache> list_tache = new List<tache>();
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                switch (index)
                {

                    case 1:

                        String qry = "SELECT * FROM Tâche Where priorité LIKE'" + info + "%'and id_activ='" + id_act + "' AND Id_utilis='" + id_user + "'";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        con.Open();
                        SqlDataReader myReader = cmd.ExecuteReader();
                        while (myReader.Read())
                        {
                            int id = myReader.GetInt32(myReader.GetOrdinal("Id_tache"));
                            string design = myReader["designation"].ToString();
                            string prio = myReader["priorité"].ToString();
                            string temps = myReader["date"].ToString();
                            string fin = myReader["fin"].ToString();
                            string etat = myReader["etat"].ToString();

                            tache t = new tache(id, design, prio, Convert.ToDateTime(temps), Convert.ToDateTime(fin), etat, id_act, id_user);
                            list_tache.Add(t);
                        }

                        break;
                    case 2:

                        qry = "SELECT * FROM Tâche Where etat LIKE'" + info + "%'and id_activ='" + id_act + "' AND Id_utilis='" + id_user + "'";
                        cmd = new SqlCommand(qry, con);
                        con.Open();
                        myReader = cmd.ExecuteReader();
                        while (myReader.Read())
                        {
                            int id = myReader.GetInt32(myReader.GetOrdinal("Id_tache"));
                            string design = myReader["designation"].ToString();
                            string prio = myReader["priorité"].ToString();
                            string temps = myReader["date"].ToString();
                            string fin = myReader["fin"].ToString();
                            string etat = myReader["etat"].ToString();

                            tache t = new tache(id, design, prio, Convert.ToDateTime(temps), Convert.ToDateTime(fin), etat, id_act, id_user);
                            list_tache.Add(t);
                        }

                        break;

                    default:
                        qry = "SELECT * FROM Tâche Where designation LIKE'" + info + "%'and id_activ ='" + id_act + "' AND Id_utilis ='" + id_user + "'";
                        cmd = new SqlCommand(qry, con);
                        con.Open();
                        myReader = cmd.ExecuteReader();
                        while (myReader.Read())
                        {
                            int id = myReader.GetInt32(myReader.GetOrdinal("Id_tache"));
                            string design = myReader["designation"].ToString();
                            string prio = myReader["priorité"].ToString();
                            string temps = myReader["date"].ToString();
                            string fin = myReader["fin"].ToString();
                            string etat = myReader["etat"].ToString();
                            methodes m = new methodes();
                            tache t = new tache(id, design, prio, Convert.ToDateTime(temps), Convert.ToDateTime(fin), etat, id_act, id_user);
                            t.set_alert(m.alerte_of_tache(id,id_user));
                            list_tache.Add(t);
                        }
                       
                        break;

                }
            }
            catch (SqlException ex)
            {
                System.Windows.MessageBox.Show("rech" + ex.ToString());
            }
            return list_tache;
        }

        //  alerte
        public void Creer_tache_planif(alerte_class a, String Design, DateTime planiftemp,String type)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "schtasks.exe";
            startInfo.UseShellExecute = false;
            String myfile = @"<?xml version=""1.0"" encoding=""UTF-16""?>
              <Task version = ""1.2"" xmlns = ""http://schemas.microsoft.com/windows/2004/02/mit/task""  >
                         <RegistrationInfo >
                           <Date >" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + @"</Date >     
                           <Author > MAISONXP - PC\MAISON XP</Author >
                           <Description >Il faut réussir</Description >              
                                   </RegistrationInfo >
                                    <Triggers >                     
                                     <TimeTrigger >
                                       <StartBoundary > " + a.gettemps().ToString("yyyy-MM-ddTHH:mm:ss") + @" </StartBoundary >
                                               <Enabled > true </Enabled >
                                             </TimeTrigger >
                                           </Triggers >                              
                                           <Principals >
                                             <Principal>
                                                     <LogonType > InteractiveToken </LogonType >
                                                     <RunLevel > LeastPrivilege </RunLevel >
                                                   </Principal >
                                                 </Principals >
                                                 <Settings >
                                                   <MultipleInstancesPolicy > IgnoreNew </MultipleInstancesPolicy >
                                                   <DisallowStartIfOnBatteries > false </DisallowStartIfOnBatteries >
                                                   <StopIfGoingOnBatteries > false </StopIfGoingOnBatteries >
                                                   <AllowHardTerminate > true </AllowHardTerminate >                                    
                                                   <StartWhenAvailable > true </StartWhenAvailable >
                                                   <RunOnlyIfNetworkAvailable > false </RunOnlyIfNetworkAvailable >
                                                    <IdleSettings >                                  
                                                     <StopOnIdleEnd > true </StopOnIdleEnd >                                    
                                                     <RestartOnIdle > false </RestartOnIdle >                                    
                                                   </IdleSettings >                                    
                                                   <AllowStartOnDemand > true </AllowStartOnDemand >                                    
                                                   <Enabled > true </Enabled >                                    
                                                   <Hidden > false </Hidden >                                    
                                                   <RunOnlyIfIdle > false </RunOnlyIfIdle >                                    
                                                   <WakeToRun > true </WakeToRun >                                    
                                                   <ExecutionTimeLimit > P1D </ExecutionTimeLimit >                                    
                                                   <Priority > 7 </Priority >                                    
                                                 </Settings >                                    
                                                 <Actions Context = ""Author"" >                                     
                                                    <Exec >                                     
                                                      <Command > " + System.IO.Directory.GetCurrentDirectory() + @"\Affichage_alerte.exe" + @"</Command>                                        
                                                         <Arguments >" + @"""" + Design + @"""" + " " + @"""" + a.getson() + @"""" + " " + @"""" + planiftemp.ToString() + @"""" + " "+@"""" + type + @""""+ @"</Arguments>                                           
                                                          </Exec >          
                                                     </Actions >
                                                      </Task > ";
            String pathString = System.IO.Directory.GetCurrentDirectory() + @"\tachplanif.xml";
            FileSecurity fs = new FileSecurity();
            fs.AddAccessRule(new FileSystemAccessRule(System.Security.Principal.WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl, AccessControlType.Allow));

            System.IO.File.WriteAllText(pathString, myfile);
            File.SetAccessControl(pathString, fs);
            startInfo.Arguments = @"/Create /XML " + @"""" + pathString + @"""" + " /TN " + @"""" + Design + @"""";
            startInfo.CreateNoWindow = true;
            var p1 = Process.Start(startInfo);
            p1.WaitForExit();
        }

        public void supprimer_alerte_tache(int id_user, int id_tache)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "Delete from Alertes WHERE id_tach='" + id_tache + "'AND id_utilis ='" + id_user+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
           
            con.Close();
        }
        public void supprimer_doc_tache(int id_user, int id_tache)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "Delete from Document WHERE id_tach='" + id_tache + "'AND id_utilis ='" + id_user + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
           
            con.Close();
        }
        public void supprimer_doc_event(int id_user, int id_event)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "Delete from Document WHERE id_évèn='" + id_event + "'AND id_utilis ='" + id_user + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
           
            con.Close();
        }
        public void supprimer_alerte_event(int id_user, int id_event)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "Delete from Alertes WHERE id_évèn='" + id_event + "'AND id_utilis ='" + id_user+"'";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();
          
            con.Close();
        }
        public void modifier_tache_planifiée(alerte_class a, String Design, DateTime planiftemp, String Olddeisignation,String type)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "schtasks.exe";
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.Arguments = @"/Delete /TN " + @"""" + Olddeisignation + @"""" + " /f";
            var p1 = Process.Start(startInfo);
            p1.WaitForExit();
            Creer_tache_planif(a, Design, planiftemp,type);
        }


        // methodes pour alerte 


        public bool exist(DateTime temps)
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
                System.Windows.MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void save_alerte(alerte_class alerte, int id)
        {

            try
            {
                if (exist(alerte.gettemps()))
                {
                    System.Windows.MessageBox.Show("Vous avez déjà une alerte à ce temps veuillez entrer un temps disponible");
                }
                else
                {
                    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-En");
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
                    String query = "INSERT INTO Alertes(temps,id_tach,activer,son,id_utilis) output INSERTED.id_alerte VALUES ('" + /*temp*/alerte.gettemps().ToString("G", culture) + "','" + /*id_tache*/id.ToString() + "','" + /*activ*/alerte.getactiver() + "','" + alerte.getson() + "','" + alerte.getidutilis() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    int id_alerte = (int)cmd.ExecuteScalar();
                    con.Close();
                 
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(string.Concat("Erreur : ", e.Message));
            }
        }
        public void modifier_alerte_planifiée(alerte_class a, String Design, DateTime planiftemp,String type)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "schtasks.exe";
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.Arguments = @"/Delete /TN " + @"""" + Design + @"""" + " /f";
            var p1 = Process.Start(startInfo);
            p1.WaitForExit();
            Creer_tache_planif(a, Design, planiftemp,type);
        }
        public void supprimer_alerte_planifiée(String Design)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "schtasks.exe";
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.Arguments = @"/Delete /TN " + @"""" + Design + @"""" + " /f";
            var p1 = Process.Start(startInfo);
            p1.WaitForExit();
        }

        public alerte_class alerte_of_tache(int id_tache,int id_user)
        {
            alerte_class a=null;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM Alertes Where id_tach='" + id_tache + "'and id_utilis='" + id_user + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                if (myReader.Read())
                {
                    int id = myReader.GetInt32(myReader.GetOrdinal("Id_alerte"));

                    DateTime time = (DateTime)myReader["temps"];
                    string son = myReader["son"].ToString();
                    bool activé =(Boolean)myReader["activer"];
                   

                     a= new alerte_class(son,id_user,id_tache,time,activé);
                    a.setidalerte(id);
                }

            }
            return a;
        }
        public List<document> docs_of_tache(int id_tache, int id_user)
        {
            List<document> docs = new List<document>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM Document Where id_tach='" + id_tache + "'and id_utilis='" + id_user + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                while (myReader.Read())
                {
                    int id = myReader.GetInt32(myReader.GetOrdinal("Id_document"));
                    string nom = myReader["titre"].ToString();
                    string empl = myReader["emplacement"].ToString();
                    document doc = new document(id, nom, empl, id_tache, -1, id_user);
                    docs.Add(doc);
                }

            }
            return docs;
        }
        public List<document> docs_of_event(int id_event, int id_user)
        {
            List<document> docs = new List<document>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM Document Where id_évèn='" + id_event + "'and id_utilis='" + id_user + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                while (myReader.Read())
                {
                    int id = myReader.GetInt32(myReader.GetOrdinal("Id_document"));
                    string nom = myReader["titre"].ToString();
                    string empl = myReader["emplacement"].ToString();
                    document doc = new document(id, nom, empl,-1,id_event, id_user);
                    docs.Add(doc);
                }

            }
            return docs;
        }

        public alerte_class alerte_of_event(int id_even, int id_user)
        {
            alerte_class a = null;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM Alertes Where id_évèn='" + id_even + "'and id_utilis='" + id_user + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                if (myReader.Read())
                {
                    int id = myReader.GetInt32(myReader.GetOrdinal("Id_alerte"));

                    DateTime time = (DateTime)myReader["temps"];
                    string son = myReader["son"].ToString();
                    bool activé = (Boolean)myReader["activer"];
                    a = new alerte_class(son, id_user,  time, activé, id_even);
                    a.setidalerte(id);
                }

            }
            return a;
        }

        // methodes pour event_class 
        public int save_event(String designation, DateTime dat,DateTime fin, String lieu, int id_user)
        {
            int id = 0; DateTime da = new DateTime(12, 01, 01, 12, 1, 1);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            con.Open();
            CultureInfo cul = CultureInfo.CreateSpecificCulture("en-En");
            //   SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "INSERT INTO évènement(designation,date,lieu) output INSERTED.Id_event values('" + designation + "','" + dat + "','" + lieu + "')";
            String query = "INSERT INTO évènement(designation,date,fin,lieu,id_utilis) output INSERTED.Id_évènement values('" + designation + "','" + dat.ToString("G", cul) + "','" + fin.ToString("G", cul)+ "','" + lieu + "','" + id_user + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            id = (int)cmd.ExecuteScalar();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return id;
        }
        public void modifier_evenement(event_class selected_event)
        {
            CultureInfo cul = CultureInfo.CreateSpecificCulture("en-En");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "UPDATE évènement SET designation=@desig, date=@dat,lieu=@lie,fin=@fin " + " WHERE Id_évènement='" + selected_event.getId() + "' AND id_utilis='" + selected_event.getIdUtilis() + "'";
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@desig", selected_event.getDesig());
            command.Parameters.AddWithValue("@dat", selected_event.getDate().ToString("G", cul));
            command.Parameters.AddWithValue("@lie", selected_event.getLieu());
            command.Parameters.AddWithValue("@fin", selected_event.getFin().ToString("G",cul));
            command.ExecuteNonQuery();
            con.Close();
        }

        public void delete_event(event_class selected_event)
        {

            {
                try
                {
                    supprimer_alerte_planifiée(selected_event.getDesig());
                    supprimer_alerte_event(selected_event.getIdUtilis(), selected_event.getId());
                    supprimer_doc_event(selected_event.getIdUtilis(), selected_event.getId());

                    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM évènement " +
                                "WHERE Id_évènement= '" + selected_event.getId() + "' AND id_utilis='" + selected_event.getIdUtilis() + "'", conn))
                        {


                            int rows = cmd.ExecuteNonQuery();

                            //rows number of record got deleted
                        }
                        conn.Close();
                    }
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    //Log exception
                    //Display Error message
                }
            }
        }
        public List<event_class> look_list_event(string info, int index, int id_user)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            List<event_class> list_even = new List<event_class>();
            switch (index)
            {

                case 1:
                    String qry = "SELECT * FROM évènement Where lieu LIKE'" + info + "%' AND Id_utilis='" + id_user + "'";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("Id_évènement"));
                        string nom = myReader["designation"].ToString();
                        string date = myReader["date"].ToString(); DateTime d = Convert.ToDateTime(date);
                        string fin = myReader["fin"].ToString(); DateTime f = Convert.ToDateTime(fin);
                        string lieu = myReader["lieu"].ToString();
                        event_class c = new event_class(id, nom, d,f, lieu, id_user);
                        list_even.Add(c);
                    }

                    break;


                default:
                    qry = "SELECT * FROM évènement Where designation LIKE'" + info + "%'AND Id_utilis='" + id_user + "'";
                    cmd = new SqlCommand(qry, con);
                    con.Open();
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("Id_évènement"));
                        string nom = myReader["designation"].ToString();
                        string date = myReader["date"].ToString(); DateTime d = Convert.ToDateTime(date);
                        string fin = myReader["fin"].ToString(); DateTime f = Convert.ToDateTime(fin);
                        string lieu = myReader["lieu"].ToString();
                        event_class c = new event_class(id, nom, d,f, lieu, id_user);
                        list_even.Add(c);
                    }

                    break;


            }
            return list_even;

        }
        // liste des evenments 
        public List<event_class> event_list(int id_utilis)
        {
            List<event_class> list_event = new List<event_class>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM évènement Where id_utilis=" + id_utilis;
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                while (myReader.Read())
                {
                    int id = myReader.GetInt32(myReader.GetOrdinal("Id_évènement"));
                    string desig = myReader["designation"].ToString();
                    DateTime dat; DateTime datevalue;
                    DateTime.TryParse(myReader["date"].ToString(), out datevalue);
                    dat = datevalue;
                    DateTime.TryParse(myReader["fin"].ToString(), out datevalue);
                    DateTime fin = datevalue;
                    string lie = myReader["lieu"].ToString();
                    event_class c = new event_class(id, desig, dat,fin, lie, id_utilis);
                    alerte_class a = alerte_of_event(id, id_utilis);
                    c.set_alerte(a);
                 
                    list_event.Add(c);
                }

            }
            return list_event;

        }
        public List<document> afficher_doc(int id_utilis)
        {
            List<document> list_document = new List<document>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM Document Where id_utilis='" + id_utilis + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                while (myReader.Read())
                {
                    int id = myReader.GetInt32(myReader.GetOrdinal("Id_document"));
                    string nom = myReader["titre"].ToString();
                    string empl = myReader["emplacement"].ToString();
                    string id_event_string = myReader["id_évèn"].ToString();
                    
                    document doc = new document(id, nom, empl, 0, 0, id_utilis);
                    list_document.Add(doc);
                }

            }
            return list_document;

        }

        public int inserer_document_totache(String Titre, String emplacement, int id_user,int id_tach)
        {
            int id = 0;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Document (titre,emplacement,id_utilis,id_tach) output inserted.id_document values('" + Titre + "','" + emplacement + "','" + id_user + "','"+id_tach + "')";
            id = (int)cmd.ExecuteScalar();
            con.Close();
            return id;
        }
        public int inserer_document_toevent(String Titre, String emplacement, int id_user, int id_event)
        {
            int id = 0;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Document (titre,emplacement,id_utilis,id_évèn) output inserted.id_document values('" + Titre + "','" + emplacement + "','" + id_user + "','" + id_event + "')";
            id = (int)cmd.ExecuteScalar();
            con.Close();
            return id;
        }

        public void modifier_document(document selected_document, String titre, String empl)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String query = "UPDATE Document SET titre=@titre, emplacement=@empl " + " WHERE Id_document='" + selected_document.getId() + "' AND id_utilis='" + selected_document.getIdUser() + "'";
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@titre", titre);
            command.Parameters.AddWithValue("@empl", empl);
            command.ExecuteNonQuery();
            con.Close();
        }

        public void supprimer_document(document selected_document)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\bdd.mdf; Integrated Security = True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Document where Id_document='" + selected_document.getId() + "' AND id_utilis = '" + selected_document.getIdUser() + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<document> look_list_doc(string info, int id_user)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            List<document> list_doc = new List<document>();

                    String qry = "SELECT * FROM Document Where Titre LIKE'" + info + "%' AND id_utilis = '" + id_user + "'";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32(myReader.GetOrdinal("Id_document"));
                        string titre = myReader["titre"].ToString();
                        string empl = myReader["emplacement"].ToString();
                        document c = new document(id, titre, empl,0,0, id_user);
                        list_doc.Add(c);
                    }               
            return list_doc;
        }
    }
}


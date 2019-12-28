using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication12
{
    class carnet
    {
        public List<contact> afficher(int id_utilis)
        {
            List<contact> list_contact = new List<contact>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            String qry = "SELECT * FROM Contacts Where id_utilis=" + id_utilis;
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            using (SqlDataReader myReader = cmd.ExecuteReader())
            {
                while (myReader.Read())
                {
                   int id = myReader.GetInt32(myReader.GetOrdinal("Id_Contact"));
                   string nom= myReader["Nom"].ToString();
                   string adr = myReader["Adresse"].ToString();
                   string tel = myReader["Tel"].ToString();
                   string mail = myReader["Email"].ToString();
                   string web = myReader["Sweb"].ToString();
                   contact c = new contact(id,nom, adr, tel, mail, web,id_utilis);
                   list_contact.Add(c);
                }
                
            }
            return list_contact;

        }
    }
}

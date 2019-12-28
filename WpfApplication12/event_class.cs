using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication12
{
    public class event_class
    {
        private int Id_event;
        private String designation;
        private DateTime dat;
        private DateTime fin;
        private String lieu;
        private int Id_user;
        private alerte_class a;
        private List<document> list;
        public event_class(int Id, String Desingnation, DateTime date,DateTime fin, String lieu, int Id_utilisateur)
        {
            this.Id_event = Id;
            this.designation = Desingnation;
            this.dat = date;
            this.fin = fin;
            this.lieu = lieu;
            this.Id_user = Id_utilisateur;
            list = new List<document>();
        }
        public event_class()
        {

        }
        public void setId(int i)
        {
            this.Id_event = i;
        }
        public void setDesig(String desig)
        {
            this.designation = desig;
        }
        public void setDate(DateTime g)
        {
            this.dat = g;
        }
        public void setLieu(String d)
        {
            this.lieu = d;
        }
        public void setIdUtilis(int g)
        {
            this.Id_user = g;
        }
        public int getId()
        {
            return this.Id_event;
        }
        public String getDesig()
        {
            return this.designation;
        }
        public DateTime getDate()
        {
            return this.dat;
        }
        public String getLieu()
        {
            return this.lieu;
        }
        public int getIdUtilis()
        {
            return this.Id_user;
        }
        public DateTime getFin()
        {
            return (fin);
        }
        public void update_event(string des,string lieu,DateTime d,DateTime f)
        {
            this.designation = des;
            this.lieu = lieu;
            this.dat = d;
            this.fin = f;
        }
        public void set_alerte(alerte_class a)
        {
            this.a = a;
        }
        public alerte_class get_alerte()
        {
            return (this.a);
        }
        public void add_doc_to_tache(document doc)
        {
            list.Add(doc);
        }
        public List<document> get_documents()
        {
            return list;
        }
        public void set_documents(List<document> docs)
        {
            this.list = docs;
        }
    }
}

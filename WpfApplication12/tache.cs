using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication12
{
    public class tache
    {
        private int id;
        private string des;
        private string prio;
        private DateTime date;
        private DateTime fin;
        private string etat;
        private int id_user;
        private int id_activ;
        private alerte_class alarm;
        private List<document> list;

        public tache(int id_tache, String designation, String priorité, DateTime date, DateTime fin, String etat, int id_activ, int id_utilis)
        {
            this.id = id_tache;
            this.des = designation;
            this.prio = priorité;
            this.date = date;
            this.fin = fin;
            this.etat = etat;
            this.id_activ = id_activ;
            this.id_user = id_utilis;
            list = new List<document>();
        }

        public tache()
        {
            list = new List<document>();
        }
        public DateTime getdebut()
        { return this.date; }
        public DateTime getfin()
        { return this.fin; }
        public void setdebut(DateTime date)
        { this.date = date; }
        public void setfin(DateTime fin)
        { this.fin = fin; }
        public int get_id()
        {
            return (id);
        }
        public string get_des()
        {
            return (des);
        }
        public string get_prio()
        {
            return (prio);
        }
        public DateTime get_date()
        {
            return (date);
        }

        public string get_etat()
        {
            return (etat);
        }
        public void set_des(string des)
        {
            this.des = des;
        }
        public void set_prio(string adr)
        {
            this.prio = adr;
        }
        public void set_date(DateTime d)
        {
            this.date = d;
        }

        public void set_etat(string e)
        {
            this.etat = e;
        }
        public int get_id_user()
        {
            return (id_user);
        }
        public int get_idactiv()
        {
            return (id_activ);
        }
    
        public void set_alert(alerte_class a)
        {
            alarm = a;
        }
        public alerte_class get_alert()
        {
            return alarm;
        }
        public void update(string des,string prio,DateTime d,DateTime f,string etat)
        {
            this.des = des;
            this.etat = etat;
            this.date = d;
            this.fin = f;
            this.prio = prio;
            this.date = d;
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

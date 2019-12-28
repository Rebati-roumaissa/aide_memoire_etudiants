using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication12
{
    class tache_class
    {
        //attributs
        private int id_tache;
        private String designation;
        private String priorité;
        private DateTime date;
        private String etat;
        private int id_activ;
        private int id_utilis;

        //methodes
        //1-constructeurs

        public tache_class(int id_tache, String designation, String priorité, DateTime date, String etat, int id_activ, int id_utilis)
        {
            this.id_tache = id_tache;
            this.designation = designation;
            this.priorité = priorité;
            this.date = date;
            this.etat = etat;
            this.id_activ = id_activ;
            this.id_utilis = id_utilis;
        }
        //2-getteurs-setteurs
        public int getidtache()
        { return this.id_tache; }
        public String getdesignation()
        { return this.designation; }
        public String getpriorité()
        { return this.priorité; }
        public DateTime getdate()
        { return this.date; }
        public String getetat()
        { return this.etat; }
        public int getidactiv()
        { return this.id_activ; }
        public int getidutilis()
        { return this.id_utilis; }
        public void setidtache(int id_tache)
        { this.id_tache = id_tache; }
        public void setdesignation(String designation)
        { this.designation = designation; }
        public void setpriorité(String priorité)
        { this.priorité = priorité; }
        public void setdate(DateTime date)
        { this.date = date; }
        public void setetat(String etat)
        { this.etat = etat; }
        public void setidactiv(int id_activ)
        { this.id_activ = id_activ; }
        public void setidutilis(int id_utilis)
        { this.id_utilis = id_utilis; }

    }
}


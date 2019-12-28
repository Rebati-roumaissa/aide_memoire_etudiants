using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication12
{
   public class document
    {
        private int Id_Doc;
        private String Titre;
        private String emplacement;
        private int Id_tache;
        private int Id_event;
        private int Id_user;
        public document(int Id_Doc, String Titre, String emplacement, int Id_tache, int Id_event, int Id_user)
        {
            this.Id_Doc = Id_Doc;
            this.Titre = Titre;
            this.emplacement = emplacement;
            this.Id_tache = Id_tache;
            this.Id_event = Id_event;
            this.Id_user = Id_user;
        }
        public document()
        { }
        public int getId()
        {
            return this.Id_Doc;
        }
        public String getTitre()
        {
            return this.Titre;
        }
        public String getEmplac()
        {
            return this.emplacement;
        }
        public void setTitre(string s)
        {
             this.Titre=s;
        }
        public void setEmplac(string s)
        {
            this.emplacement=s;
        }
        public int getIdTache()
        {
            return this.Id_tache;
        }
        public int getIdEvent()
        {
            return this.Id_event;
        }
        public int getIdUser()
        {
            return this.Id_user;
        }
        public void set_id(int id)
        {
            this.Id_Doc = id;
        }
    }
}

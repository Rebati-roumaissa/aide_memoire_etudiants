using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication12
{
   public class contact
    {
        private int id;
        private string nom;
        private string adr;
        private string num;
        private string mail;
        private string site;
        private int id_user;
        public contact(int id,string nom,string adr,string num,string mail,string site,int id_user)
        {
            this.id = id;
            this.nom = nom;
            this.adr = adr;
            this.num = num;
            this.mail = mail;
            this.site = site;
            this.id_user = id_user;
         }
        public int get_id()
        {
            return (id);
        }
        public string get_name()
        {
            return (nom);
        }
        public string get_adr()
        {
            return (adr);
        }
        public string get_num()
        {
            return (num);
        }
        public string get_mail()
        {
            return (mail);
        }
        public string get_site()
        {
            return (site);
        }
        public void set_name(string nom)
        {
            this.nom = nom;
        }
        public void set_adr(string adr)
        {
            this.adr = adr;
        }
        public void set_num(string num)
        {
            this.num = num;
        }
       
        public void set_mail(string mail)
        {
            this.mail = mail;
        }
        public void set_site(string site)
        {
            this.site = site;
        }
        public int get_id_user()
        {
            return (id_user);
        }
    }
}

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

namespace WpfApplication12
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class modif_alerte : Window
    {
        private alerte_class al;
        private add_tache page;
        private modif_tache m;
        private list_taches taches;
        private tache t;
        private int id_user;
        private evenement evenements;
        private event_class eve;
        private AddEvent addev;
        public modif_alerte(tache t, add_tache page, int id_user)
        {

            this.t = new tache();
            this.t = t;
            this.page = page;
            this.eve = null;
            this.id_user = id_user;
            InitializeComponent();
            Date.Value = (t.get_alert()).gettemps();
            music.Text = (t.get_alert()).getson();

        }
        public modif_alerte()
        {
            InitializeComponent();
        }
        public modif_alerte(tache t, int id_user,list_taches page)
        {
            this.eve = null;
            this.id_user = id_user;
            this.t = t;
            this.taches = page;
            InitializeComponent();
            Date.Value = ((t.get_alert()).gettemps());
            music.Text = (t.get_alert()).getson();

        }
        public modif_alerte(event_class eve, int id_user, evenement page)
        {
            this.id_user = id_user;
            this.eve = eve;
            this.evenements = page;
            InitializeComponent();
            Date.Value = ((eve.get_alerte()).gettemps());
            music.Text = (eve.get_alerte()).getson();

        }
        public modif_alerte(alerte_class a,tache t,int id_user, modif_tache m)
        {
            this.eve = null;
            this.t = new tache();
            this.t = t;
            this.m = m;
            this.id_user = id_user;
            this.al = a;
            InitializeComponent();
            Date.Value = (al.gettemps());
            music.Text = al.getson();
            
        }
        public modif_alerte(alerte_class a,event_class eve, int id_user, AddEvent addev)
        {
            this.eve = new event_class();
            this.eve = eve;
            this.addev = addev;
            this.id_user = id_user;
            this.al = a;
            InitializeComponent();
            Date.Value = (al.gettemps());
            music.Text = al.getson();

        }
        private void parcourir_Click(object sender, RoutedEventArgs e)
        {
            choisir_son();
        }

        private void choisir_son()
        {
            System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();
            open.Filter = "Documents musicaux(Wave)|*.wav*" + "|Tous les documents|*.*";
            open.RestoreDirectory = true;
            open.Title = " Open ";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String musica = open.FileName;
                music.Text = musica;
            }
        }
        private void valider_Click(object sender, RoutedEventArgs e)
        {
            if (Date.Text != "" && music.Text != "")
            {
               
                if (Date.Value <= DateTime.Now)
                    System.Windows.Forms.MessageBox.Show("Vous ne pouvez pas insérer une alerte avec une date antérieure");
                else
                {

                    alerte_class alerte = new alerte_class(music.Text, id_user,0, Convert.ToDateTime(Date.Text), /*activer.IsChecked.Value*/true);
                    //yab9a 0 psq f nouvelle l'identifiant makancho
                    if (this.eve== null) valid_alert_tache(alerte);
                    else valid_alert_event(alerte);
                /* if (m == null)
                    {
                        if (taches == null)
                        {
                          
                            page.Show(); page.set_alarm(alerte); this.Close();
                        }
                        else
                        {
                            alerte.setidalerte((t.get_alert()).getidalerte());
                            alerte.setidutilis(t.get_id_user());
                            alerte.setidtach(t.get_id());
                            t.set_alert(alerte);
                            (t.get_alert()).Modifier_aler_tache_bdd((t.get_alert()).getidalerte(), (t.get_alert()));
                            meth.supprimer_alerte_planifiée(t.get_des());
                            meth.Creer_tache_planif(alerte, t.get_des(), t.get_date(), "t");
                            taches.clear_listbox();
                            taches.afficher(taches.get_list());
                          
                        }
                    }
                    else {
                           alerte.setidalerte((t.get_alert()).getidalerte());
                           alerte.setidtach(t.get_id());
                           m.set_alarm(alerte);
                           m.Show();
                           this.Close();
                        }
                        */
                }
            }
            else System.Windows.Forms.MessageBox.Show("Veuillez donner des informations");
            
            
        }
        private void valid_alert_tache(alerte_class alerte)
        {
            methodes meth = new methodes();
            if (m == null)
            {
                if (taches == null)
                {

                    page.Show(); page.set_alarm(alerte); this.Close();
                }
                else
                {
                    alerte.setidalerte((t.get_alert()).getidalerte());
                    alerte.setidutilis(t.get_id_user());
                    alerte.setidtach(t.get_id());
                    t.set_alert(alerte);
                    (t.get_alert()).Modifier_aler_tache_bdd((t.get_alert()).getidalerte(), (t.get_alert()));
                    meth.supprimer_alerte_planifiée(t.get_des());
                    meth.Creer_tache_planif(alerte, t.get_des(), t.get_date(), "t");
                    taches.clear_listbox();
                    taches.afficher(taches.get_list());
                    this.Close();
                }
            }
            else
            {
                alerte.setidalerte((t.get_alert()).getidalerte());
                alerte.setidtach(t.get_id());
                m.set_alarm(alerte);
                m.Show();
                this.Close();
            }

        }
        private void valid_alert_event(alerte_class alerte)
        {
            methodes meth = new methodes();
            if (addev == null)
            {
               /* if (evenements == null)
                {

                   page.Show(); page.set_alarm(alerte); this.Close();
                }
                else
                {*/
                    alerte.setidalerte((eve.get_alerte()).getidalerte());
                    alerte.setidutilis(eve.getIdUtilis());
                    alerte.setidévèn(eve.getId());
                    eve.set_alerte(alerte);
                    (eve.get_alerte()).Modifier_aler_even_bdd((eve.get_alerte()).getidalerte(), (eve.get_alerte()));
                    meth.supprimer_alerte_planifiée(eve.getDesig());
                    meth.Creer_tache_planif(alerte, eve.getDesig(), eve.getDate(), "e");
                
                    evenements.clear_listbox();
                    evenements.afficher(evenements.get_list());
                    this.Close();
                //}
            }
            else
            {
                if (eve.getId() > 0)
                {
                    alerte.setidalerte((eve.get_alerte()).getidalerte());
                    alerte.setidévèn(eve.getId());
                    addev.set_alarm_event(alerte);
                    addev.Show();
                }
                else
                {
                    addev.Show(); addev.set_alarm_event(alerte); this.Close();
                }
                this.Close();
            }

        }


        private void music_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

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
    /// Interaction logic for add_tache.xaml
    /// </summary>
    public partial class add_tache : Window
    {
        private tache t;
        private add_act page;
        private int id_user;
        private activ_class a;
        private list_taches p;
        public add_tache(add_act a,int id)
            {
            this.t = new tache();
            t.set_alert(null);
            this.p = null;
            this.id_user = id;
            page = new add_act();
            this.page = a;
            
            InitializeComponent();
            }
        public add_tache(activ_class a, int id,list_taches p)
        {
            page = new add_act();

            this.t = new tache();
            t.set_alert(null);
            this.p = new list_taches();
            this.p = p;
            this.id_user = id;
            this.a = a;

            InitializeComponent();
        }
        public void set_alarm(alerte_class a)
           {
            t.set_alert(a);
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("modif2.png", UriKind.Relative));
            ajouter_alerte.Content = img;
            info.Text = t.get_alert().gettemps().ToString();
        }
          
            private void ajouter_tache_Click(object sender, RoutedEventArgs e)
            {
            DateTime d = Convert.ToDateTime(dateDatePicker.Text + " " + débutTimePicker.Text);
            DateTime f = Convert.ToDateTime(dateDatePicker.Text + " " + finTimePicker.Text);
           
            
            
                t.update(designation.Text,prio.Text,d,f, "non réalisée");
            
                Alerte al = new Alerte(t,this,id_user);
                al.Show();
                this.Hide();
            }


            private void comboBox_priorite_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }

            

            private void DesignationTach_TextChanged(object sender, TextChangedEventArgs e)
            {

            }
        

       

        private void alert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(designation.Text))
            {
                er.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                if (this.t.get_alert() == null)
                {
                    Alerte win = new Alerte(t, this, id_user);
                    win.Show();
                    this.Hide();
                }
                else
                {
                    modif_alerte win = new modif_alerte(this.t,this,this.id_user);
                    win.Show();
                    this.Hide();
                }
            }
        }

        private void dock_Click(object sender, RoutedEventArgs e)
        {
            add_doc win = new add_doc(this,id_user);
            win.Show();
            this.Hide();
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(dateDatePicker.Text) || string.IsNullOrEmpty(débutTimePicker.Text) || string.IsNullOrEmpty(finTimePicker.Text))
            {
                System.Windows.Forms.MessageBox.Show(" Veillez Entrer la Date et/ou les Horaires !");
            }
            else
            {
                DateTime d = Convert.ToDateTime(dateDatePicker.Text + " " + débutTimePicker.Text);
                DateTime f = Convert.ToDateTime(dateDatePicker.Text + " " + finTimePicker.Text);

                if (string.IsNullOrEmpty(designation.Text))
                {
                    System.Windows.Forms.MessageBox.Show(" Veillez Entrer Une Désignation Correct !");
                }
                else
                {
                    if ((d > f) || (d < DateTime.Now))
                    {
                        //System.Windows.MessageBox.Show("d = " + d);
                        //erreur.Visibility = System.Windows.Visibility.Visible;
                        System.Windows.Forms.MessageBox.Show(" Cette Date est Déja Passée Ou Votre Horaires Ne Sont Pas Réglées !");

                    }
                    else
                    {

                        methodes m = new methodes();


                        if (m.Exist(d, f, id_user))
                        {
                            System.Windows.Forms.MessageBox.Show(" L'intervalle de temps donné est occupé veuillez le changer ");
                        }
                        else
                        {

                            t.update(designation.Text, prio.Text, d, f, "Non réalisée");
                            if (p == null) page.add_tache_toactivity(t);
                            else
                            {
                                p.add_tache(t);
                                int id_tache = m.Save_Tache(t.get_des(), t.get_prio(), t.get_date(), t.getfin(), t.get_etat(), a.get_id(), a.get_id_user());
                                alerte_class alert = t.get_alert();

                                if (alert != null)
                                {
                                    alert.setidtach(id_tache);
                                    alert.inserer_alerte_tache(alert);
                                    m.Creer_tache_planif(alert, t.get_des(), t.get_date(), "t");
                                }
                                List<document> list_docs = t.get_documents();
                                foreach (document doc in list_docs)
                                {
                                    m.inserer_document_totache(doc.getTitre(), doc.getEmplac(), id_user, id_tache);
                                }
                            }
                            Close();
                        }
                    }
                }

            }
                
            }
        public void add_doc_totache(document doc)
        {
            t.add_doc_to_tache(doc);
        }
        
 
    }
}

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
using System.Data.SqlClient;
using System.Data;


namespace WpfApplication12
{
    /// <summary>
    /// Logique d'interaction pour AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        private int id_user;
        private evenement page;
        private event_class new_eve;
        private event_class eve;
        private List<document> list;
        public AddEvent(int id, evenement page)
        {
            InitializeComponent();
            this.id_user = id;
            this.page = page;
            title.Text = "Nouvel Evénement";
            this.eve = null;
            this.new_eve = new event_class();
            this.list = new List<document>();

        }


        public AddEvent(event_class e, evenement page)
        {
            this.page = page;
            this.eve = e;
            this.new_eve = null;
            InitializeComponent();
            title.Text = "Modifier l' Evénement";
            designation.Text = e.getDesig();
            Lieu.Text = e.getLieu();
            date.Text = e.getDate().ToString("dd/MM/yyyy");
            debut.Text = e.getDate().ToString("HH:mm");
            fin.Text = e.getFin().ToString("HH:mm");
            Document_add.Visibility = Visibility.Collapsed;
            ajouter_document.Visibility = Visibility.Collapsed;
            if (e.get_alerte() != null)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("modif2.png", UriKind.Relative));
                ajouter_alerte.Content = img;
                info.Text = e.get_alerte().gettemps().ToString();
            }

        }


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(designation.Text) || string.IsNullOrEmpty(Lieu.Text) || string.IsNullOrEmpty(date.Text) || string.IsNullOrEmpty(debut.Text) || string.IsNullOrEmpty(fin.Text))
            {
                er.Visibility = System.Windows.Visibility.Visible;
            }

            else
            {
                DateTime d = Convert.ToDateTime(date.Text + " " + debut.Text);
                DateTime f = Convert.ToDateTime(date.Text + " " + fin.Text);
                if (f < d) erreur.Visibility = System.Windows.Visibility.Visible;
                else
                {
                    methodes m = new methodes();
                    
                        if (eve == null)
                        {  // adition d un nouveau evenement
                            if (m.Exist(d, f, id_user)) System.Windows.MessageBox.Show("occupé");
                            else
                            {
                                int id_new_event = m.save_event(designation.Text, d, f, Lieu.Text, this.id_user);
                                new_eve.update_event(designation.Text, Lieu.Text, d, f); ;
                                new_eve.setId(id_new_event);

                                alerte_class alert = new_eve.get_alerte();

                                if (alert != null)
                                {
                                    alert.setidévèn(id_new_event);
                                    alert.inserer_alerte_even(alert);
                                    m.Creer_tache_planif(alert, new_eve.getDesig(), new_eve.getDate(), "e");
                                }
                                foreach(document doc in list)
                                {
                                m.inserer_document_toevent(doc.getTitre(), doc.getEmplac(), id_user, id_new_event);
                                }
                                page.add_tolist(new_eve);
                                page.clear_listbox();
                                page.afficher(page.get_list());
                                Close();
                            }
                        }
                        else
                        {
                            if (m.Exist_modif_event(d, f, eve.getId(), eve.getId())) throw new Exception();
                            else
                            {
                                string olddesignation = eve.getDesig();
                                eve.update_event(designation.Text, Lieu.Text, d, f);
                                m.modifier_evenement(eve);
                                if (eve.get_alerte() != null)
                                {
                                    m.modifier_tache_planifiée(eve.get_alerte(), designation.Text, eve.getDate(), olddesignation, "e");
                                    (eve.get_alerte()).setidutilis(eve.getIdUtilis());
                                    (eve.get_alerte()).Modifier_aler_even_bdd((eve.get_alerte()).getidalerte(), (eve.get_alerte()));
                                }
                                page.clear_listbox();
                                page.afficher(page.get_list());
                                Close();
                            }
                        }
                    
                    

                }





            }
        }

        /* private void doc(object sender, RoutedEventArgs e)
         {
             page.listBox.SelectedIndex = page.listBox.Items.Count - 1;
             Add_doc win = new Add_doc(id_user, page.listBox.Items.Count - 1);
             win.Show();
         }*/


       /* private void ajouter(object sender, RoutedEventArgs e)
        {
            if (eve == null)
            {
                this.eve = new event_class();
                Alerte win = new Alerte(this, id_user,true);
            }
        }*/

        private void alert_Click(object sender, RoutedEventArgs e)
        {
            if (eve == null)
            {
                if (new_eve.get_alerte() == null)
                {
                    Alerte win = new Alerte(this, id_user, true);
                    win.Show();
                    this.Hide();
                }
                else
                {

                    modif_alerte win = new modif_alerte(new_eve.get_alerte(),new_eve,id_user, this);
                    win.Show();
                    this.Hide();
                }

            }
            else
            {
                if (eve.get_alerte() != null)
                {
                    
                    modif_alerte win = new modif_alerte(eve.get_alerte(), eve, eve.getId(), this);
                    win.Show();
                    this.Hide();
                }
                else
                {
                    Alerte win = new Alerte(this, id_user,false);
                    win.Show();
                    this.Hide();
                }

            }
        }
        public void set_alarm_tonew_event(alerte_class a)
        {
            new_eve.set_alerte(a);
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("modif2.png", UriKind.Relative));
            ajouter_alerte.Content = img;
            info.Text = new_eve.get_alerte().gettemps().ToString();
        }
        public void set_alarm_event(alerte_class a)
        {
            if (eve == null)
            {
                new_eve.set_alerte(a);
                info.Text = new_eve.get_alerte().gettemps().ToString();
            }
            else
            {
                eve.set_alerte(a);
                info.Text = eve.get_alerte().gettemps().ToString();
            }
                Image img = new Image();
            img.Source = new BitmapImage(new Uri("modif2.png", UriKind.Relative));
            ajouter_alerte.Content = img;
            

        }

        private void dock_Click(object sender, RoutedEventArgs e)
        {
            add_doc doc = new add_doc(this,id_user);
            doc.Show();
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void add_doc_toevent(document doc)
        {
            this.list.Add(doc);
        }
    }


}


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
    /// Interaction logic for add_act.xaml
    /// </summary>
    public partial class add_act : Window
    {
        private activ page;
        private int pos = -1;
        activ_class a;
        int id_user;
        int id_act;
        List<tache> taches;
        public add_act(activ p,int id)
        {
            this.id_user = id;
            this.page = p;
            this.a = null;
            this.id_act = -1;
            taches = new List<tache>();
            InitializeComponent();
            titre.Text = "Nouvelle activité";
        }
        public add_act()
        {
            InitializeComponent();
        }
        public add_act(activ_class con, activ page, int pos)
        {
            this.page = page;
            this.pos = pos;
            this.id_act = con.get_id();
            InitializeComponent();
            taches = new List<tache>();
            Designation_activité.Text = con.get_designation();
            titre.Text = "Modifier l'activité";
            bool itemExists = false;
            foreach (ComboBoxItem cbi in comboBox_type.Items)
            {
                itemExists = cbi.Content.Equals(con.get_type());
                if (itemExists) break;
            }
            if ( itemExists)
            {
                comboBox_type.Text = con.get_type();
            }
            else
            {
                comboBox_type.SelectedIndex = 2;
                autre_type.Visibility = System.Windows.Visibility.Visible;
                autre_type.Text = con.get_type();
            }
            textBlock1_Copy1.Visibility = Visibility.Collapsed;
            ajouter_tache.Visibility = Visibility.Collapsed;
        }

        public void add_tache_toactivity(tache t)
        {
            taches.Add(t);
        }
        private void ajouter_tache_Click(object sender, RoutedEventArgs e)
        {
            methodes m = new methodes();
            if (string.IsNullOrEmpty(Designation_activité.Text))
            {
                error.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                a = new activ_class(0, Designation_activité.Text, comboBox_type.Text, id_user);
                add_tache window = new add_tache(this,id_user);
                window.Show();
            }
        }

       
        string Le_Type;
        private void Creer_activite_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(Designation_activité.Text))
            {
                if (comboBox_type.SelectedIndex == 2)
                    
                {
                   
                    Le_Type = autre_type.Text;
                }
                else
                    Le_Type = comboBox_type.Text;
                if (string.IsNullOrEmpty(Le_Type)) textBlock_stp_type.Visibility = System.Windows.Visibility.Visible;
                else
                {
                    methodes m = new methodes();
                    List<activ_class> list = page.get_list();
                    if (pos == -1)
                    {
                        id_act = m.insert_Activite(Designation_activité.Text, Le_Type, id_user);
                        a = new activ_class(id_act, Designation_activité.Text, Le_Type, id_user);
                        page.add_tolist(a);
                        foreach (tache t in taches)
                        {
                            int id_tach = m.Save_Tache(t.get_des(),t.get_prio(),t.get_date(),t.getfin(),t.get_etat(),id_act, id_user);
                            if (id_tach != 0)
                            {
                                alerte_class alert = t.get_alert();
                               
                                if (alert != null)
                                {
                                    alert.setidtach(id_tach);
                                    alert.inserer_alerte_tache(alert);
                                    m.Creer_tache_planif(alert, t.get_des(), t.get_date(),"t");
                                }
                                List<document> list_docs = t.get_documents();
                                foreach (document doc in list_docs)
                                {
                                    m.inserer_document_totache(doc.getTitre(), doc.getEmplac(), id_user, id_tach);
                                }
                            }

                        }
                    }
                    else
                    {
                        
                        m.modif_Activ(list[pos], Designation_activité.Text,Le_Type);
                        foreach (tache t in taches)
                        {
                            int id_tach = m.Save_Tache(t.get_des(), t.get_prio(), t.get_date(), t.getfin(), t.get_etat(), id_act, id_user);
                            if (id_tach != 0)
                            {
                                alerte_class alert = t.get_alert();

                                if (alert != null)
                                {
                                    alert.setidtach(id_tach);
                                    alert.inserer_alerte_tache(alert);
                                    m.Creer_tache_planif(alert, t.get_des(), t.get_date(), "t");
                                }
                                List<document> list_docs = t.get_documents();
                                foreach (document doc in list_docs)
                                {
                                    m.inserer_document_totache(doc.getTitre(), doc.getEmplac(), id_user, id_tach);
                                }
                            }

                        }
                        list[pos].set_designation(Designation_activité.Text);
                        list[pos].set_type(Le_Type);
                        page.set_list(list);
                    }
                    page.clear_listbox();
                    page.afficher(page.get_list());

                    this.Close();
                }
            }
            else error.Visibility = System.Windows.Visibility.Visible;
        }

        private void textBox_disgnation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboBox_priorite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox_type.SelectedIndex == 2)
            {
                autre_type.Visibility = System.Windows.Visibility.Visible;

            }

            else
            {

                autre_type.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}

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
    /// Logique d'interaction pour modif_tache.xaml
    /// </summary>
    public partial class modif_tache : Window
    {
        private list_taches page;
        private int pos;
        private int id;
        private tache t;
        public modif_tache(tache t, list_taches page, int pos)
        {
            this.page = page;
            this.pos = pos;
            InitializeComponent();
            this.t = t;
            id = t.get_id();
            designationTextBox.Text = t.get_des();
            prioritéComboBox.Text = t.get_prio();
            dateDatePicker.Text = t.get_date().Date.ToString();
            débutTimePicker.Text= t.get_date().ToString("HH:mm");
            finTimePicker.Text = t.getfin().ToString("HH:mm");
            etatComboBox.Text = t.get_etat();
            if(t.get_alert() != null)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("modif2.png", UriKind.Relative));
                ajouter_alerte.Content = img;
                info.Text = t.get_alert().gettemps().ToString();
            }
            
        }
        public modif_tache()
        {
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
        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            methodes m = new methodes();
            if (string.IsNullOrEmpty(dateDatePicker.Text)|| string.IsNullOrEmpty(débutTimePicker.Text)|| string.IsNullOrEmpty(finTimePicker.Text))
            {
                System.Windows.Forms.MessageBox.Show(" Veillez Entrer la Date et/ou les Horaires !");
            }
            else
            {
                DateTime d = Convert.ToDateTime(dateDatePicker.Text + " " + débutTimePicker.Text);
                DateTime f = Convert.ToDateTime(dateDatePicker.Text + " " + finTimePicker.Text);


                if ((d > f) || (string.IsNullOrEmpty(designationTextBox.Text)))
                {
                    System.Windows.Forms.MessageBox.Show("Veuillez remplir tous les champs ou vérifier vos horaires !");
                }
                else
                {
                    if ((( d> DateTime.Now)&&((etatComboBox.Text=="Réalisée")||(etatComboBox.Text=="En cours"))))
                    {
                        //erreur.Visibility = System.Windows.Visibility.Visible;
                        System.Windows.Forms.MessageBox.Show("L'état de la tâche ne correspond pas à son intervalle du temps !");
                    }
                    else
                    {
                        if (m.Exist_modif_tach(d, f, id,t.get_id_user()))
                        {
                            System.Windows.Forms.MessageBox.Show("L'intervalle de temps donné est occupé veuillez le changer SVP");
                        }
                        else
                        {
                            List<tache> list = page.get_list();
                            string olddesignation = list[pos].get_des();
                            m.Update_Tache(list[pos], designationTextBox.Text, prioritéComboBox.Text, d, f, etatComboBox.Text);
                            if (list[pos].get_alert() != null)
                            {
                                m.modifier_tache_planifiée(list[pos].get_alert(), designationTextBox.Text, list[pos].get_date(), olddesignation, "t");
                                (list[pos].get_alert()).setidutilis(list[pos].get_id_user());
                                if(list[pos].get_alert().getidalerte() > 0)
                                (list[pos].get_alert()).Modifier_aler_tache_bdd((list[pos].get_alert()).getidalerte(), (list[pos].get_alert()));
                                else
                                {
                                    list[pos].get_alert().inserer_alerte_tache(list[pos].get_alert());
                                }
                            }
                            List<document> list_docs = t.get_documents();
                            foreach (document doc in list_docs)
                            {
                                if (doc.getId() <= 0)
                                {
                                    int id_doc = m.inserer_document_totache(doc.getTitre(), doc.getEmplac(), list[pos].get_id_user(), list[pos].get_id());
                                    doc.set_id(id_doc);
                                }
                               
                            }
                            list[pos].set_des(designationTextBox.Text);
                            list[pos].set_prio(prioritéComboBox.Text);
                            list[pos].set_date(d);
                            list[pos].setfin(f);
                            list[pos].set_etat(etatComboBox.Text);
                            page.clear_listbox();
                            page.afficher(list);

                            this.Close();
                        }
                    }
                }
            }
           
            
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void comboBox_priorite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DesignationTach_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void alert_Click(object sender, RoutedEventArgs e)
        {
            if (t.get_alert() != null)
            {
                
                modif_alerte win = new modif_alerte(t.get_alert(),t,t.get_id(),this);
                win.Show();
                this.Hide();

            }
            else
            {
                if (string.IsNullOrEmpty(designationTextBox.Text))
                {
                    er.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    Alerte win = new Alerte(t, this, t.get_id_user());
                    win.Show();
                    this.Hide();
                }
            }

        }

        private void dock_Click(object sender, RoutedEventArgs e)
        {//nrmlmnt machi par défaut
            add_doc win = new add_doc(this,id,t.get_id_user());
            win.Show();
            this.Hide();
        }
        public void add_doc_totache(document doc)
        {
            t.add_doc_to_tache(doc);
        }
    }
}

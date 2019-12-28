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
    /// Interaction logic for add_doc.xaml
    /// </summary>
    public partial class add_doc : Window
    {
        private int id_user;
        private add_tache ajouter_tache;
        private modif_tache modifier_tache;
        private AddEvent ajouter_event;
        private int id_tach;
        private event_class eve;
        private document doc;
        private document_page pge_docs;
        private docs_tache_events documents;
        public add_doc(add_tache page,int id_user)
        {
            ajouter_tache = page;
            this.id_user = id_user;
            InitializeComponent();
        }
        public add_doc(AddEvent page, int id_user)
        {
            ajouter_event = page;
            this.doc = null;
            ajouter_tache = null;
            this.id_user = id_user;
            InitializeComponent();
        }
        public add_doc(docs_tache_events page, int id_user,int id_tach)
        {
            documents = page;
            this.id_tach = id_tach;
            eve = null;
            this.id_user = id_user;
            InitializeComponent();
        }
        public add_doc(docs_tache_events page, int id_user,event_class eve)
        {
            documents = page;
            this.eve = eve;
            this.id_tach = -1;
            this.id_user = id_user;
            InitializeComponent();
        }
        public add_doc(modif_tache page,int id_tach, int id_user)
        {
            modifier_tache = page;
            this.id_user = id_user;
            this.id_tach = id_tach;
            this.doc = null;
            eve = null;
            InitializeComponent();
        }
        public add_doc(document_page page,document doc, int id_user)
        {
            pge_docs = page;
            eve = null;
            this.id_user = id_user;
            this.doc = doc;
            InitializeComponent();
            textBlock.Text = "Modifier le document";
            titre.Text = doc.getTitre();
            emplacement.Text = doc.getEmplac();
        }
        public add_doc(docs_tache_events page,document doc)
        {
            this.documents = page;
           
            this.doc = doc;
            InitializeComponent();
            textBlock.Text = "Modifier le document";
            titre.Text = doc.getTitre();
            emplacement.Text = doc.getEmplac();
            pge_docs = null;
            eve = null;
        }
        public add_doc()
        {
            InitializeComponent();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(titre.Text)||(string.IsNullOrEmpty(emplacement.Text)))
            {
                er.Visibility = Visibility.Visible;
            }
            else
            {
                
                if (ajouter_tache == null)
                {
                    if (doc == null)
                    {
                        if (this.documents == null)
                        {
                            if (ajouter_event == null)
                            {
                                //ajouter un nouveau document dans une tache modifié
                                document doc = new document(0, titre.Text, emplacement.Text, id_tach, 0, id_user);
                                modifier_tache.add_doc_totache(doc);
                                modifier_tache.Show();
                                this.Close();
                            }
                            else
                            {
                                document doc = new document(0, titre.Text, emplacement.Text,0, 0, id_user);
                                ajouter_event.add_doc_toevent(doc);
                                this.Close();
                            }
                        }
                        else
                        {
                            if (id_tach > 1)
                            {
                                // la page de document dans une tache
                                methodes m = new methodes();
                                int id = m.inserer_document_totache(titre.Text, emplacement.Text, id_user, id_tach);
                                document doc = new document(id, titre.Text, emplacement.Text, id_tach, -1, id_user);
                                documents.add_tolist(doc);
                                documents.clear_listbox();
                                documents.afficher(documents.get_list());
                                this.Close();
                            }
                            else
                            {
                                methodes m = new methodes();
                                int id = m.inserer_document_toevent(titre.Text, emplacement.Text, id_user,eve.getId());
                                document doc = new document(id, titre.Text, emplacement.Text,-1,id, id_user);
                                documents.add_tolist(doc);
                                documents.clear_listbox();
                                documents.afficher(documents.get_list());
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        
                        if (pge_docs == null)
                        {
                            // modifier a partir de la pge _docs_events_tache
                            methodes m = new methodes();
                            m.modifier_document(doc, titre.Text, emplacement.Text);
                            doc.setTitre(titre.Text);
                            doc.setEmplac(emplacement.Text);
                            documents.clear_listbox();
                            documents.afficher(documents.get_list());
                        }
                        else
                        {
                            // modifier a partir de la page generale//modifier le document a partir de la page document (home)
                            methodes m = new methodes();
                            m.modifier_document(doc, titre.Text, emplacement.Text);
                            doc.setTitre(titre.Text);
                            doc.setEmplac(emplacement.Text);
                            pge_docs.clear_listbox();
                            pge_docs.afficher(pge_docs.get_list());
                            this.Close();
                        }
                    }
                }
                else
                {
                    // ajouter un nouveau document dans une nouvelle tache
                    document doc = new document(0, titre.Text, emplacement.Text, 0, 0, id_user);
                    ajouter_tache.add_doc_totache(doc);
                    ajouter_tache.Show();
                    this.Close();
                }
            }
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void parcourir_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            emplacement.Text = dlg.FileName;
        }
    }
}
        
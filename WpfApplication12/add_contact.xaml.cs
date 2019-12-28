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
namespace WpfApplication12
{
    /// <summary>
    /// Interaction logic for add_contact.xaml
    /// </summary>
    public partial class add_contact : Window
    {
       private int id_user;
        private carnet_adr page;
        public add_contact(int id,carnet_adr page)
        {
            this.id_user = id;
            this.page = page;
            InitializeComponent();
        }
        private void contact_gotfocus(object sender, EventArgs e)
        {
            contact2.Visibility = System.Windows.Visibility.Collapsed;
            contact.Visibility = System.Windows.Visibility.Visible;
            contact.Focus();
        }
        private void contact_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(contact.Text))
            {
                contact.Visibility = System.Windows.Visibility.Collapsed;
                contact2.Visibility = System.Windows.Visibility.Visible;

            }

        }
        private void adr_gotfocus(object sender, EventArgs e)
        {
            adr2.Visibility = System.Windows.Visibility.Collapsed;
            adr.Visibility = System.Windows.Visibility.Visible;
            adr.Focus();
        }
        private void adr_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(adr.Text))
            {
                adr.Visibility = System.Windows.Visibility.Collapsed;
                adr2.Visibility = System.Windows.Visibility.Visible;

            }

        }
        private void tlphn_gotfocus(object sender, EventArgs e)
        {
            tlphn2.Visibility = System.Windows.Visibility.Collapsed;
            tlphn.Visibility = System.Windows.Visibility.Visible;
            tlphn.Focus();
        }
        private void tlphn_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tlphn.Text))
            {
                tlphn.Visibility = System.Windows.Visibility.Collapsed;
                tlphn2.Visibility = System.Windows.Visibility.Visible;

            }

        }
        private void mail_gotfocus(object sender, EventArgs e)
        {
            mail2.Visibility = System.Windows.Visibility.Collapsed;
            mail.Visibility = System.Windows.Visibility.Visible;
            mail.Focus();
        }
        private void mail_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tlphn.Text))
            {
                mail.Visibility = System.Windows.Visibility.Collapsed;
                mail2.Visibility = System.Windows.Visibility.Visible;

            }

        }
        private void site_gotfocus(object sender, EventArgs e)
        {
            site2.Visibility = System.Windows.Visibility.Collapsed;
            site.Visibility = System.Windows.Visibility.Visible;
            site.Focus();
        }
        private void site_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tlphn.Text))
            {
                site.Visibility = System.Windows.Visibility.Collapsed;
                site2.Visibility = System.Windows.Visibility.Visible;

            }

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void enregistrer(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contact.Text))
            {
                eror.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {

                methodes save = new methodes();
                int id_new_contact = save.save_contact(contact.Text, adr.Text, tlphn.Text,mail.Text,site.Text, this.id_user);
                contact new_con = new contact(id_new_contact, contact.Text, adr.Text, tlphn.Text, mail.Text, site.Text, this.id_user);
                page.add_tolist(new_con);
                page.clear_listbox();
                page.afficher(page.get_list());
                Close();

            }
        }
    }
}

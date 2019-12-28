using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for modify_contact.xaml
    /// </summary>
    public partial class modify_contact : Window
    {
        private carnet_adr page;
        private int pos;
       
        public modify_contact(contact con,carnet_adr page,int pos)
        {
            this.page = page;
            this.pos = pos;
         
            InitializeComponent();
            contact.Text = con.get_name();
            adr.Text = con.get_adr();
            tlphn.Text = con.get_num();
            mail.Text = con.get_mail();
            site.Text = con.get_site();
        }

        private void enregistrer(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contact.Text))
            {
                eror.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                methodes save_changes = new methodes();
                List<contact> list = page.get_list();
                save_changes.modif_contact(list[pos],contact.Text, adr.Text, tlphn.Text, mail.Text, site.Text);
                list[pos].set_name(contact.Text);
                list[pos].set_adr(adr.Text);
                list[pos].set_num(tlphn.Text);
                list[pos].set_mail(mail.Text);
                list[pos].set_site(site.Text);
                page.clear_listbox();
                page.afficher(list);
                this.Close();
            }
        }
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

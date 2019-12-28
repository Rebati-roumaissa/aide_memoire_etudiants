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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace WpfApplication12
{
    /// <summary>
    /// Interaction logic for carnet_adr.xaml
    /// </summary>
    public partial class carnet_adr : Page
    {
        private int id_user; 
        private List<contact> list;
        public carnet_adr(int id)
        {
            this.id_user = id;
            InitializeComponent();
            carnet c = new carnet();
            List<contact> contact = c.afficher(id);
            this.list = contact;
            this.afficher(list);
        }
        public void add_tolist(contact c)
        {
            this.list.Add(c);
        }
        public List<contact> get_list()
        {
            return list;
        }
        public void clear_listbox()
        {
            listBox.Items.Clear();
        }
        public void afficher(List<contact> list)
        {
            foreach (contact con in list)
            {
                Expander Item = new Expander();
                //header of expander
                StackPanel big = new StackPanel();
                big.Orientation = Orientation.Horizontal;
                big.HorizontalAlignment = HorizontalAlignment.Left;
                big.Width = 1200;
                StackPanel info = new StackPanel();
                info.Orientation = Orientation.Horizontal;
                info.Width = 1050;
                Image symb = new Image();
                symb.Source = new BitmapImage(new Uri("contact.png", UriKind.Relative));
                symb.Height = 30;
                symb.Width = 50;
                Label lbl = new Label();
                lbl.Content = con.get_name();
                CheckBox check = new CheckBox();
                info.Children.Add(check);
                check.Margin = new Thickness(5,10,0,0);
                
                info.Children.Add(symb);
                info.Children.Add(lbl);

                //add some buttons to header
                //modify
                StackPanel option = new StackPanel();
                option.Orientation = Orientation.Horizontal;
                option.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                option.Width = 80;
                Button modif = new Button();
                Image ch = new Image();
                ch.Source = new BitmapImage(new Uri("modif.png", UriKind.Relative));

                modif.Content = ch;
                modif.Height = 30;
                modif.Width = 30;
                modif.Background = null;
                modif.Click += new RoutedEventHandler(modif_Click);
                option.Children.Add(modif);

                //delete button
                Button delete = new Button();
                Image del = new Image();
                del.Source = new BitmapImage(new Uri("delete1.png", UriKind.Relative));
                delete.Click += new RoutedEventHandler(delete_Click);
                delete.Content = del;
                delete.Height = 30;
                delete.Width = 30;
                delete.Background = null;
                option.Children.Add(delete);
                big.Children.Add(info);
                //stack in the middle
                /* StackPanel mid = new StackPanel();
                 mid.Width = 500;
                 big.Children.Add(mid);*/
                big.Children.Add(option);
                Item.Header = big;

                //grid of expander
                StackPanel bigstack = new StackPanel();
                bigstack.Width = 690;
                //adr

                StackPanel stack1 = new StackPanel();
                stack1.Orientation = Orientation.Horizontal;
                Image symb1 = new Image();
                symb1.Source = new BitmapImage(new Uri("home.png", UriKind.Relative));
                symb1.Height = 25;
                symb1.Width = 40;
                Label lbl1 = new Label();
                lbl1.Content = con.get_adr();
                stack1.Children.Add(symb1);
                stack1.Children.Add(lbl1);
                bigstack.Children.Add(stack1);
                //tel
                symb1 = new Image();
                symb1.Source = new BitmapImage(new Uri("tlphn2.png", UriKind.Relative));
                symb1.Height = 25;
                symb1.Width = 40;
                lbl1 = new Label();
                lbl1.Content = con.get_num();
                stack1 = new StackPanel();
                stack1.Orientation = Orientation.Horizontal;
                stack1.Children.Add(symb1);
                stack1.Children.Add(lbl1);
                bigstack.Children.Add(stack1);
                //mail
                Image mailpic = new Image();
                mailpic.Source = new BitmapImage(new Uri("adr.png", UriKind.Relative));
                mailpic.Height = 25;
                mailpic.Width = 40;
                lbl1 = new Label();
                lbl1.Content = con.get_mail();
                stack1 = new StackPanel();
                stack1.Orientation = Orientation.Horizontal;
                stack1.Children.Add(mailpic);
                stack1.Children.Add(lbl1);
                bigstack.Children.Add(stack1);
                //site web
                Image web = new Image();
                web.Source = new BitmapImage(new Uri("siteweb.png", UriKind.Relative));
                web.Height = 25;
                web.Width = 40;
                lbl1 = new Label();
                lbl1.Content = con.get_site();
                stack1 = new StackPanel();
                stack1.Orientation = Orientation.Horizontal;
                stack1.Children.Add(web);
                stack1.Children.Add(lbl1);
                bigstack.Children.Add(stack1);
                bigstack.Width = 1100;
                Item.Content = bigstack;
                listBox.Items.Add(Item);
            }
        }

        private void modif_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                var st = FindParent<Expander>(btn); //stackpanel as we have added item as stackpanel.
                if (st != null)
                {
                    int index = listBox.Items.IndexOf(st);
                    modify_contact win = new modify_contact(list[index],this,index);
                    win.Show();
                }
            }
        }
        public T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as T;
            return parentT ?? FindParent<T>(parent);
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult reslt = System.Windows.MessageBox.Show("Voulez-vous vraiment supprimer cet élément ?", "Confirmation", MessageBoxButton.YesNo);
            if (reslt == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    var st = FindParent<Expander>(btn); //stackpanel as we have added item as stackpanel.
                    if (st != null)
                    {
                        int index = listBox.Items.IndexOf(st);
                        methodes m = new methodes();
                        m.delete_contact(list[index]);
                        listBox.Items.Remove(st);
                        list.Remove(list[index]);

                    }
                }
            }
            else { }
        }
        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                modify_contact window = new modify_contact(list[listBox.SelectedIndex],this,listBox.SelectedIndex);
                window.Owner = MainWindow.GetWindow(this);
                window.Show();
            }
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            add_contact win = new add_contact(id_user,this);
            win.Show();
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox.Text))
            {
                listBox.Items.Clear();
                afficher(list);
            }
        }

        private void materialButton_Click(object sender, RoutedEventArgs e)
        {
            if(! string.IsNullOrEmpty(textBox.Text))
            {
                listBox.Items.Clear();
                methodes m = new methodes();
                List<contact> newlist = m.look_list(textBox.Text, comboBox.SelectedIndex, id_user);
                afficher(newlist);
            }

           
        }

        
      void ch_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (Expander i in listBox.Items)
            {
                CheckBox ch = GetChildOfType< CheckBox > (i);
                ch.IsChecked = true;
            }
        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (Expander i in listBox.Items)
            {
                CheckBox ch = GetChildOfType<CheckBox>(i);
                ch.IsChecked = false;
            }
        }
        public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

       void mul_del(object sender, RoutedEventArgs e)
        {
            MessageBoxResult reslt = System.Windows.MessageBox.Show("Voulez-vous vraiment supprimer ces éléments ?", "Confirmation", MessageBoxButton.YesNo);
            if (reslt == MessageBoxResult.Yes)
            {
                List<int> ind = new List<int>();
                foreach (Expander i in listBox.Items)
                {

                    CheckBox ch = GetChildOfType<CheckBox>(i);
                    if (ch.IsChecked.Value)
                    {
                        int index = listBox.Items.IndexOf(i);
                        methodes m = new methodes();
                        m.delete_contact(list[index]);
                        ind.Add(index);
                    }


                }
                int cpt = 0;

                foreach (int x in ind)
                {

                    list.Remove(list[x - cpt]);
                    listBox.Items.Remove(listBox.Items[x - cpt]);
                    cpt++;
                }
            }
            else { }  
           
        }
    }
}

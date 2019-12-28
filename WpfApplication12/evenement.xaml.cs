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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication12
{
    /// <summary>
    /// Interaction logic for evenement.xaml
    /// </summary>
    public partial class evenement : Page
    {
        utilisateur user;
        List<event_class> list;
        acceuil home;
        public evenement(utilisateur user,acceuil home)
        {
            this.user = user;
            this.home = home;
            methodes m = new methodes();
            this.list = m.event_list(user.getid_utilis());
            InitializeComponent();
            afficher(list);
        }

        public void afficher(List<event_class> list)
        {
            foreach (event_class con in list)
            {
                Grid Item = new Grid();
                //header
                StackPanel big = new StackPanel();
                big.Orientation = Orientation.Horizontal;
                big.HorizontalAlignment = HorizontalAlignment.Left;
                big.Width = 1200;

                /*StackPanel info = new StackPanel();
                info.Orientation = Orientation.Horizontal;
                info.Width = 670;
                /*Label lbl = new Label();
                lbl.Content = con.get_des();
                CheckBox check = new CheckBox();
                info.Children.Add(check);
                check.Margin = new Thickness(5, 10, 5, 0);
                info.Children.Add(lbl);*/

               

                StackPanel info = new StackPanel();
                info.Orientation = Orientation.Horizontal;
                info.Width = 470;

                Label lbl = new Label();
                lbl.Content = con.getDesig();
                CheckBox check = new CheckBox();
                info.Children.Add(check);
                
                check.Margin = new Thickness(17, 12, 5, 0);
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
                option.Margin = new Thickness(600, -130, 0, 0);

                DropShadowBitmapEffect shadow = new DropShadowBitmapEffect();
                shadow.Direction = 320;
                shadow.Opacity = 0.6;
                Item.BitmapEffect = shadow;
                BrushConverter bc = new BrushConverter();
                Item.Background = (Brush)bc.ConvertFrom("#FFFFFF");

                big.Children.Add(option);
                Item.Children.Add(big);

                //grid of expander
                StackPanel bigstack = new StackPanel();
                bigstack.Width = 600;

                //priorité

                /*StackPanel stack1 = new StackPanel();
                stack1.Orientation = Orientation.Horizontal;
                Label symb1 = new Label();
                symb1.Content = "Priorité :"; ;
                symb1.Height = 30;
                symb1.Width = 122;
                Label lbl1 = new Label();
                lbl1.Content = con.get_prio();
                stack1.Children.Add(symb1);
                stack1.Children.Add(lbl1);
                stack1.Margin = new Thickness(0, 30, 0, 0);
                bigstack.Children.Add(stack1);*/

                //lieu

                StackPanel stack2 = new StackPanel();
                stack2.Orientation = Orientation.Horizontal;
                Label symb2 = new Label();
                symb2.Content = "Lieu :"; ;
                symb2.Height = 30;
                symb2.Width = 122;
                Label lbl2 = new Label();
                lbl2.Content = con.getLieu();
                stack2.Children.Add(symb2);
                stack2.Children.Add(lbl2);
                stack2.Margin = new Thickness(0, 30, 0, 0);
                bigstack.Children.Add(stack2);

                //temps

                StackPanel stack3 = new StackPanel();
                stack3.Orientation = Orientation.Horizontal;
                Label symb3 = new Label();
                symb3.Content = "Date :"; ;
                symb3.Height = 30;
                symb3.Width = 122;
                Label lbl3 = new Label();
                lbl3.Content = con.getDate().Date.ToString("dd/MM/yyyy");
                stack3.Children.Add(symb3);
                stack3.Children.Add(lbl3);
                bigstack.Children.Add(stack3);

                StackPanel stack4 = new StackPanel();
                stack4.Orientation = Orientation.Horizontal;
                Label symb4 = new Label();
                symb4.Content = "Heure Début :"; ;
                
                symb4.Width = 122;
                Label lbl4 = new Label();
                lbl4.Margin = new Thickness(0, 1, 0, 0);
                lbl4.Content = con.getDate().ToString("HH:mm");
                stack4.Children.Add(symb4);
                stack4.Children.Add(lbl4);
                bigstack.Children.Add(stack4);

                StackPanel stack5 = new StackPanel();
                stack5.Orientation = Orientation.Horizontal;
                Label symb5 = new Label();
                symb5.Content = "Heure Fin :"; ;
                symb5.Height = 30;
                symb5.Width = 122;
                Label lbl5 = new Label();
                symb5.Margin = new Thickness(0, -10, 0, 0);
                lbl5.Content = con.getFin().ToString("HH:mm");
                stack5.Children.Add(symb5);
                stack5.Children.Add(lbl5);
                bigstack.Children.Add(stack5);
                bigstack.Margin = new Thickness(-500, 0, 0, 0);
                Item.Children.Add(bigstack);
                
                alerte_class a = con.get_alerte();
                if (a != null)
                {
                    StackPanel stackofalert = new StackPanel();
                   
                    option.Margin = new Thickness(600, -165, 0, 0);
                    stackofalert.Orientation = Orientation.Horizontal;
                    stackofalert.Width = 1200;
                    Image reveil = new Image();
                    reveil.Source = new BitmapImage(new Uri("reveil.png", UriKind.Relative));
                    reveil.Height = 20;
                    reveil.Width = 20;

                    stackofalert.Children.Add(reveil);
                    Label labl6 = new Label();
                    labl6.Content = a.gettemps().ToString("dd/MM/yyyy HH:mm");
                    stackofalert.Children.Add(labl6);
                    //modify
                    StackPanel options_alerte = new StackPanel();
                    options_alerte.Orientation = Orientation.Horizontal;
                    options_alerte.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    options_alerte.Width = 80;
                    Button modify = new Button();
                    Image pen = new Image();
                    pen.Source = new BitmapImage(new Uri("modif.png", UriKind.Relative));

                    modify.Content = pen;
                    modify.Height = 30;
                    modify.Width = 30;
                    modify.Background = null;
                    modify.Click += new RoutedEventHandler(modifyAlert_Click);
                    options_alerte.Children.Add(modify);


                    options_alerte.Margin = new Thickness(800, 0, 0, 0);
                    //delete button
                    Button supp = new Button();
                    Image su = new Image();
                    su.Source = new BitmapImage(new Uri("delete1.png", UriKind.Relative));
                    supp.Click += new RoutedEventHandler(deleteAlert_Click);
                    supp.Content = su;
                    supp.Height = 30;
                    supp.Width = 30;
                    supp.Background = null;
                    options_alerte.Children.Add(supp);
                    stackofalert.Margin = new Thickness(100, 160, 0, 0);
                    stackofalert.Children.Add(options_alerte);
                    Item.Children.Add(stackofalert);


                }
                listBox.Items.Add(Item);
            }
        }
        private void modifyAlert_Click(object sender, RoutedEventArgs e)
        {
           Button btn = (Button)sender;
            if (btn != null)
            {
                var st = FindParent<Grid>(btn); //stackpanel as we have added item as stackpanel.
                if (st != null)
                {
                    int index = listBox.Items.IndexOf(st);
                    modif_alerte win = new modif_alerte(list[index], user.getid_utilis(), this);
                    win.Show();
                }
            }
        }
        private void deleteAlert_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult reslt = MessageBox.Show("Voulez-vous vraiment supprimer cet élément ?", "Confirmation", MessageBoxButton.YesNo);
            if (reslt == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    var st = FindParent<Grid>(btn); //stackpanel as we have added item as stackpanel.
                    if (st != null)
                    {
                        int index = listBox.Items.IndexOf(st);
                        methodes m = new methodes();
                        m.supprimer_alerte_planifiée(list[index].getDesig());
                        list[index].get_alerte().supprimer(list[index].get_alerte());
                        listBox.Items.Clear();
                        list[index].set_alerte(null);
                        //this.list = m.event_list(activité.get_id(), actget_id_user());
                        afficher(this.list);


                    }
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
        private void modif_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                var st = FindParent<Grid>(btn); //stackpanel as we have added item as stackpanel.
                if (st != null)
                {
                    int index = listBox.Items.IndexOf(st);
                    AddEvent win = new AddEvent(list[index],this);
                    win.Show();
                }
            }
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult reslt = MessageBox.Show("Voulez-vous vraiment supprimer cet élément ?", "Confirmation", MessageBoxButton.YesNo);
            if (reslt == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    var st = FindParent<Grid>(btn); //stackpanel as we have added item as stackpanel.
                    if (st != null)
                    {
                        int index = listBox.Items.IndexOf(st);
                        methodes m = new methodes();
                        m.delete_event(list[index]);
                        listBox.Items.Remove(st);
                        list.Remove(list[index]);

                    }
                }
            }
            else { }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddEvent win = new AddEvent(user.getid_utilis(),this);
            win.Show();
        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (Grid i in listBox.Items)
            {
                CheckBox ch = GetChildOfType<CheckBox>(i);
                ch.IsChecked = false;
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (Grid i in listBox.Items)
            {
                CheckBox ch = GetChildOfType<CheckBox>(i);
                ch.IsChecked = true;
            }
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox.Text))
            {
                listBox.Items.Clear();
                methodes m = new methodes();
                this.list = m.event_list(user.getid_utilis());
                afficher(list);
            }
        }

        private void research_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                listBox.Items.Clear();
                methodes m = new methodes();
                List<event_class> newlist = m.look_list_event(textBox.Text, comboBox.SelectedIndex, user.getid_utilis());
                afficher(newlist);
            }
        }
        void mul_del(object sender, RoutedEventArgs e)
        {
            MessageBoxResult reslt = MessageBox.Show("Voulez-vous vraiment supprimer ces éléments ?", "Confirmation", MessageBoxButton.YesNo);
            if (reslt == MessageBoxResult.Yes)
            {
                List<int> ind = new List<int>();
                foreach (Grid i in listBox.Items)
                {

                    CheckBox ch = GetChildOfType<CheckBox>(i);
                    if (ch.IsChecked.Value)
                    {
                        int index = listBox.Items.IndexOf(i);
                        methodes m = new methodes();
                        m.delete_event(list[index]);
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
         /*   void mul_del(object sender, RoutedEventArgs e)
        {
            List<int> ind = new List<int>();
            foreach (Expander i in listBox.Items)
            {

                CheckBox ch = GetChildOfType<CheckBox>(i);
                if (ch.IsChecked.Value)
                {
                    int index = listBox.Items.IndexOf(i);
                    methodes m = new methodes();
                    m.delete_event(list[index]);
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


        }*/
        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                docs_tache_events page = new docs_tache_events(user.getid_utilis(), list[listBox.SelectedIndex], this, home);
                home.set_frame(page);               
            }
        }
        public void add_tolist(event_class new_eve)
        {
            this.list.Add(new_eve);
        }
        public void clear_listbox()
        {
            listBox.Items.Clear();
        }
        public List<event_class> get_list()
        {
            return list;
        }
    }
}

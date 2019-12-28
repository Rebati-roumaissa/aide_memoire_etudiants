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
using System.Diagnostics;
using System.Windows.Media.Effects;
using System.IO;

namespace WpfApplication12
{
    /// <summary>
    /// Interaction logic for docs_tache_events.xaml
    /// </summary>
    public partial class docs_tache_events : Page
    {
        private int id_user;
        private tache t;
        private event_class eve;
        private list_taches taches;
        private evenement events;
        private List<document> list;
        private acceuil home;
        public docs_tache_events(int id_user,tache t, list_taches taches,acceuil home)
        {
            this.id_user = id_user;
            this.t = t;
            this.eve = null;
            this.events = null;
            this.taches = taches;
            InitializeComponent();
            info.Text = t.get_des();
            this.home = home;
            methodes m = new methodes();
            list = m.docs_of_tache(t.get_id(), id_user);
            afficher(list);
            
        }
        public docs_tache_events(int id_user, event_class eve, evenement events,acceuil home)
        {
            this.id_user = id_user;
            this.t = null;
            this.eve = eve;
            this.events = events;
            this.taches = null;
            this.home = home;
            InitializeComponent();
            info.Text = eve.getDesig();
            methodes m = new methodes();
            list = m.docs_of_event(eve.getId(), id_user);
            afficher(list);
        }
        private void list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void afficher(List<document> list)
        {

            foreach (document con in list)
            {
                Grid Item = new Grid();
                //header of expander
                StackPanel big = new StackPanel();
                big.Orientation = Orientation.Horizontal;
                big.HorizontalAlignment = HorizontalAlignment.Left;
                big.Width = 1200;
                StackPanel info = new StackPanel();
                info.Orientation = Orientation.Horizontal;
                info.Width = 670;
                Label lbl = new Label();
                lbl.Content = con.getTitre();
                CheckBox check = new CheckBox();
                info.Children.Add(check);
                check.Margin = new Thickness(5, 10, 0, 0);
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

                Button open = new Button();
                Image ope = new Image();
                ope.Height = 25;
                ope.Width = 25;
                ope.Source = new BitmapImage(new Uri("d.png", UriKind.Relative));
                open.Click += new RoutedEventHandler(open_Click);
                open.Content = ope;
                open.Height = 30;
                open.Width = 30;
                open.Background = null;
                option.Children.Add(open);
                option.Width = 90;
                big.Children.Add(info);

                option.Margin = new Thickness(400, 0, 0, 0);
                big.Children.Add(option);
                Item.Children.Add(big);
                DropShadowBitmapEffect shadow = new DropShadowBitmapEffect();
                shadow.Direction = 320;
                shadow.Opacity = 0.6;
                Item.BitmapEffect = shadow;
                BrushConverter bc = new BrushConverter();
                Item.Background = (Brush)bc.ConvertFrom("#FFFFFF");
                list_box.Items.Add(Item);
            }
        }
        public List<document> get_list()
        {
            return list ;
        }
        public void clear_listbox()
        {
            list_box.Items.Clear();
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                var st = FindParent<Grid>(btn); //stackpanel as we have added item as stackpanel.
                if (st != null)
                {
                    int index = list_box.Items.IndexOf(st);
                    var programPath = @list[index].getEmplac();
                    if (!File.Exists(programPath))
                    {
                        MessageBox.Show("ce fichier n existe pas, veuillez verifier l'emplacement de votre fichier");
                        return;
                    }
                   else  Process.Start(programPath);
                    //Process.Start(@list[index].getEmplac());
                }
            }
        }
        private void modif_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                var st = FindParent<Grid>(btn); //stackpanel as we have added item as stackpanel.
                if (st != null)
                {
                    int index = list_box.Items.IndexOf(st);
                    add_doc win = new add_doc(this,list[index]);
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
            MessageBoxResult reslt = MessageBox.Show("Voulez-vous vraiment supprimer cet élément ?", "Confirmation", MessageBoxButton.YesNo);
            if (reslt == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    var st = FindParent<Grid>(btn); //stackpanel as we have added item as stackpanel.
                    if (st != null)
                    {
                        int index = list_box.Items.IndexOf(st);

                        methodes m = new methodes();
                        m.supprimer_document(list[index]);
                        list_box.Items.Remove(st);
                        list.Remove(list[index]);

                    }
                }
            }
            else { }
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (eve == null)
            {
                add_doc win = new add_doc(this, id_user, t.get_id());
                win.Show();
            }
            else
            {
                add_doc win = new add_doc(this, id_user,eve);
                win.Show();
            }
        }



        private void materialButton_Click(object sender, RoutedEventArgs e)
        {

        }



        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (list_box.SelectedItem != null)
            {
                // modify_doc win = new modify_doc(list[listBox.SelectedIndex], user.getid_utilis(), this, listBox.SelectedIndex);
                // win.Owner = MainWindow.GetWindow(this);
                // win.Show();

            }
        }

        private void materialButton1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (Grid i in list_box.Items)
            {
                CheckBox ch = GetChildOfType<CheckBox>(i);
                ch.IsChecked = true;
            }
        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (Grid i in list_box.Items)
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
            MessageBoxResult reslt = MessageBox.Show("Voulez-vous vraiment supprimer ces éléments ?", "Confirmation", MessageBoxButton.YesNo);
            if (reslt == MessageBoxResult.Yes)
            {
                List<int> ind = new List<int>();
                foreach (Grid i in list_box.Items)
                {

                    CheckBox ch = GetChildOfType<CheckBox>(i);
                    if (ch.IsChecked.Value)
                    {
                        int index = list_box.Items.IndexOf(i);
                        methodes m = new methodes();
                        m.supprimer_document(list[index]);
                        ind.Add(index);
                    }


                }
                int cpt = 0;

                foreach (int x in ind)
                {

                    list.Remove(list[x - cpt]);
                    list_box.Items.Remove(list_box.Items[x - cpt]);
                    cpt++;
                }
            }
            else { }

        }



    
        public void set_list(List<document> l)
        {
            this.list = l;
        }
        public void add_tolist(document a)
        {
            this.list.Add(a);
        }

        private void retourner_Click(object sender, RoutedEventArgs e)
        {
            if(events == null)
            {
                home.set_frame(taches);
            }
            else
            {
                home.set_frame(events);
            }

        }
    }
}
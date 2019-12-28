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
    /// Interaction logic for activ.xaml
    /// </summary>
    public partial class activ : Page
    {
        utilisateur user;
        private List<activ_class> list;
        private acceuil page;
        public activ(utilisateur user,acceuil page)
        {
            this.user = user;
            this.page = page;
            InitializeComponent();
           
            list= new List<activ_class>();
            methodes m = new methodes();
            list = m.list_activ(user.getid_utilis());    
            afficher(list);
        }

        public void afficher(List<activ_class> list)
        {
            
            foreach (activ_class con in list)
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
                Label symb = new Label();
                symb.Content = con.get_designation();
                symb.Height = 40;
                symb.Width = 400;
                symb.Margin = new Thickness(0, -30, 0, 0);
                //Label lbl = new Label();
                //lbl.Content = con.get_designation();
                CheckBox check = new CheckBox();
                info.Children.Add(check);
                check.Margin = new Thickness(5, 10, 0, 0);

                info.Children.Add(symb);
                //info.Children.Add(lbl);

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
                option.Margin = new Thickness(400, -30, 0, 0);
                big.Children.Add(option);
                Item.Children.Add(big);

                //grid of expander
                StackPanel bigstack = new StackPanel();
                bigstack.Width = 790;
                //type

                StackPanel stack1 = new StackPanel();
                stack1.Orientation = Orientation.Horizontal;
                Label symb1 = new Label();
                symb1.Content = con.get_type();
                symb1.Height = 40;
                symb1.Width = 400;
               
                //Label lbl1 = new Label();
                //lbl1.Content = con.get_type();
                stack1.Children.Add(symb1);
                //stack1.Children.Add(lbl1);
                bigstack.Children.Add(stack1);
                stack1.Margin = new Thickness(-180, 30, 0, 0);
                DropShadowBitmapEffect shadow = new DropShadowBitmapEffect();
                shadow.Direction = 320;
                shadow.Opacity = 0.6;
                Item.BitmapEffect = shadow;
                BrushConverter bc = new BrushConverter();
                Item.Background = (Brush)bc.ConvertFrom("#FFFFFF");
                Item.Children.Add(bigstack);
                listBox.Items.Add(Item);
            }
        }
        public List<activ_class> get_list()
        {
            return list;
        }
        public void clear_listbox()
        {
            listBox.Items.Clear();
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
                    add_act win = new add_act(list[index], this, index);
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
                        int index = listBox.Items.IndexOf(st);

                        methodes m = new methodes();
                        m.delete_activ(list[index]);
                        listBox.Items.Remove(st);
                        list.Remove(list[index]);

                    }
                }
            }
            else { }
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            add_act win = new add_act(this,user.getid_utilis());
            win.Show();
        }

       

        private void materialButton_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                list_taches window = new list_taches(list[listBox.SelectedIndex],user, this,page);
                page.set_frame(window);
                
            }
        }

        private void materialButton1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (Grid i in listBox.Items)
            {
                CheckBox ch = GetChildOfType<CheckBox>(i);
                ch.IsChecked = true;
            }
        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (Grid i in listBox.Items)
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
                foreach (Grid i in listBox.Items)
                {

                    CheckBox ch = GetChildOfType<CheckBox>(i);
                    if (ch.IsChecked.Value)
                    {
                        int index = listBox.Items.IndexOf(i);
                        methodes m = new methodes();
                        m.delete_activ(list[index]);
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

       

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                listBox.Items.Clear();
                afficher(list);
            }
        }

        private void research_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                listBox.Items.Clear();
                methodes m = new methodes();
                List<activ_class> newlist = m.look_activ(textBox.Text, comboBox.SelectedIndex,user.getid_utilis());
                afficher(newlist);
            }


        }
        public void set_list(List<activ_class> l)
        {
            this.list = l;
        }
        public void add_tolist(activ_class a)
        {
           this.list.Add(a);
        }
       
    }
}

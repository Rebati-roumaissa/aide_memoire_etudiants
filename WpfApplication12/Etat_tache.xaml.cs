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
    /// Interaction logic for Etat_tache.xaml
    /// </summary>
    public partial class Etat_tache : Page
    {
        private utilisateur user;
        List<tache> todo;
        private List<tache> doing;
        private List<tache> did;
        private List<tache> list;
        int index = -1;
        ListBoxItem _dragged;
        ListBox dragSource = null;
        

        public Etat_tache(utilisateur user)
        {
            InitializeComponent();
            this.user = user;

            this.list = new List<tache>();
            methodes m = new methodes();
            DateTime date1 = System.DateTime.Now;
            DateTime dateOnly = date1.Date;
            List<tache> l = m.etat(user.getid_utilis(), dateOnly);
            
            this.todo = new List<tache>();
            this.doing = new List<tache>();
            this.did = new List<tache>();

            foreach (tache t in l)
            {
                switch (t.get_etat())
                {
                    case "Non réalisée":
                        this.todo.Add(t);
                        break;
                    case "En cours":
                        this.doing.Add(t);
                        break;
                    case "Réalisée":
                        this.did.Add(t);
                        break;

                }

            }

            affich_list(todo, faire);
            affich_list(doing, cours);
            affich_list(did, faite);
            
        }
        public void affich_list(List<tache> list, ListBox listBox)
        {
            foreach (tache t in list)
            {

                Grid Item = new Grid();
                //header of expander
                StackPanel big = new StackPanel();
                big.Orientation = Orientation.Horizontal;
                big.HorizontalAlignment = HorizontalAlignment.Left;

                
                Image prio = new Image();
                prio.Height = 25;
                prio.Width = 25;
                prio.Margin = new Thickness(5, -3, 0, 0);
                switch (t.get_prio())
                {
                    case "Elevée":
                        prio.Source = new BitmapImage(new Uri("prio_elevé.png", UriKind.Relative));
                        break;
                    case "Moyenne":
                        prio.Source = new BitmapImage(new Uri("pro.png", UriKind.Relative));
                        break;
                    case "Faible":
                        prio.Source = new BitmapImage(new Uri("prio_faible.png", UriKind.Relative));
                        break;
                }

                StackPanel info = new StackPanel();
                info.Orientation = Orientation.Horizontal;
                info.Width = 300;
                info.Children.Add(prio);
                Label lbl = new Label();
                lbl.Content = t.get_des();
                lbl.Width = 300;
                info.Children.Add(lbl);

                DropShadowBitmapEffect shadow = new DropShadowBitmapEffect();
                shadow.Direction = 320;
                shadow.Opacity = 0.6;
                Item.BitmapEffect = shadow;

                big.Children.Add(info);

                SolidColorBrush w = new SolidColorBrush(Colors.White);
                Item.Background = w;
                StackPanel header = new StackPanel();
                header.Children.Add(big);


                StackPanel bigstack = new StackPanel();
                bigstack.Width = 200;

                StackPanel stack3 = new StackPanel();
                stack3.Orientation = Orientation.Horizontal;
                Label symb3 = new Label();
                symb3.Content = "Date :"; ;
                symb3.Height = 30;
                symb3.Width = 122;
                Label lbl3 = new Label();
                lbl3.Content = t.get_date().Date.ToString("dd/MM/yyyy");
                stack3.Children.Add(symb3);
                stack3.Children.Add(lbl3);
                bigstack.Children.Add(stack3);

                StackPanel stack4 = new StackPanel();
                stack4.Orientation = Orientation.Horizontal;
                Label symb4 = new Label();
                symb4.Content = "Heure Début :"; ;
                symb4.Height = 30;
                symb4.Width = 122;
                Label lbl4 = new Label();
                lbl4.Content = t.get_date().ToString("HH:mm");
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
                lbl5.Content = t.getfin().ToString("HH:mm");
                stack5.Children.Add(symb5);
                stack5.Children.Add(lbl5);
                bigstack.Children.Add(stack5);
                header.Children.Add(bigstack);
                Item.Children.Add(header);
                Item.Width = 300;

                listBox.Items.Add(Item);
            }
        }

        public T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as T;
            return parentT ?? FindParent<T>(parent);

        }





        private void faite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void faire_MouseUp(object sender, MouseButtonEventArgs e)
        {

            ListBoxItem i = sender as ListBoxItem;
            
            if (i != null)
            {
                DataObject data = new DataObject(typeof(ListBoxItem));
                DragDropEffects dde1 = DragDrop.DoDragDrop(_dragged, data, DragDropEffects.Move);
            }
        }
        private void cours_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem i = sender as ListBoxItem;
            if (i != null)
            {
                DataObject data = new DataObject(typeof(ListBoxItem));
                DragDropEffects dde1 = DragDrop.DoDragDrop(_dragged, data, DragDropEffects.Move);
            }
        }
        private void faite_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem i = sender as ListBoxItem;
            if (i != null)
            {
                DataObject data = new DataObject(typeof(ListBoxItem));
                DragDropEffects dde1 = DragDrop.DoDragDrop(_dragged, data, DragDropEffects.Move);
            }
        }

        private void faire_MouseDown(object sender, MouseButtonEventArgs e)
        {

            ListBoxItem i = sender as ListBoxItem;
            if (i != null)
            {
                DataObject data = new DataObject(typeof(ListBoxItem), i);
                DragDropEffects dde1 = DragDrop.DoDragDrop(_dragged, data, DragDropEffects.Move);
            }
        }
        private void cours_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem i = sender as ListBoxItem;
            if (i != null)
            {
                DataObject data = new DataObject(typeof(ListBoxItem), i);
                DragDropEffects dde1 = DragDrop.DoDragDrop(_dragged, data, DragDropEffects.Move);
            }
        }
        private void faite_MouseDown(object sender, MouseButtonEventArgs e)
        {

            ListBoxItem i = sender as ListBoxItem;
            if (i != null)
            {
                DataObject data = new DataObject(typeof(ListBoxItem), i);
                DragDropEffects dde1 = DragDrop.DoDragDrop(_dragged, data, DragDropEffects.Move);
            }
        }
        private void faire_DragEnter(object sender, DragEventArgs e)
        {
            if (_dragged == null)
                e.Effects = DragDropEffects.None;
            else
                e.Effects = DragDropEffects.All;
        }

        private void cours_DragEnter(object sender, DragEventArgs e)
        {
            if (_dragged == null)
                e.Effects = DragDropEffects.None;
            else
                e.Effects = DragDropEffects.All;
        }
        private void faite_DragEnter(object sender, DragEventArgs e)
        {
            if (_dragged == null)
                e.Effects = DragDropEffects.None;
            else
                e.Effects = DragDropEffects.All;
        }
        private void faire_Drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(Grid));
            dragSource.Items.Remove(data);
            parent.Items.Add(data);
            methodes m = new methodes();
            m.update_etat(list[index].get_id(), user.getid_utilis(), "Non réalisée");
            todo.Add(list[index]);
            list.Remove(list[index]);

        }

        private void cours_Drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(Grid));
            dragSource.Items.Remove(data);
            parent.Items.Add(data);
            methodes m = new methodes();
            m.update_etat(list[index].get_id(), user.getid_utilis(), "En cours");
            doing.Add(list[index]);
            list.Remove(list[index]);
        }
        private void faite_Drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(Grid));
            dragSource.Items.Remove(data);
            parent.Items.Add(data);
            methodes m = new methodes();
            m.update_etat(list[index].get_id(), user.getid_utilis(), "Réalisée");
            did.Add(list[index]);
            list.Remove(list[index]);
        }


        private void faire_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
            index = faire.Items.IndexOf(data);
            list = todo;

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }
        private void cours_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
            index = cours.Items.IndexOf(data);
            list = doing;
            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }
        private void faite_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;

            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
            index = faite.Items.IndexOf(data);
            list = did;
            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);

            }
        }
        #region GetDataFromListBox(ListBox,Point)
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }




        #endregion

    }    
    
}
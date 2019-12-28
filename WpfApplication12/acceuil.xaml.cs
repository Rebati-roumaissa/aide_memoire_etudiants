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
    /// Interaction logic for acceuil.xaml
    /// </summary>
    public partial class acceuil : Window
    {
        utilisateur user;
        List<tache> late;
        public acceuil(utilisateur user)
        {
            this.user = user;
            this.late = new List<tache>();
            InitializeComponent();
            methodes m = new methodes();
            this.late = m.tache_nonrealise(user.getid_utilis(), DateTime.Now);
           
            if(late.Count >0)
            {
                Image i = new Image();
                i.Height = 40;
                i.Width = 60;
                i.Source = new BitmapImage(new Uri("notice_new.png", UriKind.Relative));
                split.Header = i;
                affich_latetache(late);

            }
            else
            {
                
                Image notice = new Image();
                notice.Source = new BitmapImage(new Uri("notice.png", UriKind.Relative));
                split.Header = notice;
                menu.Items.Add("Vous n'avez pas de tâche en retard");
            }
        }

        public void affich_latetache(List<tache> l)
        {
            foreach (tache t in l)
            {
                Grid Item = new Grid();
                //header of expander
                StackPanel big = new StackPanel();
                big.Orientation = Orientation.Horizontal;
                big.HorizontalAlignment = HorizontalAlignment.Left;
                big.Width = 200;
                Image prio = new Image();
                prio.Height = 20;
                prio.Width = 20;
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
                info.Width = 110;
                info.Children.Add(prio);
                Label lbl = new Label();
                lbl.Content = t.get_des();
                info.Children.Add(lbl);


                
                
                SolidColorBrush w = new SolidColorBrush(Colors.White);
                Item.Background = w;
                Item.Width = 200;
                StackPanel header = new StackPanel();
                header.Children.Add(info);


                StackPanel bigstack = new StackPanel();
                bigstack.Width = 200;

                StackPanel stack3 = new StackPanel();
                stack3.Orientation = Orientation.Horizontal;
                Label symb3 = new Label();
                symb3.Content = "Date :"; ;
                symb3.Height = 30;
                symb3.Width = 122;
                Label lbl3 = new Label();
                lbl3.Content = t.get_date().Date;
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
                header.Width = 200;
                info.HorizontalAlignment = HorizontalAlignment.Left;
                Item.Children.Add(header);
                split.Items.Add(Item);
            }
        }
        private void materialButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void materialButton_Click_1(object sender, RoutedEventArgs e)
        {


        }

        private void materialButton_Copy4_Click(object sender, RoutedEventArgs e)
        {
            carnet_adr ca = new carnet_adr(user.getid_utilis());
            frame.Content = ca;
        }
        public void set_frame(list_taches page)
        {
            frame.Content = page;
        }
        public void set_frame(activ page)
        {
            frame.Content = page;
        }
        public void set_frame(evenement page)
        {
            frame.Content = page;
        }
        public void set_frame(docs_tache_events page)
        {
            frame.Content = page;
        }
        private void frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void planning_Click(object sender, RoutedEventArgs e)
        {

            planning page = new planning(user);
            frame.Content = page;
        }

        private void etat_Click(object sender, RoutedEventArgs e)
        {
            Etat_tache page = new Etat_tache(user);
            frame.Content = page;
        }

        private void activ_Click(object sender, RoutedEventArgs e)
        {
            activ win = new activ(user, this);
            frame.Content = win;
        }
        

        private void event_Click(object sender, RoutedEventArgs e)
        {
            evenement page = new evenement(user,this);
            frame.Content = page;
        }

        private void docs_Click(object sender, RoutedEventArgs e)
        {
            document_page page = new document_page(user,this);
            frame.Content = page;
        }

        private void parameter_Click(object sender, RoutedEventArgs e)
        {
            User_Affichage page = new User_Affichage(user);
            frame.Content = page;
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            a_propos win = new a_propos();
            win.Show();
        }

        private void disconnect_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"aide_en_ligne\templates\admin\help.html");
        }
    }
}
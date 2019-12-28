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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfScheduler;

namespace WpfApplication12
{
    /// <summary>
    /// Interaction logic for planning.xaml
    /// </summary>
    public partial class planning : Page
    {
        utilisateur user;

            static Color red = (Color)ColorConverter.ConvertFromString("#FFFFA424");
            SolidColorBrush sol = new SolidColorBrush(red);


            static Color vert = (Color)ColorConverter.ConvertFromString("#FF40A497");
            SolidColorBrush solide = new SolidColorBrush(vert);

        public planning(utilisateur user)
        {
            this.user = user;
            InitializeComponent();

            PlanningSemaine.SelectedDate = DateTime.Now;
            PlanningMonth.SelectedDate = DateTime.Now;
            PlanningJour.SelectedDate = DateTime.Now;


            SqlConnection connexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            connexion.Open();
            SqlCommand cmd = new SqlCommand("Select * from Tâche where id_utilis='"+user.getid_utilis()+"'", connexion);
            SqlDataReader lecteur = cmd.ExecuteReader();

            while (lecteur.Read())
            {
                Event t = new Event() { Subject = lecteur["designation"].ToString(),Priorité=lecteur["priorité"].ToString().ToUpper() ,Description = lecteur["etat"].ToString(), Color = solide, Start = (DateTime)lecteur["date"], End = (DateTime)lecteur["fin"] };
                PlanningSemaine.AddEvent(t);
                PlanningJour.AddEvent(t);
                PlanningMonth.AddEvent(t);

            }
            connexion.Close();





            SqlConnection connex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdd.mdf;Integrated Security=True");
            connex.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from évènement where id_utilis='"+user.getid_utilis()+"'", connex);
            SqlDataReader lecteur1 = cmd1.ExecuteReader();
            while (lecteur1.Read())
            {
                Event t = new Event() { Subject = lecteur1["designation"].ToString(), Description = lecteur1["lieu"].ToString(), Color = sol, Start = (DateTime)lecteur1["date"], End = (DateTime)lecteur1["fin"] };
                // t.setColor();

                //scheduler1.AddEvent(t);
                PlanningSemaine.AddEvent(t);
                PlanningJour.AddEvent(t);
                PlanningMonth.AddEvent(t);


            }

            //s.WeekScheduler*/
        }


        private void scheduler1_Loaded(object sender, RoutedEventArgs e)
        {
        }


        private void scheduler2_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void scheduler3_Loaded(object sender, RoutedEventArgs e)
        {
        }
        void scheduler1_OnScheduleDoubleClick(object sender, DateTime e)
        {
            Console.WriteLine(e.ToShortDateString() + ((FrameworkElement)sender).Name);
        }

        void scheduler1_OnEventDoubleClick(object sender, Event e)
        {
            Console.WriteLine(e.Subject);
        }

        void Planjour_OnEventDoubleClick(object sender, Event e)
        {
            if (e.Color == solide)
            {
                Affi_Tach win = new Affi_Tach();
                win.designationTextBox.Content = e.Subject;
                win.Date.Content = e.Start.ToString(" dddd  dd/MM/yyyy").ToUpper();
                win.Priorité.Content = e.Priorité;
                win.Etat.Content = e.Description;
                win.Hdebut.Content = e.Start.ToString("hh:mm ");
                win.Hfin.Content = e.End.ToString("hh:mm ");
                win.Show();
            }
            else
            {
                if (e.Color == sol)
                {
                    Affi_Event win1 = new Affi_Event();
                    win1.designationTextBox.Content = e.Subject;
                    win1.Date.Content = e.Start.ToString(" dddd  dd/MM/yyyy").ToUpper();
                    win1.Lieu.Content = e.Description;
                    win1.Hdebut.Content = e.Start.ToString("hh:mm ");
                    win1.Hfin.Content = e.End.ToString("hh:mm "); ;
                    win1.Show();
                }
            }
        }

        void PlanSemaine_OnEventDoubleClick(object sender, Event e)
        {
            if (e.Color == solide)
            {
                Affi_Tach win = new Affi_Tach();
                win.designationTextBox.Content = e.Subject;
                win.Date.Content = e.Start.ToString(" dddd  dd/MM/yyyy").ToUpper();
                win.Priorité.Content = e.Priorité;
                win.Etat.Content = e.Description;
                win.Hdebut.Content = e.Start.ToString("hh:mm ");
                win.Hfin.Content = e.End.ToString("hh:mm ");
                win.Show();
            }
            else
            {
                if (e.Color == sol)
                {
                    Affi_Event win1 = new Affi_Event();
                    win1.designationTextBox.Content = e.Subject;
                    win1.Date.Content = e.Start.ToString(" dddd  dd/MM/yyyy").ToUpper();
                    win1.Lieu.Content = e.Description;
                    win1.Hdebut.Content = e.Start.ToString("hh:mm ");
                    win1.Hfin.Content = e.End.ToString("hh:mm "); ;
                    win1.Show();
                }
            }
        }

        void PlanMois_OnEventDoubleClick(object sender, Event e)
        {
            if (e.Color == solide)
            {
                Affi_Tach win = new Affi_Tach();
                win.designationTextBox.Content = e.Subject;
                win.Date.Content = e.Start.ToString(" dddd  dd/MM/yyyy").ToUpper();
                win.Priorité.Content = e.Priorité;
                win.Etat.Content = e.Description;
                win.Hdebut.Content = e.Start.ToString("hh:mm ");
                win.Hfin.Content = e.End.ToString("hh:mm ");
                win.Show();
            }
            else
            {
                if (e.Color == sol)
                {
                    Affi_Event win1 = new Affi_Event();
                    win1.designationTextBox.Content = e.Subject;
                    win1.Date.Content = e.Start.ToString(" dddd  dd/MM/yyyy").ToUpper();
                    win1.Lieu.Content = e.Description;
                    win1.Hdebut.Content = e.Start.ToString("hh:mm ");
                    win1.Hfin.Content = e.End.ToString("hh:mm "); ;
                    win1.Show();
                }
            }
        }

        private void PrevWeek(object sender, RoutedEventArgs e)
        {
            PlanningSemaine.PrevPage();
        }

        private void NextWeek(object sender, RoutedEventArgs e)
        {
            PlanningSemaine.NextPage();
        }

        private void PrevDay(object sender, RoutedEventArgs e)
        {
            PlanningJour.PrevPage();
        }

        private void NextDay(object sender, RoutedEventArgs e)
        {
            PlanningJour.NextPage();
        }




        private void PrevMonth(object sender, RoutedEventArgs e)
        {
            PlanningMonth.PrevPage();
        }

        private void NextMonth(object sender, RoutedEventArgs e)
        {
            PlanningMonth.NextPage();
        }
    }
}

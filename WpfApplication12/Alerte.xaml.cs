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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Data.SqlClient;
using System.Media;
using System.Globalization;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;
using WpfApplication12;
namespace WpfApplication12
{
   
    /// <summary>
    /// Logique d'interaction pour Alerte.xaml
    /// </summary>
    public partial class Alerte : Window
    {
        private add_tache page;
        private modif_tache m;
        private tache t;
        private AddEvent eve;
        private int id_user;
        private Boolean new_event;
        public Alerte(tache t, add_tache page, int id_user)
        {

            this.t = new tache();
            this.t = t;
            this.page = page;

            this.id_user = id_user;
            InitializeComponent();

        }
        public Alerte(AddEvent eve, int id_user,Boolean new_event)
        {

            this.id_user = id_user;
            this.eve = eve;
            this.t = null;
            this.new_event = new_event;
            InitializeComponent();

        }
        public Alerte(tache t, modif_tache page, int id_user)
        {

            this.t = new tache();
            this.t = t;
            this.m = page;
            this.id_user = id_user;
            InitializeComponent();

        }

        private void parcourir_Click(object sender, RoutedEventArgs e)
        {
            choisir_son();
        }
        private void choisir_son()
        {
            System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();
            open.Filter = "Documents musicaux(Wave)|*.wav*" + "|Tous les documents|*.*";
            open.RestoreDirectory = true;
            open.Title = " Open ";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String musica = open.FileName;
                music.Text = musica;
            }
        }
        private void Creer_tache_planif(alerte_class a, String Design, DateTime planiftemp)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "schtasks.exe";
            startInfo.UseShellExecute = false;
            String myfile = @"<?xml version=""1.0"" encoding=""UTF-16""?>
              <Task version = ""1.2"" xmlns = ""http://schemas.microsoft.com/windows/2004/02/mit/task""  >
                         <RegistrationInfo >
                           <Date >" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + @"</Date >     
                           <Author > MAISONXP - PC\MAISON XP</Author >
                           <Description >Il faut réussir</Description >              
                                   </RegistrationInfo >
                                    <Triggers >                     
                                     <TimeTrigger >
                                       <StartBoundary > " + a.gettemps().ToString("yyyy-MM-ddTHH:mm:ss") + @" </StartBoundary >
                                               <Enabled > true </Enabled >
                                             </TimeTrigger >
                                           </Triggers >                              
                                           <Principals >
                                             <Principal>
                                                     <LogonType > InteractiveToken </LogonType >
                                                     <RunLevel > LeastPrivilege </RunLevel >
                                                   </Principal >
                                                 </Principals >
                                                 <Settings >
                                                   <MultipleInstancesPolicy > IgnoreNew </MultipleInstancesPolicy >
                                                   <DisallowStartIfOnBatteries > false </DisallowStartIfOnBatteries >
                                                   <StopIfGoingOnBatteries > false </StopIfGoingOnBatteries >
                                                   <AllowHardTerminate > true </AllowHardTerminate >                                    
                                                   <StartWhenAvailable > true </StartWhenAvailable >
                                                   <RunOnlyIfNetworkAvailable > false </RunOnlyIfNetworkAvailable >
                                                    <IdleSettings >                                  
                                                     <StopOnIdleEnd > true </StopOnIdleEnd >                                    
                                                     <RestartOnIdle > false </RestartOnIdle >                                    
                                                   </IdleSettings >                                    
                                                   <AllowStartOnDemand > true </AllowStartOnDemand >                                    
                                                   <Enabled > true </Enabled >                                    
                                                   <Hidden > false </Hidden >                                    
                                                   <RunOnlyIfIdle > false </RunOnlyIfIdle >                                    
                                                   <WakeToRun > true </WakeToRun >                                    
                                                   <ExecutionTimeLimit > P1D </ExecutionTimeLimit >                                    
                                                   <Priority > 7 </Priority >                                    
                                                 </Settings >                                    
                                                 <Actions Context = ""Author"" >                                     
                                                    <Exec >                                     
                                                      <Command > " + System.IO.Directory.GetCurrentDirectory() + @"\Affichage_alerte.exe" + @"</Command>                                        
                                                         <Arguments >" + @"""" + Design + @"""" + " " + @"""" + a.getson() + @"""" + " " + @"""" + planiftemp.ToString() + @"""" + @"</Arguments>                                           
                                                          </Exec >          
                                                     </Actions >
                                                      </Task > ";
            String pathString = System.IO.Directory.GetCurrentDirectory() + @"tachplanif.xml";
            System.IO.File.WriteAllText(pathString, myfile);
            startInfo.Arguments = @"/Create /XML " + @"""" + pathString + @"""" + " /TN " + @"""" + Design + @"""";
            startInfo.CreateNoWindow = true;
            var p1 = Process.Start(startInfo);
            p1.WaitForExit();
        }
        private void valider_Click(object sender, RoutedEventArgs e)
        {
            if (Date.Text != "" && music.Text != "")
            {
                if (Date.Value <= DateTime.Now)
                    System.Windows.Forms.MessageBox.Show("Vous ne pouvez pas insérer une alerte avec une date antérieure");
                else
                {
                    methodes m = new methodes();
                    alerte_class alerte = new alerte_class(music.Text, id_user, 0, Convert.ToDateTime(Date.Text), true);
                    if (t == null)
                    {
                        if (new_event)
                        {
                            eve.set_alarm_tonew_event(alerte);
                           
                        }
                        else
                        {
                            eve.set_alarm_event(alerte);
                        }
                        eve.Show();
                        this.Close();
                    }
                    else
                    {
                        
                        if (this.m == null)
                        { page.set_alarm(alerte);page.Show(); this.Close();/*ajouter une tacha*/ }
                        else
                        {
                            alerte.setidtach(this.t.get_id());
                            this.m.set_alarm(alerte);
                            this.m.Show();
                            this.Close();
                            /*modifier une tache*/
                        }
                    }

                    //   System.Windows.Forms.MessageBox.Show(alerte.gettemps().ToString("yyyy-MM-ddTHH:mm:ss")+" " + ta.textBox.Text+" "+ Convert.ToDateTime(ta.temps_tache.Text).ToString("yyyy-MM-ddTHH:mm:ss"));
                }
            }
            else System.Windows.Forms.MessageBox.Show("Veuillez donner des informations");


        }

        private void activer_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            if (page == null)
            {
                if(m==null)
                {
                    eve.Show();
                }
                else
                {
                    m.Show();
                }
            }
            else
            {
                page.Show();
            }
            
            this.Close();
        }

        private void music_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
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
    /// Logique d'interaction pour modif_tache.xaml
    /// </summary>
    public partial class Affi_Tach : Window
    {
        public Affi_Tach()
        {
            InitializeComponent();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}

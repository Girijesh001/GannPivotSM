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

namespace PivotApplicationCom
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void btnEquity_Click(object sender, RoutedEventArgs e)
        {
            PivotApplication.MainWindow gann = new PivotApplication.MainWindow();
            gann.ShowDialog();
        }

        private void btnPivot_Click(object sender, RoutedEventArgs e)
        {
            PivotApplication.Window1 gann = new PivotApplication.Window1();
            gann.ShowDialog();
        }

        private void btnGann_Click(object sender, RoutedEventArgs e)
        {
            Gann gann = new PivotApplicationCom.Gann();
            gann.ShowDialog();
        }
    }
}

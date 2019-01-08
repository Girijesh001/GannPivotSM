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
    /// Interaction logic for Gann.xaml
    /// </summary>
    public partial class Gann : Window
    {
        public Gann()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           string gannValue = "At 90 degree:"+Math.Round(Math.Pow(Math.Sqrt(Convert.ToDouble(textBox.Text))-0.5,2))
                + "\n At 120 degree:" + Math.Round(Math.Pow(Math.Sqrt(Convert.ToDouble(textBox.Text)) - 0.66, 2))
                + "\n At 180 degree:" + Math.Round(Math.Pow(Math.Sqrt(Convert.ToDouble(textBox.Text)) - 1, 2))
                + "\n At 240 degree:" + Math.Round(Math.Pow(Math.Sqrt(Convert.ToDouble(textBox.Text)) - 1.32, 2))
                + "\n At 270 degree:" + Math.Round(Math.Pow(Math.Sqrt(Convert.ToDouble(textBox.Text)) - 1.5, 2))
                + "\n At 360 degree:" + Math.Round(Math.Pow(Math.Sqrt(Convert.ToDouble(textBox.Text)) - 2, 2))
                ;

            
            MessageBox.Show(""+gannValue);
            MessageBox.Show("" + ((Math.Sqrt(Convert.ToDouble(textBox.Text)) * 180 - 225) % 360)/ 60);
            double temp = 9 + ((Math.Sqrt(Convert.ToDouble(textBox.Text)) * 180 - 225) % 360) / 60;

           // TimeSpan time;
            //TimeSpan.TryParse(temp.ToString().Replace('.',':'), out time);
            DateTime dt;
            DateTime.TryParseExact(temp.ToString().Replace('.', ':'), "HH:mm", System.Globalization.CultureInfo.InvariantCulture,
                                              System.Globalization.DateTimeStyles.None, out dt);
            MessageBox.Show("Revarshal will happen at " + dt);
            MessageBox.Show("Stop loss must be 15 to 20 points below in nifty");
        }
    }
}

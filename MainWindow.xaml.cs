using Microsoft.VisualBasic.FileIO;
using System;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace PivotApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    if (!fields[0].Contains("SYMBOL"))
                    {
                        txtHigh.Text = fields[3];
                        txtLow.Text = fields[4];
                        txtClose.Text = fields[5];

                        // double pivotPoint = (Convert.ToDouble(txtHigh.Text) + Convert.ToDouble(txtClose.Text) + Convert.ToDouble(txtLow.Text)) / 3;
                        double pivotPoint = (Convert.ToDouble(txtHigh.Text) + Convert.ToDouble(txtClose.Text) + Convert.ToDouble(txtLow.Text)) / 3;
                        lblResultPivot.Content = "Pivot Point is: " + pivotPoint.ToString();
                        //TODO:check for case 1:
                        double diffPivot = Math.Abs(Convert.ToDouble(txtClose.Text) - pivotPoint);
                        if (diffPivot > Convert.ToDouble(txtClose.Text) * .5 / 100 && diffPivot - Convert.ToDouble(txtClose.Text) * 1 / 100 < 0.09)
                        {
                            //It's valid pivot
                            //now we have 2 condition 

                            //TODO:check for case 2:
                            if (pivotPoint < Convert.ToDouble(txtClose.Text))
                            {
                                NewMethod(pivotPoint, Convert.ToDouble(txtHigh.Text), "BUY", "SELL",fields[0]);
                            }
                            else
                            {

                                NewMethod(pivotPoint, Convert.ToDouble(txtLow.Text), "SELL", "BUY",fields[0]);
                            }
                        }
                        else
                        {
                           // MessageBox.Show("Pivot point is not valid for today");
                        }
                        //foreach (string field in fields)
                        //{
                        //    MessageBox.Show(field);
                        //}
                    }
                }
            }

            

        }

        public static void SetGridData(object v1, object v2, object v3, object v4)
        {
           
        }

        public void NewMethod(double sellValue,double buyVlaue,string temp1,string temp2,string scriptName)
        {
            //then high will become buy and pivot point will become sell 
            //for BUY
            string strMessage = "-----"+ scriptName+"-----\n";
            strMessage += temp1 + "\n"; ;
            strMessage += "STOP LOSS = " + Convert.ToDouble(txtClose.Text) + "\n";
            double pointValue = buyVlaue - Convert.ToDouble(txtClose.Text);
            strMessage += "Point Value = "+ pointValue + "\n"; ;
            strMessage += "Target1 = " + (buyVlaue + pointValue) + "\n";
            strMessage += "Target2 = " + (buyVlaue + 2 * pointValue) + "\n";
            strMessage += "Target3 = " + (buyVlaue + 3 * pointValue) + "\n";

            strMessage += temp2 + "\n";
            strMessage += "STOP LOSS = " + Convert.ToDouble(txtClose.Text) + "\n";
            pointValue = sellValue - Convert.ToDouble(txtClose.Text);
            strMessage += "Point Value = " + pointValue + "\n"; ;
            strMessage += "Target1 = " + (sellValue + pointValue) + "\n";
            strMessage += "Target2 = " + (sellValue + (2 * pointValue)) + "\n";
            strMessage += "Target3 = " + (sellValue + (3 * pointValue)) + "\n";
            MessageBox.Show("" + strMessage);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Calendar_SelectedDatesChanged(object sender,
             SelectionChangedEventArgs e)
        {
            #region This code is downloading equity excel from test.
            try
            {
                // ... Get reference.
                var calendar = sender as Calendar;

                // ... See if a date is selected.
                if (calendar.SelectedDate.HasValue)
                {
                    // ... Display SelectedDate in Title.
                    DateTime date = calendar.SelectedDate.Value;
                    this.Title = date.ToShortDateString();
                    string date12 = string.Format("{0:00}", date.Date.Day);
                    string year = string.Format("{0:00}", date.Date.Year);
                    string month = string.Format("{0:00}", date.ToString("MMM", System.Globalization.CultureInfo.InvariantCulture).ToUpper());

                    //cm07SEP2017bhav.csv.zip
                    //https://www.nseindia.com/content/historical/EQUITIES/2017/SEP/cm07SEP2017bhav.csv.zip
                    string url = "https://www.nseindia.com/content/historical/EQUITIES/" + year
                        + "/" + month + "/cm" + date12 + month + year + "bhav.csv.zip";
                    WebClient wb = new WebClient();
                    wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
                   // wb.DownloadFile(url, "c:\\temp\\" + date12 + month + year + "csv.zip");
                    wb.DownloadFile(url, AppDomain.CurrentDomain.BaseDirectory + date12 + month + year + "csv.zip");
                    MessageBox.Show("File exported successfully. Path is :" + AppDomain.CurrentDomain.BaseDirectory + date12 + month + year + "csv.zip");
                    
                    //Window1 obj = new PivotApplication.Window1();
                    //obj.ShowDialog();
                }
            }
            catch (Exception exception)
            {

                throw exception;
            }
            #endregion
        }
    }
}

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

namespace WpfApp2
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
        private void NightModeButtons(bool colorDay)
        { 
            Panel mainContainer = (Panel)this.Content;
            UIElementCollection element = mainContainer.Children;
            List<FrameworkElement> lstElement = element.Cast<FrameworkElement>().ToList();
            var lstControl = lstElement.OfType<Control>();
            foreach (Control contol in lstControl)
            {
                if(contol is Button && colorDay==true)
                {
                    (contol as Button).Background = new SolidColorBrush(Colors.LightSlateGray);
                    
                }
                else if(contol is Button && colorDay == false)
                {
                    (contol as Button).Background = new SolidColorBrush(Colors.White);
                }
            }
        }
        private void ButtonEqual_Click(object sender, RoutedEventArgs e) {
            string str = TextBoxMain.Text;
            try {

                if (str.Contains('+')) {
                    int position = str.IndexOf('+');
                    float firstpart = float.Parse(str.Substring(0, position));
                    float secondpart = float.Parse(str.Substring(position + 1, str.Length - position - 1));
                    TextBoxMain.Clear();
                    TextBoxMain.Text = (firstpart + secondpart).ToString();
                }
                if (str.Contains('-')) {
                    int position = str.IndexOf('-');
                    float firstpart = float.Parse(str.Substring(0, position));
                    float secondpart = float.Parse(str.Substring(position + 1, str.Length - position - 1));
                    TextBoxMain.Clear();
                    TextBoxMain.Text = (firstpart - secondpart).ToString();
                }
                if (str.Contains('*')) {
                    int position = str.IndexOf('*');
                    float firstpart = float.Parse(str.Substring(0, position));
                    float secondpart = float.Parse(str.Substring(position + 1, str.Length - position - 1));
                    TextBoxMain.Clear();
                    TextBoxMain.Text = (firstpart * secondpart).ToString();
                }
                if (str.Contains('/')) {
                    int position = str.IndexOf('/');
                    float firstpart = float.Parse(str.Substring(0, position));
                    float secondpart = float.Parse(str.Substring(position + 1, str.Length - position - 1));
                    TextBoxMain.Clear();

                    if (secondpart == 0 || firstpart == 0)
                        throw new Exception("Dividing by zero");
                    
                    TextBoxMain.Text = (firstpart / secondpart).ToString();
                }


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            TextBoxMain.Text += (sender as Button).Content;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e) {
            TextBoxMain.Clear();
        }

        private void ButtonNightMode_Click(object sender, RoutedEventArgs e) {
            if ((sender as CheckBox).IsChecked == true) {
                // це пізда це реально пізда
                this.Background = new SolidColorBrush(Colors.DarkSlateGray);
                NightModeButtons(true);
                (sender as CheckBox).Foreground = new SolidColorBrush(Colors.LightSlateGray);
                TextBoxMain.Background = new SolidColorBrush(Colors.LightSlateGray);
            }
            else
            {
                TextBoxMain.Background = new SolidColorBrush(Colors.White);
                this.Background = new SolidColorBrush(Colors.LightGray);
                NightModeButtons(false);
                (sender as CheckBox).Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void ButtonAbs_Click(object sender, RoutedEventArgs e) {
            
            try {

                if (TextBoxMain.Text.Length > 0) {
                    TextBoxMain.Text = Math.Sqrt(double.Parse(TextBoxMain.Text)).ToString();
                }
                else {
                    throw new Exception("Empty field");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ButtonPow_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (TextBoxMain.Text.Length > 0) {
                    TextBoxMain.Text = Math.Pow(double.Parse(TextBoxMain.Text), (double)2).ToString();
                }
                else {
                    throw new Exception("Empty field");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

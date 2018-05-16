﻿using System;
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
                    
                    TextBoxMain.Text = (firstpart + secondpart).ToString();
                }


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

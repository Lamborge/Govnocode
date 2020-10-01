using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Diagnostics;

namespace Govnocode
{
    /// <summary>
    /// Логика взаимодействия для LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public LogWindow()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\log";

            using (FileStream fstream = new FileStream(@$"{path}\log.txt", FileMode.Create))
            {

            }

            TextLogBox.Text = "";
        }
    }
}
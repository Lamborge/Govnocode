using Govnocode;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TextBox
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Title_MouseEnter(object sender, MouseEventArgs e)
        {
            /*int test_hash = InputName.Text.GetHashCode();
            MessageBox.Show(Convert.ToString(test_hash));*/
        }

        public void MessageReturn(int result)
        {
            if (result > 100) { MessageBox.Show("Твой процент говнокодинга зашкаливает"); }
            else if (result <= 0) { result = 0; MessageBox.Show("Твой процент говнокодерства меньше нуля, таких проегров не бывает"); }
            else { MessageBox.Show("Ты говнокодер на " + Convert.ToString(result) + "%"); }
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            string res_string = InputName.Text.Trim();

            if (res_string.Length > 10 || res_string.Length < 2)
            {
                MessageBox.Show("Невалидное имя");
            }
            else
            {

                string Language = null;
                string Opit = null;
                //обрабатывает какой яп выбран
                if (CSharp_Radio.IsChecked == true) { Language = "Sharp"; }
                if (CPP_Radio.IsChecked == true) { Language = "CPP"; }
                if (Kotlin_Radio.IsChecked == true) { Language = "Kotlin"; }
                if (Java_Radio.IsChecked == true) { Language = "Java"; }
                if (JavaScript_Radio.IsChecked == true) { Language = "JS"; }
                if (PHP_Radio.IsChecked == true) { Language = "PHP"; }
                if (Ruby_Radio.IsChecked == true) { Language = "Ruby"; }
                if (Swift_Radio.IsChecked == true) { Language = "Swift"; }
                if (Python_Radio.IsChecked == true) { Language = "Python"; }

                if (OneM.IsChecked == true) { Opit = "1Mounth"; }
                if (ThreeM.IsChecked == true) { Opit = "3Mounth"; }
                if (SixM.IsChecked == true) { Opit = "6Mounth"; }
                if (OneY.IsChecked == true) { Opit = "1Years"; }
                if (ThreeY.IsChecked == true) { Opit = "3Years"; }
                if (FiveY.IsChecked == true) { Opit = "5Years"; }
                if (OneW.IsChecked == true) { Opit = "OneW"; }
                if (TwoW.IsChecked == true) { Opit = "TwoW"; }


                string result_path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\res";

                DirectoryInfo path_info = new DirectoryInfo(result_path);
                if (!path_info.Exists)
                {
                    path_info.Create();
                }

                string file_name = $"{res_string}{Language}{Opit}";
                string base64_path = Convert.ToBase64String(Encoding.Default.GetBytes(file_name));
                string main_path = $@"{result_path}\{base64_path}.txt";

                if (File.Exists(main_path))
                {
                    string procent = "";

                    using (FileStream fstream = File.OpenRead(main_path))
                    {
                        byte[] array = new byte[fstream.Length];

                        fstream.Read(array, 0, array.Length);
                        fstream.Close();

                        string base64_str = Encoding.Default.GetString(array);

                        try
                        {
                            byte[] base64_byte = Convert.FromBase64String(base64_str);

                            procent = Encoding.Default.GetString(base64_byte);
                        }
                        catch
                        {
                            File.Delete(main_path);
                            MessageBox.Show("Файл с данным результатом повреждён");
                        }

                    }
                    if (procent == null) { }
                    else
                    {
                        MessageReturn(Convert.ToInt32(procent));
                    }
                }
                else
                {

                    //алгоритм высчитывания процента
                    Random rnd = new Random();
                    int sum = 0;
                    int text_hash = res_string.GetHashCode();
                    string hash_str = Convert.ToString(text_hash);
                    char[] hash_array = hash_str.ToCharArray();
                    foreach (char item in hash_array)
                    {
                        sum += Convert.ToInt32(item);
                    }

                    sum = sum / Convert.ToInt32(res_string.ToCharArray().Length * 4.5f);

                    //обрабатывает какой яп выбран
                    if (CSharp_Radio.IsChecked == true) { sum -= 7; Language = "Sharp"; }
                    if (CPP_Radio.IsChecked == true) { sum -= 12; Language = "CPP"; }
                    if (Kotlin_Radio.IsChecked == true) { sum -= 2; Language = "Kotlin"; }
                    if (Java_Radio.IsChecked == true) { sum -= 2; Language = "Java"; }
                    if (JavaScript_Radio.IsChecked == true) { sum += 5; Language = "JS"; }
                    if (PHP_Radio.IsChecked == true) { sum += 13; Language = "PHP"; }
                    if (Ruby_Radio.IsChecked == true) { sum -= 10; Language = "Ruby"; }
                    if (Swift_Radio.IsChecked == true) { sum += 5; Language = "Swift"; }
                    if (Python_Radio.IsChecked == true) { sum += 100; Language = "Python"; }

                    if (OneM.IsChecked == true) { sum += 12; Opit = "1Mounth"; }
                    if (ThreeM.IsChecked == true) { sum += 7; Opit = "3Mounth"; }
                    if (SixM.IsChecked == true) { sum += 4; Opit = "6Mounth"; }
                    if (OneY.IsChecked == true) { sum -= 4; Opit = "1Years"; }
                    if (ThreeY.IsChecked == true) { sum -= 7; Opit = "3Years"; }
                    if (OneW.IsChecked == true) { sum += 9; Opit = "OneW"; }
                    if (TwoW.IsChecked == true) { sum += 12; Opit = "TwoW"; }

                    if (rnd.Next(0, 2) == 1) { sum = sum * 2; }

                    if (Dark_Theme.IsChecked == true) { sum -= 2; }

                    if (sum < 0) { sum = 0; sum += 2; }

                    MessageReturn(sum);


                    file_name = $"{res_string}{Language}{Opit}";
                    base64_path = Convert.ToBase64String(Encoding.Default.GetBytes(file_name));

                    using (FileStream fstream = new FileStream($@"{result_path}\{base64_path}.txt", FileMode.Append))
                    {
                        byte[] array = Encoding.Default.GetBytes(Convert.ToString(sum));

                        string array_string = Convert.ToBase64String(array);

                        byte[] array_convert = Encoding.Default.GetBytes(array_string);

                        fstream.Write(array_convert, 0, array_convert.Length);
                    }

                    //запись лога
                    string log_path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\log";
                    DirectoryInfo dirInfo = new DirectoryInfo(log_path);
                    if (!dirInfo.Exists)
                    {
                        dirInfo.Create();
                    }


                    string text = $"Имя: {res_string}; Процент: " + Convert.ToString(sum) + $"%; Язык: {Language}; Опыт: {Opit}" + Environment.NewLine;
                    using (FileStream fstream = new FileStream($@"{log_path}\log.txt", FileMode.Append))
                    {

                        // преобразуем строку в байты
                        byte[] array = Encoding.Default.GetBytes(text);

                        // запись массива байтов в файл
                        fstream.Write(array, 0, array.Length);
                    }
                }
            }
        }

        private void Dark_Theme_Checked(object sender, RoutedEventArgs e)
        {
            Main_Grid.Background = Brushes.Black;
            Input_name_text.Foreground = Brushes.White;
            Dark_Theme.Foreground = Brushes.White;
            CSharp_Radio.Foreground = Brushes.White;
            CPP_Radio.Foreground = Brushes.White;
            Kotlin_Radio.Foreground = Brushes.White;
            Java_Radio.Foreground = Brushes.White;
            JavaScript_Radio.Foreground = Brushes.White;
            PHP_Radio.Foreground = Brushes.White;
            Ruby_Radio.Foreground = Brushes.White;
            Swift_Radio.Foreground = Brushes.White;
            Python_Radio.Foreground = Brushes.White;
            Versinon.Foreground = Brushes.White;
            OneM.Foreground = Brushes.White;
            ThreeM.Foreground = Brushes.White;
            SixM.Foreground = Brushes.White;
            OneY.Foreground = Brushes.White;
            ThreeY.Foreground = Brushes.White;
            FiveY.Foreground = Brushes.White;
            ChangeLangText.Foreground = Brushes.White;
            ChangeOpitText.Foreground = Brushes.White;
            OneW.Foreground = Brushes.White;
            TwoW.Foreground = Brushes.White;
        }

        private void Dark_Theme_Unchecked(object sender, RoutedEventArgs e)
        {
            Main_Grid.Background = Brushes.White;
            Input_name_text.Foreground = Brushes.Black;
            Dark_Theme.Foreground = Brushes.Black;
            CSharp_Radio.Foreground = Brushes.Black;
            CPP_Radio.Foreground = Brushes.Black;
            Kotlin_Radio.Foreground = Brushes.Black;
            Java_Radio.Foreground = Brushes.Black;
            JavaScript_Radio.Foreground = Brushes.Black;
            PHP_Radio.Foreground = Brushes.Black;
            Ruby_Radio.Foreground = Brushes.Black;
            Swift_Radio.Foreground = Brushes.Black;
            Python_Radio.Foreground = Brushes.Black;
            Versinon.Foreground = Brushes.Black;
            OneM.Foreground = Brushes.Black;
            ThreeM.Foreground = Brushes.Black;
            SixM.Foreground = Brushes.Black;
            OneY.Foreground = Brushes.Black;
            ThreeY.Foreground = Brushes.Black;
            FiveY.Foreground = Brushes.Black;
            ChangeLangText.Foreground = Brushes.Black;
            ChangeOpitText.Foreground = Brushes.Black;
            OneW.Foreground = Brushes.Black;
            TwoW.Foreground = Brushes.Black;
            //хуй залупа
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow logWindow = new LogWindow();

            logWindow.Show();

            string path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\log";

            using (FileStream fstream = File.OpenRead($@"{path}\log.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);

                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(array);

                logWindow.TextLogBox.Text = textFromFile;
            }
        }
    }
}
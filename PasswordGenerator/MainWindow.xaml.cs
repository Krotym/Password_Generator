using Microsoft.Win32;
using PasswordGenerator.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PasswordGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int prompt = 0;
        public int size=4;
        public string str = "", StrPrompt = "",StrInfo="";
        string[] ch ={"","","","","",
                      "","","","",};
        bool check = false;
        /// <summary>
        /// Выбор типа данных для ввода подсказки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Text_string(object sender, RoutedEventArgs e)
        {
            StrPrompt = "Name";
              prompt = 0;
        }
        public void Text_string1(object sender, RoutedEventArgs e)
        {
            StrPrompt = "Surname";
            prompt = 0;
        }
        public void Text_integer(object sender, RoutedEventArgs e)
        {
            StrPrompt = "Date";
           prompt = 1;
        }
        private void Text_input(object sender, RoutedEventArgs e)
        {
            
            Other_Prompt Oth = new Other_Prompt();
            Oth.Owner = this;
            Oth.ShowDialog();
            prompt = 2;

        } 
        public void Text_prompt(object sender, TextCompositionEventArgs e)
        {
            if(prompt==0)
            {
                e.Handled = !(Char.IsLetter(e.Text, 0));
            }
            else if (prompt == 1)
            {
                e.Handled = !(Char.IsDigit(e.Text, 0));
            }
            else 
            {
                e.Handled = !(Char.IsLetterOrDigit(e.Text, 0));
            }
        }   
        /// <summary>
        /// Выбор размера пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Size_4(object sender, RoutedEventArgs e)
        {
            size = 4;
            slValue.Maximum = size;
        }
        public void Size_8(object sender, RoutedEventArgs e)
        {
            size = 8;
            slValue.Maximum = size;
        }
        public void Size_16(object sender, RoutedEventArgs e)
        {
            size = 16;
            slValue.Maximum = size;
        }
        private void Size_input(object sender, RoutedEventArgs e)
        {
            Other_Size Oth = new Other_Size();
            Oth.Owner = this;
            Oth.ShowDialog();
            
        }


        public void Vistex_slider(object sender, RoutedEventArgs e)
        {
            slValue.Maximum = size;
        }

            /// <summary>
            /// клавиша генерации
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void Generate(object sender, RoutedEventArgs e)
        {
            
            Cipher ci = new Cipher();
            str = textBox.Text;
            int change = Convert.ToInt32(slider.Content); 
            ci.cryptic(str, change,size,check,ch);
            textBlock.Text = ci.cryp();
        }
        /// <summary>
        /// перемешать символы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            check = true;
        }
        private void checkBox_UNChecked(object sender, RoutedEventArgs e)
        {
            check =false;
        }

        /// <summary>
        /// спец символы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chaptter1(object sender, RoutedEventArgs e)
        {
            ch[0] = "#";
        }
        private void UnChaptter1(object sender, RoutedEventArgs e)
        {
            ch[0] = "";
        }
        private void Chaptter2(object sender, RoutedEventArgs e)
        {
            ch[1] = "?";
        }
        private void UnChaptter2(object sender, RoutedEventArgs e)
        {
            ch[1] = "";
        }
        private void Chaptter3(object sender, RoutedEventArgs e)
        {
            ch[2] = "+";
        }
        private void UnChaptter3(object sender, RoutedEventArgs e)
        {
            ch[2] = "";
        }
        private void Chaptter4(object sender, RoutedEventArgs e)
        {
            ch[3] = "*";
        }
        private void UnChaptter4(object sender, RoutedEventArgs e)
        {
            ch[3] = "";
        }
        private void Chaptter5(object sender, RoutedEventArgs e)
        {
            ch[4] = "-";
        }
        private void UnChaptter5(object sender, RoutedEventArgs e)
        {
            ch[4] = "";
        }
        private void Chaptter6(object sender, RoutedEventArgs e)
        {
            ch[5] = "$";
        }
        private void UnChaptter6(object sender, RoutedEventArgs e)
        {
            ch[5] = "";
        }
        private void Chaptter7(object sender, RoutedEventArgs e)
        {
            ch[6] = "@";
        }
        private void UnChaptter7(object sender, RoutedEventArgs e)
        {
            ch[6] = "";
        }
        private void Chaptter8(object sender, RoutedEventArgs e)
        {
            ch[7] = "=";
        }
        private void UnChaptter8(object sender, RoutedEventArgs e)
        {
            ch[7] = "";
        }
        private void Chaptter9(object sender, RoutedEventArgs e)
        {
            ch[8] = "!";
        }
        private void UnChaptter9(object sender, RoutedEventArgs e)
        {
            ch[8] = "";
        }

        /// <summary>
        /// сохранение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save(object sender, RoutedEventArgs e)
        {
            Info Oth = new Info();
            Oth.Owner = this;
            Oth.ShowDialog();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string info = "Prompt: " + StrPrompt + "\nPassword from: "+ StrInfo + "\nPassword: " + textBlock.Text;
            saveFileDialog1.Filter = "(*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(info);
                    sw.Close();
                }
            }
        }

    }
}

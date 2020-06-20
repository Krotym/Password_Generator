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
        bool prompt = false;
        int size=4;
        string str = "";

        /// <summary>
        /// Выбор типа данных для ввода подсказки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Text_string(object sender, RoutedEventArgs e)
        {
            prompt = false;
        }
        public void Text_integer(object sender, RoutedEventArgs e)
        {
            prompt = true;
        }
        public void Text_prompt(object sender, TextCompositionEventArgs e)
        {
            if(prompt==false)
            {
                e.Handled = !(Char.IsLetter(e.Text, 0));
            }
            else 
            {
                e.Handled = !(Char.IsDigit(e.Text, 0));
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
            ci.cryptic(str, change);
            textBlock.Text = ci.cryp();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace PasswordGenerator
{
    /// <summary>
    /// Логика взаимодействия для Other_Prompt.xaml
    /// </summary>
    public partial class Other_Prompt : Window
    {
        public Other_Prompt()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.Text, 0));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = this.Owner as MainWindow;
            if(main != null)
            {
                main.StrPrompt = textBox1.Text;
                Close();
            }
        }
    }
}

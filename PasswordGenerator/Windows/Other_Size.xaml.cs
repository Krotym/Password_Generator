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

namespace PasswordGenerator.Windows
{
    /// <summary>
    /// Логика взаимодействия для Other_Size.xaml
    /// </summary>
    public partial class Other_Size : Window
    {
        public Other_Size()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = this.Owner as MainWindow;
            if (main != null)
            {
                main.size =Int32.Parse( textBox1.Text);
                main.slValue.Maximum = Int32.Parse(textBox1.Text);
                Close();
            }
        }
    }
}

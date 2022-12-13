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

namespace prac10
{
    public partial class MainWindow : Window
    {
        List<int> mas = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32.TryParse(Value.Text, out int value);
                if (value < -100 || value > 100) throw new ArgumentException("Не попадает в интервал");
                foreach (int i in mas) if (value == i)
                    {
                        Value.Text = null;
                        throw new ArgumentException("Повторяющееся число");
                    }
                mas.Add(value);
                listBox.Items.Add(value);
                Value.Text = null;
                Value.Focus();
            }
            catch
            {
                MessageBox.Show("Число не подходит");
            }
        }

        private void Сalculate(object sender, RoutedEventArgs e)
        {
            string final = "";
            int kolPolozhit = 0;
            int kolOtric = 0;
            foreach (int i in mas)
                if (i % 2 == 0) kolPolozhit++;
                else kolOtric++;
            final = $"Четных {kolPolozhit}Нечетных {kolOtric}";
            Itog.Text = final;
        }
        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кузнецов Алексей Алексеевич.Вариант 13. Дан массив в диапазоне [-100;100] найти количество четных и нечетных.");
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            mas.Clear();
            listBox.Items.Clear();
            Itog.Clear();
        }
    }
}

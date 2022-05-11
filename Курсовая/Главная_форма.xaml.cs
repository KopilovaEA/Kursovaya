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

namespace Курсовая
{
    /// <summary>
    /// Логика взаимодействия для Главная_форма.xaml
    /// </summary>
    public partial class Главная_форма : Window
    {
        public Главная_форма()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Состав_кафедры n = new Состав_кафедры();
            n.Show();
            this.Close();
        }

        private void SP(object sender, MouseButtonEventArgs e)
        {
            Авторизация n = new Авторизация();
            n.Show();
            this.Close();
        }
    }
}

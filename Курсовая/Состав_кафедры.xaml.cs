using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Состав_кафедры.xaml
    /// </summary>
    public partial class Состав_кафедры : Window
    {
        kno db = new kno();
        kafedra kafedra = new kafedra();
        int id;
        string ФИО, ЗанимаемаяД;
        public Состав_кафедры()
        {
            InitializeComponent();
            db.CreateStrConnection();
            sostav.ItemsSource = db.Readkafedra();
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kafedra kafedra = new kafedra();
            kafedra = sostav.SelectedItem as kafedra;
            if (kafedra != null)
            {
                id = kafedra.id;
                textbox2.Text = kafedra.ФИО;
                textbox3.Text = kafedra.ЗанимаемаяД;
                textbox4.Text = kafedra.Образование;
                textbox5.Text = kafedra.Специальность;
                textbox6.Text = kafedra.УченоеЗвание;
                textbox7.Text = kafedra.Стаж;
                textbox8.Text = kafedra.Дисциплины;
               


            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Главная_форма newfrm = new Главная_форма();
            newfrm.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
            db.Delkafedra(id);
            sostav.ItemsSource = db.Readkafedra();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            db.Addkafedra(id,textbox2.Text, textbox3.Text, textbox4.Text, textbox5.Text, textbox6.Text, textbox7.Text, textbox8.Text);
            sostav.ItemsSource = db.Readkafedra();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            db.Upkafedra(id,textbox2.Text, textbox3.Text, textbox4.Text, textbox5.Text, textbox6.Text, textbox7.Text, textbox8.Text);
            sostav.ItemsSource = db.Readkafedra();

        }

        /* private void sostav_SelectionChanged(object sender, RoutedEventArgs e)
         {
                 kafedra kafedra = new kafedra();
                 kafedra = sostav.SelectedItem as kafedra;
                 if (kafedra != null)
                 {
                     tbTitle.Text = book.Title;
                     tbAuthor.Text = book.Author;
                     tbGenre.Text = book.Genre;
                     tbDateCreate.Text = book.DateCreate.ToString();
                     idBook = book.idbooks;
                     tbDes.Text = book.Description;

                 }*/
    }
        }
    


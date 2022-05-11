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
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Курсовая
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Window
    {
        connection con = new connection();
        string id, Polzovatel, login, password;
        public Авторизация()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    if (textbox1.Text != "" && textbox2.Text != "")
                    {

                        con.Open();
                        string query = "select id, Polzovatel, login, password from users WHERE login ='" + textbox1.Text + "' AND password ='" + textbox2.Text + "'";
                        MySqlDataReader row;
                        row = con.ExecuteReader(query);
                        if (row.HasRows)
                        {
                            while (row.Read())
                            {
                                id = row["id"].ToString();
                                Polzovatel = row["Polzovatel"].ToString();
                                login = row["login"].ToString();
                                password = row["password"].ToString();

                            }
                            MessageBox.Show("Вы зашли под пользователем " + Polzovatel);
                            string s = "Adp";
                            string a = "Student";
                            if (textbox1.Text != "Student")
                            {
                                Главная_форма newfrm = new Главная_форма();
                                newfrm.Show();
                                this.Close();
                            }
                            else if (textbox1.Text != "Adp")
                            {
                                Главная_форма2 newfrm = new Главная_форма2();
                                newfrm.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Возможно вы ввели неверный логин или пароль, пожалуйста попробуйте снова", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данные не найдены", "Error");
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Error");
                }
            }

        }
    }
}


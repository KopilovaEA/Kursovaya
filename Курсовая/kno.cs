using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Курсовая
{
    class kno
    {
        MySqlConnectionStringBuilder ConnectrionStr;
        MySqlConnection connection;
        public void CreateStrConnection()
        {
            ConnectrionStr = new MySqlConnectionStringBuilder();
            ConnectrionStr.Server = "localhost";
            ConnectrionStr.Port = 3306;
            ConnectrionStr.UserID = "root";
            ConnectrionStr.Password = "root";
            ConnectrionStr.Database = "kno";
            connection = new MySqlConnection(ConnectrionStr.ToString());
        }
        public void Addkafedra(int id, string ФИО, string ЗанимаемаяД, string Образование, string Специальность, string УченоеЗвание, string Стаж, string Дисциплины)
        {
            string CommandText = $"INSERT INTO kafedraa (id,ФИО, ЗанимаемаяД, Образование, Специальность, УченоеЗвание, Стаж, Дисциплины) VALUES ('{id}','{ФИО}', '{ЗанимаемаяД}','{ Образование}', '{Специальность}','{ УченоеЗвание}', '{Стаж}', '{Дисциплины}');";

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(CommandText, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();

        }

        public List<kafedra> Readkafedra()
        {
            List<kafedra> kafedras = new List<kafedra>();
            string cmdtxt = $"SELECT * FROM kafedraa;";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        kafedras.Add(new kafedra()
                        {
                            id = reader.GetInt32(0),
                            ФИО = reader.GetString(1),
                            ЗанимаемаяД = reader.GetString(2),
                            Образование = reader.GetString(3),
                            Специальность = reader.GetString(4),
                            УченоеЗвание = reader.GetString(5),
                            Стаж = reader.GetString(6),
                            Дисциплины = reader.GetString(7)
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return kafedras;

        }
        public void Delkafedra(int id)
        {
            string cmdtxt = $"DELETE FROM kafedraa WHERE id = {id}";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        public void Upkafedra(int Id, string nФИО, string nЗанимаемаяД, string nОбразование, string nСпециальность, string nУченоеЗвание, string nСтаж, string nДисциплины)
        {
            string CommandText = $"UPDATE kafedraa SET ФИО ='{nФИО}', " +
               $"ЗанимаемаяД = '{nЗанимаемаяД}', " +
               $"Образование = '{nОбразование}', " +
                $"Специальность = '{nСпециальность}', " +
               $"УченоеЗвание = '{nУченоеЗвание}', " +
                $"Стаж = '{nСтаж}', " +
               $"Дисциплины = '{nДисциплины}' WHERE id = {Id};";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(CommandText, connection);
                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            connection.Close();
        }
    }
}

/*   public void UpdBook(int Id, string newTitle, string newAuthor, string newGenre, int newDate, string newDescription)
   {
       string CommandText = $"UPDATE books SET Title = '{newTitle}', " +
           $"Genre = '{newGenre}', " +
           $"Author = '{newAuthor}', " +
           $"DateCreate = {newDate}, " +
           $"Description = '{newDescription}' WHERE idbooks = {Id};";

       try
       {
           connection.Open();
           MySqlCommand command = new MySqlCommand(CommandText, connection);
           command.ExecuteNonQuery();

       }
       catch (Exception error)
       {
           MessageBox.Show(error.Message);
       }
       connection.Close();
   }

   public void DeldBook(int id)
   {
       string cmdtxt = $"DELETE FROM books WHERE idbooks = {id}";
       try
       {
           connection.Open();
           MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
           cmd.ExecuteNonQuery();
       }
       catch (Exception ex)
       {

           MessageBox.Show(ex.Message);
       }
       connection.Close();
   }

   public int Authorize(string login, string password)
   {
       string cmdtxt = $"SELECT * FROM user WHERE login='{login}' AND password='{password}'";
       int codeAuth = -1;
       try
       {
           connection.Open();
           MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
           codeAuth = Convert.ToInt32(cmd.ExecuteScalar());
       }
       catch (Exception ex)
       {

           MessageBox.Show(ex.Message);
       }
       connection.Close();
       return codeAuth;
   }

   public List<Us> ReadUser()
   {
       List<Us> user = new List<Us>();
       string cmdtxt = $"SELECT * FROM user;";
       try
       {
           connection.Open();
           MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
           MySqlDataReader reader = cmd.ExecuteReader();
           if (reader.HasRows)
           {
               while (reader.Read())
               {
                   user.Add(new Us()
                   {
                       idUser = reader.GetInt32(0),
                       login = reader.GetString(1),
                       password = reader.GetString(2),
                       FirstName = reader.GetString(3),

                   });
               }
           }
       }
       catch (Exception ex)
       {

           MessageBox.Show(ex.Message);
       }
       connection.Close();
       return user;

   }

   public void AddUser(string UserLogin, string UserPassword, string LastName, string FirstName)
   {
       string CommandText = $"INSERT INTO user (login,password,LastName,FirstName) VALUES ('{UserLogin}','{UserPassword}','{LastName}','{FirstName}');";

       try
       {
           connection.Open();
           MySqlCommand cmd = new MySqlCommand(CommandText, connection);
           cmd.ExecuteNonQuery();

       }
       catch (Exception ex)
       {

           MessageBox.Show(ex.Message);
       }
       connection.Close();

   }

   public void UpdUser(int Id, string newLogin, string newPassword, string newLastName, string newFirstName)
   {
       string CommandText = $"UPDATE user SET login = '{newLogin}', " +
           $"password = '{newPassword}', " +
           $"LastName = '{newLastName}', " +
           $"FirstName = '{newFirstName}'  WHERE idUser = {Id};";

       try
       {
           connection.Open();
           MySqlCommand command = new MySqlCommand(CommandText, connection);
           command.ExecuteNonQuery();

       }
       catch (Exception error)
       {
           MessageBox.Show(error.Message);
       }
       connection.Close();
   }

   public void DelUser(int id)
   {
       string cmdtxt = $"DELETE FROM user WHERE idUser = {id}";
       try
       {
           connection.Open();
           MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
           cmd.ExecuteNonQuery();
       }
       catch (Exception ex)
       {


           MessageBox.Show(ex.Message);
       }
       connection.Close();
   }
}
}


}
}
*/
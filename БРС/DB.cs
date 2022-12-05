using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace БРС
{
    class DB//подключение к базе данных
    {
        MySqlConnection connection= new MySqlConnection("server=localhost;port= 3306;username=root;password=root;database=brs");//вводим значения порта и хоста локальной сети , пароля и названия нашей базы данных 

        public void openConnection()//если мы не подключены к базе данных, то мы подключимся
        {
            if(connection.State== System.Data.ConnectionState.Closed)
                connection.Open();            
        }
        public void closeConnection()// если мы подключены к базе данных, то мы отключимся 
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();            
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestDb
{
    class Program
    {
        private string nameBd = "test.db";
        private string log = "Журнал событий \t\n";
        private SQLiteConnection connection;

        static void Main(string[] args)
        {

        }

        public void connectionDb_1()
        {

           connection = new SQLiteConnection($"Data Sourse={nameBd}; Version=3;"); // создание подключения к самой бд
        }

        public void CreateBDsql()
        {
            if (!File.Exists(nameBd))
            {
                try{
                    SQLiteConnection.CreateFile(nameBd); // созданиие бд
                    string sql = "CREATE TABLE testtable (id integer key,data INT, txt TEXT, vchar varchar(81))"; // Создание конкретной таблице в бд 
                    SQLiteCommand command = new SQLiteCommand(connection); // команды для передачи в бд

                    command.CommandText = sql; // отправка команды в бд
                    command.ExecuteNonQuery(); // команда выполнить.
                    connection.Close(); // отсоединение от базы
                }
                catch(Exception ex)
                {
                    log += $"Ошибка при создании БД \t\n{ex}\t\n";
                }
            } 
        }
        



    }
}

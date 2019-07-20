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
        private static string nameBd = "test.db";
        private static string log = "Журнал событий \t\n";
      //  private static SQLiteConnection connection;
       // private static SQLiteCommand command;

        static void Main(string[] args)
        {
            var temm = new Program();
            temm.CreateBDsql();
            temm.insertDb();
        }

        public static void connectionDb_1()
        {

            //connection = new SQLiteConnection($"Data Sourse={nameBd};Version=3;dateimeformat=CurrentCulture;"); // создание подключения к самой бд
                                                                                                                // connection.Open();
        }

        /// <summary>
        /// Созданние БД
        /// </summary>
        public  void CreateBDsql()
        {
             

            if (!File.Exists("test.db"))
            {
                try{

                    SQLiteConnection.CreateFile(nameBd); // созданиие бд

                    try{
                        SQLiteConnection connection = new SQLiteConnection(@"Data Sourse=test.db;Pooling=true;FailIfMissing=false;Version=3"); // создание подключения к самой бд
                        connection.Open();

                        string sql = "CREATE TABLE testtable (id integer key,data INT, txt TEXT, vchar varchar(81))"; // Создание конкретной таблице в бд 
                        SQLiteCommand command  = new SQLiteCommand(connection); // команды для передачи в бд

                        command.CommandText = sql; // отправка команды в бд
                        command.ExecuteNonQuery(); // команда выполнить.
                      //  connection.Close(); // отсоединение от базы
                        log += $"Создание БД  \t\n{DateTime.Now}\t\n";
                        connection.Close(); // отсоединение от базы
                    }
                    catch (Exception exx)
                    {
                        log += $"Ошибка при создании таблиц БД \t\n{exx}\t\n";
                        Console.WriteLine(log);

                    }

                   
                }
                catch(Exception ex)
                {
                    log += $"Ошибка при создании БД \t\n{ex}\t\n";
                    Console.WriteLine(log);
                }
            }

            else 
            {
                log += $"БД ранее была была созданна. \t\n";
               // connection.Close(); // отсоединение от базы
            }
            Console.WriteLine(log);
            Console.ReadKey();
        }
        
        public  void insertDb()
        {

             var  connection = new SQLiteConnection($"Data Sourse={nameBd};Version=3;dateimeformat=CurrentCulture;"); // создание подключения к самой бд
        //    SQLiteConnection connection = new SQLiteConnection("Data Sourse=test.db;Pooling=true;FailIfMissing=false;Version=3"); // создание подключения к самой бд
            connection.Open();


            string temTimeDatae = DateTime.Now.ToString();
            log += $"{temTimeDatae} Добавление в таблицу:";

            try
            {
                string sqlInserComand = $"Insert into testtable(data, txt, vchar) values(11,{temTimeDatae}, {log});";
                var command = new SQLiteCommand(connection); // команды для передачи в бд
              // connection.Open();
                command.CommandText = sqlInserComand; // отправка команды в бд
                command.ExecuteNonQuery(); // команда выполнить.
                connection.Close(); // отсоединение от базы
                log += "{temTimeDatae} Добавленны данные в таблицу";
            }
             
            catch (Exception ex)
                {
                    log += $"Ошибка добавлении данных в  БД \t\n{ex}\t\n";
                    Console.WriteLine(log);
                }

            Console.WriteLine(log);
            Console.ReadKey();
        }


    }
}

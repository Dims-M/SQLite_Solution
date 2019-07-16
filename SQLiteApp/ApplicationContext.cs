using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteApp
{
    /// <summary>
    /// Класс связи с БД
    /// </summary>
    class ApplicationContext : DbContext
    {
        //Конструктор класса
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Phone> Phones { get; set; } // свойства для работы и связи с бд
    }
}

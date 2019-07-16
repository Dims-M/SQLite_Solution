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

namespace SQLiteApp
{
    /// <summary>
    /// Логика взаимодействия для PhoneWindow.xaml
    /// </summary>
    public partial class PhoneWindow : Window
    {
        /// <summary>
        /// Связь с БД
        /// </summary>
        public Phone Phone { get; private set; }
        
        //Конструктор инициализироватся будет при запуске формы
        public PhoneWindow(Phone p)
        {
            InitializeComponent();

            Phone = p;
            this.DataContext = Phone; //связь с бд
        }
        //метод диалога
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

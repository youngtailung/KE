global using Appliances.Data;
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

namespace Appliances
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        dbContext DbContext;
        public AuthWindow(dbContext DbContext)
        {
            InitializeComponent();
            this.DbContext = DbContext;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string PasswordContent = Password.Password;
            if ((PasswordContent == "") && (Login.Text == "")) 
            {
                MessageBox.Show("Введите логин и пароль");
            } 
            else if(Login.Text == "")
            {
                MessageBox.Show("Введите логин");
            }
            else if(PasswordContent == "")
            {
                MessageBox.Show("Введите пароль");
            }
            else
            {
                var User = DbContext.Employees.Where(u => u.Login == Login.Text && u.Password == PasswordContent).FirstOrDefault();
                if (User != null)
                {
                    switch (User.PostId)
                    {
                        case 1:
                            MainWindow mainWindow = new MainWindow(this.DbContext, User);
                            mainWindow.Show();
                            Close();
                            break;
                        case 2:
                            Window1 window1 = new Window1();
                            window1.Show();
                            Close();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверные данные авторизации");
                }
            }
        }
    }
}

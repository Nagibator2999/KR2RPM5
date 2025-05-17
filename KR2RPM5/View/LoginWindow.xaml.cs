using KR2RPM5.Data;
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

namespace KR2RPM5.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
		public LoginWindow()
		{
			InitializeComponent();
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			using var db = new AppDBContext();
			var user = db.Users.FirstOrDefault(u => u.Login == txtLogin.Text && u.Password == txtPassword.Password);

			if (user != null)
			{
				new MainWindow(user).Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			new RegisterWindow().ShowDialog();
		}
	}
}


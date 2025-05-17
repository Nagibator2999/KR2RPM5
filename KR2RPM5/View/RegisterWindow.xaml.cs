using KR2RPM5.Data;
using KR2RPM5.Models;
using System.Windows;

namespace KR2RPM5.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
		public RegisterWindow()
		{
			InitializeComponent();
		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			using var db = new AppDBContext();

			if (db.Users.Any(u => u.Login == txtLogin.Text))
			{
				MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			var newUser = new User
			{
				Login = txtLogin.Text,
				Password = txtPassword.Password,
				FullName = txtFullName.Text,
				PhoneNumber = txtPhone.Text
			};

			db.Users.Add(newUser);
			db.SaveChanges();

			MessageBox.Show("Регистрация успешна", "Успешный успех", MessageBoxButton.OK, MessageBoxImage.Information);
			this.Close();
		}
	}
}

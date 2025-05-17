using KR2RPM5.Data;
using System.Windows;
using KR2RPM5.Models;

namespace KR2RPM5.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditInventoryWindow.xaml
    /// </summary>
    public partial class AddEditInventoryWindow : Window
    {
		public AddEditInventoryWindow()
		{
			InitializeComponent();
			dpReleaseDate.SelectedDate = DateTime.Now;
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtArticle.Text) || string.IsNullOrWhiteSpace(txtName.Text))
			{
				MessageBox.Show("Заполните обязательные поля", "Ошибка...(", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
			}

			using var db = new AppDBContext();

			var newItem = new Inventory
			{
				ArticleNumber = txtArticle.Text,
				Name = txtName.Text,
				Type = txtType.Text,
				Description = txtDescription.Text,
				ReleaseDate = dpReleaseDate.SelectedDate ?? DateTime.Now
			};

			db.Inventories.Add(newItem);
			db.SaveChanges();

			DialogResult = true;
			Close();
		}
	}
}

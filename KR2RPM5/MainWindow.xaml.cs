using KR2RPM5.Data;
using KR2RPM5.Models;
using KR2RPM5.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;

namespace KR2RPM5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _currentUser;

        public MainWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            DataContext = this;
            LoadInventory();
        }

        public User CurrentUser => _currentUser;

        private void LoadInventory()
        {
            using var db = new AppDBContext();
            inventoryGrid.ItemsSource = db.Inventories.Include(i => i.User).ToList();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }

        private void AddInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddEditInventoryWindow();
            if (dialog.ShowDialog() == true)
            {
                LoadInventory();
            }
        }
		private void DeleteInventoryButton_Click(object sender, RoutedEventArgs e)
		{
			if (inventoryGrid.SelectedItem is Inventory selectedItem)
			{					
                
				using var db = new AppDBContext();
				var itemToDelete = db.Inventories.FirstOrDefault(i => i.Id == selectedItem.Id);
				if (itemToDelete != null)
				{
					db.Inventories.Remove(itemToDelete);
					db.SaveChanges();
					LoadInventory();	
				}							
			}
			else
			{
				MessageBox.Show(
					"Пожалуйста, выберите инвентарь для удаления",
					"Не выбрана запись",
					MessageBoxButton.OK,
					MessageBoxImage.Warning);
			}
		}		
	}
}
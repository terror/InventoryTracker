using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InventoryTracker.Models;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);
        Item item = new Item();

        public Create()
        {
            txtName.Text = "Item #" + (item.GetID() + 1);
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            // Validate fields
            string cost = txtCost.Text; double parsedCost;
            if (!double.TryParse(cost, out parsedCost) || parsedCost < 0) {
                MessageBox.Show("Cost must be a valid integer or >= 0", "Cost", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string optimalQuantity = txtOptimalQuantity.Text; int parsedOptimalQuantity;
            if(!int.TryParse(optimalQuantity, out parsedOptimalQuantity) || parsedOptimalQuantity < 0) {
                MessageBox.Show("Optimal Quantity must be a valid integer or >= 0", "Optimal Quantity", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Set item properties
            item.Name = txtName.Text;
            item.Category = txtCategory.Text;
            item.Cost = parsedCost;
            item.OptimalQuantity = parsedOptimalQuantity;
            item.Supplier = txtSupplier.Text;
            item.Location = txtLocation.Text;

            // Add to list
            mainWindow.inventory.CreateItem(item);
        }
    }
}

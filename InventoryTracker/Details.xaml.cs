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

namespace InventoryTracker {
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window {
        MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);

        public Details() {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e) {
            // Validate fields and update item properties
            try {
                Item.CheckProperties(txtName.Text, txtCost.Text, txtOptimalQuantity.Text);
            }
            catch (Exception error) {
                MessageBox.Show(error.Message, "Item Property Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Item item = mainWindow.inventory.GetItemFromID((int)Tag);
            item.Name = txtName.Text;
            item.Cost = int.Parse(txtCost.Text);
            item.OptimalQuantity = int.Parse(txtOptimalQuantity.Text);
            item.Category = txtCategory.Text;
            item.Supplier = txtSupplier.Text;
            item.Location = txtLocation.Text;

            // Update main window -- IF DATA IS SORTED BY ANYTHING ASIDE FROM ID AND QUANTITY, WILL NEED TO SORT AGAIN
            Grid itemGrid = mainWindow.GetGridForItem(item.ID);
            TextBlock itemNameTextBlock = itemGrid.Children[0] as TextBlock;
            itemNameTextBlock.Text = item.Name;
            mainWindow.txtValue.Text = mainWindow.inventory.GetValue().ToString("C");

            Close();
        }
    }
}

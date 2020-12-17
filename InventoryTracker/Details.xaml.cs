using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
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
        MainWindow mainWindow;

        public Details(MainWindow mainWindow_, string tag, string title) {
            mainWindow = mainWindow_;
            Owner = mainWindow;
            Tag = tag;
            Title = title;
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e) {
            // Validate fields and update item properties
            try {
                Item.CheckProperties(txtName.Text, txtCost.Text, txtOptimalQuantity.Text);
            }
            catch (Exception error) {
                new CustomMessageBox(this, error.Message, "Item Property Error", SystemIcons.Error, SystemSounds.Hand).ShowDialog();
                return;
            }
            Item item = mainWindow.inventory.GetItemFromID((int)Tag);
            item.UpdateDetails(txtName.Text, double.Parse(txtCost.Text), int.Parse(txtOptimalQuantity.Text), txtCategory.Text, txtSupplier.Text, txtLocation.Text);

            // Update main window -- IF DATA IS SORTED BY ANYTHING ASIDE FROM ID AND QUANTITY, WILL NEED TO SORT AGAIN
            Grid itemGrid = mainWindow.GetGridForItem(item.ID);
            TextBlock itemNameTextBlock = itemGrid.Children[0] as TextBlock;
            itemNameTextBlock.Text = item.Name;
            mainWindow.UpdateTotalValue();

            Close();
        }
    }
}

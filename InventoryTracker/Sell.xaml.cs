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
    /// Interaction logic for Sell.xaml
    /// </summary>
    public partial class Sell : Window {
        MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);

        public Sell() {
            InitializeComponent();
        }

        private void btnSell_Click(object sender, RoutedEventArgs e) {
            foreach (Grid gr in spItemList.Children) {
                var id = gr.Tag;
                foreach (UIElement el in gr.Children) {
                    TextBox itemElement = el as TextBox;
                    if (itemElement == null) continue;

                    var amount = itemElement.Text; int parsedAmount;

                    if (int.TryParse(amount, out parsedAmount)) {
                        if (parsedAmount == 0) continue;

                        Item item = mainWindow.inventory.GetItemFromID(int.Parse(id.ToString()));

                        if (parsedAmount > item.Quantity || parsedAmount < 0) {
                            MessageBox.Show("Quantity must be greater than 0 and the item's current quantity.", "Quantity Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        item.Quantity -= parsedAmount;
                        // Update mainwindow here

                    } else { 
                          MessageBox.Show("Quantity must be a valid integer", "Quantity Error", MessageBoxButton.OK, MessageBoxImage.Error);
                          return;
                    }
                }
            }
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InventoryTracker.Models;
using System.Media;
using System.Drawing;

namespace InventoryTracker {
    /// <summary>
    /// Interaction logic for Sell.xaml
    /// </summary>
    public partial class Sell : Window {
        MainWindow mainWindow;

        public Sell(MainWindow mainWindow_) {
            mainWindow = mainWindow_;
            Owner = mainWindow;
            InitializeComponent();
        }

        private void btnSell_Click(object sender, RoutedEventArgs e) {
            foreach (Grid itemGrid in spItemList.Children.OfType<Grid>()) {

                int id = int.Parse(itemGrid.Tag.ToString());
                Item item = mainWindow.inventory.GetItemFromID(id);

                if (int.TryParse(((TextBox)itemGrid.Children[2]).Text, out int parsedAmount)) {
                    if (parsedAmount == 0) continue;

                    if (parsedAmount > item.Quantity || parsedAmount < 0) {
                        new CustomMessageBox(this, "Quantity must be greater than 0 and the item's current quantity.", "Quantity Error for " + item.Name, SystemIcons.Error, SystemSounds.Hand).ShowDialog();
                        return;
                    }

                    item.Sell(parsedAmount);

                    // Update MainWindow
                    Grid mainGrid = mainWindow.GetGridForItem(id);
                    ((TextBlock)mainGrid.Children[2]).Text = item.Quantity.ToString();
                    mainWindow.UpdateTotalValue();
                    mainWindow.UpdateTotalRevenue();
                    if (mainWindow.inventory.IsEmpty()) {
                        mainWindow.btnSellItem.IsEnabled = false;
                    }
                    mainWindow.justSaved = false;

                } else {
                    new CustomMessageBox(this, "Quantity must be a valid integer.", "Quantity Error for " + item.Name, SystemIcons.Error, SystemSounds.Hand).ShowDialog();
                    return;
                }
            }
            Close();
        }
    }
}
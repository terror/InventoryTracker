using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
using System.Drawing;
using InventoryTracker.Models;
using Microsoft.Win32;
using System.Media;

namespace InventoryTracker {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public Inventory inventory = new Inventory();
        private bool itemGridBGColor1 = true;

        public MainWindow() {
            InitializeComponent();

            // Set Sort Combobox
            cmbSortOptions.ItemsSource = new string[] { "ID", "Name", "Quantity", "Cost", "Optimal Quantity" };
            cmbSortOptions.SelectedIndex = 0;
            cmbSortOrder.ItemsSource = new string[] { "Ascending", "Descending" };
            cmbSortOrder.SelectedIndex = 0;
        }

        public void AddItemToWindow(Item item) {
            // Create Grid
            // IMPORTANT: Tag is used to differentiate each item using their ID
            Grid itemGrid = new Grid {
                Tag = item.ID,
                Height = 45
            };
            itemGrid.MouseDown += new MouseButtonEventHandler(spItemListChild_MouseDown);
            if (itemGridBGColor1) {
                itemGrid.Background = (System.Windows.Media.Brush)FindResource("ItemListColor1");
                itemGridBGColor1 = false;
            } else {
                itemGrid.Background = (System.Windows.Media.Brush)FindResource("ItemListColor2");
                itemGridBGColor1 = true;
            }

            // Define Columns
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) } );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition() );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(20, GridUnitType.Pixel) } );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = GridLength.Auto } );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) } );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = GridLength.Auto } );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) } );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(40, GridUnitType.Pixel) } );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(5, GridUnitType.Pixel) } );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(45, GridUnitType.Pixel) } );
            itemGrid.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(5, GridUnitType.Pixel) } );

            // Add TextBlocks and Buttons
            TextBlock txt1 = new TextBlock {
                Text = item.Name,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 20,
                FontWeight = FontWeights.DemiBold,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(5)
            };
            Grid.SetColumn(txt1, 1);
            itemGrid.Children.Add(txt1);

            TextBlock txt2 = new TextBlock {
                Text = "Quantity:",
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(txt2, 3);
            itemGrid.Children.Add(txt2);

            TextBlock txt3 = new TextBlock {
                Text = item.Quantity.ToString(),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Grid.SetColumn(txt3, 5);
            itemGrid.Children.Add(txt3);

            Button btn1 = new Button {
                Content = "➕",
                Foreground = (System.Windows.Media.Brush)FindResource("BackgroundColor"),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };
            Grid.SetColumn(btn1, 7);
            btn1.Click += new RoutedEventHandler(spItemListChildAddButton_Click);
            itemGrid.Children.Add(btn1);

            Button btn2 = new Button {
                Style = (Style)FindResource("DeleteButton")
            };
            Grid.SetColumn(btn2, 9);
            btn2.Click += new RoutedEventHandler(spItemListChildDelButton_Click);
            itemGrid.Children.Add(btn2);

            // Add to StackPanel
            spItemList.Children.Add(itemGrid);
        }

        public Grid GetGridForItem(int itemID) {
            foreach (Grid itemGrid in spItemList.Children.OfType<Grid>()) {
                if (itemGrid.Tag != null && (int)itemGrid.Tag == itemID)
                    return itemGrid as Grid;
            }
            return null;
        }

        public void UpdateItemListColorPattern() {
            itemGridBGColor1 = true;

            foreach (Grid itemGrid in spItemList.Children.OfType<Grid>()) {
                if (itemGridBGColor1) {
                    itemGrid.Background = (System.Windows.Media.Brush)FindResource("ItemListColor1");
                    itemGridBGColor1 = false;
                } else {
                    itemGrid.Background = (System.Windows.Media.Brush)FindResource("ItemListColor2");
                    itemGridBGColor1 = true;
                }
            }
        }

        public void UpdateTotalValue() {
            txtValue.Text = inventory.GetTotalValue().ToString("C");
        }

        public void UpdateTotalRevenue() {
            txtRevenue.Text = inventory.GetTotalRevenue().ToString("C");
        }

        public void btnCreateItem_Click(object sender, RoutedEventArgs e) {
            new Create(this).ShowDialog();
        }

        public void btnSellItem_Click(object sender, RoutedEventArgs e) {
            Sell sellPage = new Sell(this);

            // Copy Grids from Main Window for items in stock (Quantity > 0)
            bool itemGridSellBGColor1 = true;
            foreach (Grid itemGrid in spItemList.Children.OfType<Grid>()) {
                if (itemGrid.Tag != null && int.Parse(((TextBlock)itemGrid.Children[2]).Text) > 0) {
                    // Create Grid
                    // IMPORTANT: Tag is used to differentiate each item using their ID
                    Grid itemGridSell = new Grid {
                        Tag = itemGrid.Tag,
                        Height = itemGrid.Height
                    };
                    // No need to dynamically update the background for this StackPanel since items cannot be deleted from the list.
                    if (itemGridSellBGColor1) {
                        itemGridSell.Background = (System.Windows.Media.Brush)sellPage.FindResource("ItemListColor1");
                        itemGridSellBGColor1 = false;
                    } else {
                        itemGridSell.Background = (System.Windows.Media.Brush)sellPage.FindResource("ItemListColor2");
                        itemGridSellBGColor1 = true;
                    }

                    // Define Columns
                    itemGridSell.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) } );
                    itemGridSell.ColumnDefinitions.Add( new ColumnDefinition() );
                    itemGridSell.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(20, GridUnitType.Pixel) } );
                    itemGridSell.ColumnDefinitions.Add( new ColumnDefinition { Width = GridLength.Auto } );
                    itemGridSell.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) } );
                    itemGridSell.ColumnDefinitions.Add( new ColumnDefinition { MinWidth = 25, Width = GridLength.Auto } );
                    itemGridSell.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(5, GridUnitType.Pixel) } );
                    itemGridSell.ColumnDefinitions.Add( new ColumnDefinition { Width = GridLength.Auto } );
                    itemGridSell.ColumnDefinitions.Add( new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) } );

                    // Add TextBlocks and TextBox
                    TextBlock txt1 = new TextBlock {
                        Text = ((TextBlock)itemGrid.Children[0]).Text,
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        FontSize = 20,
                        FontWeight = FontWeights.DemiBold,
                        VerticalAlignment = VerticalAlignment.Center,
                        Padding = new Thickness(5)
                    };
                    Grid.SetColumn(txt1, 1);
                    itemGridSell.Children.Add(txt1);

                    TextBlock txt2 = new TextBlock {
                        Text = "Amount to sell:",
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    Grid.SetColumn(txt2, 3);
                    itemGridSell.Children.Add(txt2);

                    TextBox txt3 = new TextBox {
                        Text = "0",
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    Grid.SetColumn(txt3, 5);
                    itemGridSell.Children.Add(txt3);

                    TextBlock txt4 = new TextBlock {
                        Text = "/ " + ((TextBlock)itemGrid.Children[2]).Text,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    Grid.SetColumn(txt4, 7);
                    itemGridSell.Children.Add(txt4);

                    // Add to StackPanel
                    sellPage.spItemList.Children.Add(itemGridSell);
                }
            }

            sellPage.ShowDialog();
        }

        public void btnReportItem_Click(object sender, RoutedEventArgs e) {
            string report = inventory.GenerateReport();
            new CustomMessageBox(this, report, "Item Report").ShowDialog();
        }

        public void btnAnalysisItem_Click(object sender, RoutedEventArgs e) {
            string quantity = inventory.QuantityAnalysis();
            new CustomMessageBox(this, quantity, "Quantity Analysis").ShowDialog();
        }

        public void btnResetItem_Click(object sender, RoutedEventArgs e) {
            // Warn first
            CustomMessageBox messageBox = new CustomMessageBox(this, "Are you sure you want to reset the entire inventory?\nThis action cannot be reverted.",
                "Reset Confirmation", SystemIcons.Warning, SystemSounds.Exclamation, false);
            messageBox.ShowDialog();

            if (messageBox.clickedYes) {
                inventory.Reset();
                spItemList.Children.Clear();
                UpdateTotalValue();
                UpdateTotalRevenue();
            }
        }

        private void ReloadItemList(List<Item> items) {
            spItemList.Children.Clear();
            foreach (Item item in items) {
                AddItemToWindow(item);
            }
        }

        public void btnLoadItem_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json file|*.json";
            if (openFileDialog.ShowDialog() == true) {
                List<Item> items;
                try {
                    items = inventory.LoadFromFile(openFileDialog.FileName);
                }
                catch (Exception exception) {
                    new CustomMessageBox(this, "File could not be read:\n" + exception.Message, 
                        "Load Error", SystemIcons.Error, SystemSounds.Hand).ShowDialog();
                    return;
                }
                new CustomMessageBox(this, "Successfully loaded information from " + openFileDialog.FileName, "Load successful").ShowDialog();

                ReloadItemList(items);
                UpdateTotalValue();
                UpdateTotalRevenue();
                if (inventory.IsEmpty()) {
                    btnSellItem.IsEnabled = false;
                } else {
                    btnSellItem.IsEnabled = true;
                }
            }
        }

        public void btnSaveItem_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json file|*.json";
            if (saveFileDialog.ShowDialog() == true) {
                try {
                    inventory.SaveToFile(saveFileDialog.FileName);
                }
                catch (Exception exception) {
                    new CustomMessageBox(this, "File could not be written:\n" + exception.Message, 
                        "Save Error", SystemIcons.Error, SystemSounds.Hand).ShowDialog();
                    return;
                }
                new CustomMessageBox(this, "Successfully saved information to " + saveFileDialog.FileName, "Save successful").ShowDialog();
            }
        }

        private void spItemListChild_MouseDown(object sender, MouseEventArgs e) {
            Grid itemGrid = sender as Grid;
            Item item = inventory.GetItemFromID((int)itemGrid.Tag);

            Details detailsPage = new Details(this, item.ID.ToString(), "Details about " + item.Name);
            detailsPage.txtName.Text = item.Name;
            detailsPage.txtID.Text = item.ID.ToString();
            detailsPage.txtCost.Text = item.Cost.ToString();
            detailsPage.txtQuantity.Text = item.Quantity.ToString();
            detailsPage.txtOptimalQuantity.Text = item.OptimalQuantity.ToString();
            detailsPage.txtCategory.Text = (string.IsNullOrWhiteSpace(item.Category)) ? "N/A" : item.Category;
            detailsPage.txtSupplier.Text = (string.IsNullOrWhiteSpace(item.Supplier)) ? "N/A" : item.Supplier;
            detailsPage.txtLocation.Text = (string.IsNullOrWhiteSpace(item.Location)) ? "N/A" : item.Location;

            detailsPage.ShowDialog();
        }

        private void spItemListChildAddButton_Click(object sender, RoutedEventArgs e) {
            Button btn = sender as Button;
            Grid itemGrid = VisualTreeHelper.GetParent(btn) as Grid;
            TextBlock qty = itemGrid.Children[2] as TextBlock;
            Item item = inventory.GetItemFromID((int)itemGrid.Tag);

            // Increase item's quantity
            item.Quantity++;
            qty.Text = item.Quantity.ToString();
            UpdateTotalValue();

            // Enable selling
            btnSellItem.IsEnabled = true;
        }
         

        private void spItemListChildDelButton_Click(object sender, RoutedEventArgs e) {
            Button btn = sender as Button;
            Grid itemGrid = VisualTreeHelper.GetParent(btn) as Grid;
            Item item = inventory.GetItemFromID((int)itemGrid.Tag);

            // Warn first
            CustomMessageBox messageBox = new CustomMessageBox(this, "Are you sure you want to delete " + item.Name + "?", 
                "Delete Confirmation", SystemIcons.Warning, SystemSounds.Exclamation, false);
            messageBox.ShowDialog();

            if (messageBox.clickedYes) {
                inventory.DeleteItem(item);
         
                // Update visually
                spItemList.Children.Remove(itemGrid);
                UpdateItemListColorPattern();
                UpdateTotalValue();
                UpdateTotalRevenue();
                if (inventory.IsEmpty()) {      
                    btnSellItem.IsEnabled = false;
                }
            }
        }

        private void btnSort_Click(object sender, RoutedEventArgs e) {
            bool ascending = true;
            if (cmbSortOrder.SelectedIndex == 1) {
                ascending = false;
            }

            List<Item> items;
            switch (cmbSortOptions.SelectedIndex) {
                case 0: // ID
                    items = inventory.SortItems(ascending, x => x.ID);
                    break;
                case 1: // Name
                    items = inventory.SortItems(ascending, x => x.Name);
                    break;
                case 2: // Quantity
                    items = inventory.SortItems(ascending, x => x.Quantity);
                    break;
                case 3: // Cost
                    items = inventory.SortItems(ascending, x => x.Cost);
                    break;
                case 4: // Optimal Quantity
                    items = inventory.SortItems(ascending, x => x.OptimalQuantity);
                    break;
                default:
                    return;
            }
            ReloadItemList(items);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {

            // if not empty and not justsaved
            
            // use exit...
            //Error errorPage = new CustomMessageBox(this, "Unsaved Changes", "You have unsaved changes! If you close this application all data will be lost.\nAre you sure you want to leave?");
        }
    }
}
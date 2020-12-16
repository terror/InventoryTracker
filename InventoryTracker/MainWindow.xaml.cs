using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.IO;
>>>>>>> 05e5a7e09a5729d9167c59ad78fe892e4b3b7b6e
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> 05e5a7e09a5729d9167c59ad78fe892e4b3b7b6e
using InventoryTracker.Models;
using Microsoft.Win32;


namespace InventoryTracker {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public Inventory inventory = new Inventory();
        private bool itemGridBGColor1 = true;
        private string saveLocation;

        public MainWindow() {
            InitializeComponent();

            // Set Sort Combobox
            cmbSortOptions.ItemsSource = new string[] { "ID", "Name", "Quantity", "Cost", "Category", "Supplier" };
            cmbSortOptions.SelectedIndex = 0;
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
                itemGrid.Background = (Brush)FindResource("ItemListColor1");
                itemGridBGColor1 = false;
            } else {
                itemGrid.Background = (Brush)FindResource("ItemListColor2");
                itemGridBGColor1 = true;
            }

            // Define Columns
            ColumnDefinition colDef1 = new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) };
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition { Width = new GridLength(20, GridUnitType.Pixel) };
            ColumnDefinition colDef4 = new ColumnDefinition { Width = GridLength.Auto };
            ColumnDefinition colDef5 = new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) };
            ColumnDefinition colDef6 = new ColumnDefinition { Width = GridLength.Auto };
            ColumnDefinition colDef7 = new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) };
            ColumnDefinition colDef8 = new ColumnDefinition { Width = new GridLength(40, GridUnitType.Pixel) };
            ColumnDefinition colDef9 = new ColumnDefinition { Width = new GridLength(5, GridUnitType.Pixel) };
            ColumnDefinition colDef10 = new ColumnDefinition { Width = new GridLength(45, GridUnitType.Pixel) };
            ColumnDefinition colDef11 = new ColumnDefinition { Width = new GridLength(5, GridUnitType.Pixel) };
            itemGrid.ColumnDefinitions.Add(colDef1);
            itemGrid.ColumnDefinitions.Add(colDef2);
            itemGrid.ColumnDefinitions.Add(colDef3);
            itemGrid.ColumnDefinitions.Add(colDef4);
            itemGrid.ColumnDefinitions.Add(colDef5);
            itemGrid.ColumnDefinitions.Add(colDef6);
            itemGrid.ColumnDefinitions.Add(colDef7);
            itemGrid.ColumnDefinitions.Add(colDef8);
            itemGrid.ColumnDefinitions.Add(colDef9);
            itemGrid.ColumnDefinitions.Add(colDef10);
            itemGrid.ColumnDefinitions.Add(colDef11);

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
                Foreground = (Brush)FindResource("BackgroundColor"),
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(5),
                Margin = new Thickness(5)
            };
            Grid.SetColumn(btn1, 7);
            btn1.Click += new RoutedEventHandler(spItemListChildAddButton_Click);
            itemGrid.Children.Add(btn1);

            Button btn2 = new Button {
                Style = (Style)FindResource("DeleteButton"),
                Content = new Image {
                    Style = (Style)FindResource("DeleteButtonImage")
                }
            };
            Grid.SetColumn(btn2, 9);
            btn2.Click += new RoutedEventHandler(spItemListChildDelButton_Click);
            itemGrid.Children.Add(btn2);

            // Add to StackPanel -- IF DATA IS SORTED BY ANYTHING ASIDE FROM ID AND QUANTITY, WILL NEED TO SORT AGAIN
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
                    itemGrid.Background = (Brush)FindResource("ItemListColor1");
                    itemGridBGColor1 = false;
                } else {
                    itemGrid.Background = (Brush)FindResource("ItemListColor2");
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
            Create createPage = new Create {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            createPage.ShowDialog();
        }

        public void btnSellItem_Click(object sender, RoutedEventArgs e) {
            Sell sellPage = new Sell {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            // Copy Grids from Main Window for items in stock (Quantity > 0)
            bool itemGridSellBGColor1 = true;
            foreach (Grid itemGrid in spItemList.Children.OfType<Grid>()) {
                if (itemGrid.Tag != null && int.Parse(((TextBlock)itemGrid.Children[2]).Text) > 0) {
<<<<<<< HEAD
                    // Create Grid
                    // IMPORTANT: Tag is used to differentiate each item using their ID
=======
>>>>>>> 05e5a7e09a5729d9167c59ad78fe892e4b3b7b6e
                    Grid itemGridSell = new Grid {
                        Tag = itemGrid.Tag,
                        Height = itemGrid.Height
                    };
                    // No need to dynamically update the background for this StackPanel since items cannot be deleted from the list.
                    if (itemGridSellBGColor1) {
                        itemGridSell.Background = (Brush)sellPage.FindResource("ItemListColor1");
                        itemGridSellBGColor1 = false;
                    } else {
                        itemGridSell.Background = (Brush)sellPage.FindResource("ItemListColor2");
                        itemGridSellBGColor1 = true;
                    }

                    // Define Columns
                    ColumnDefinition colDef1 = new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) };
                    ColumnDefinition colDef2 = new ColumnDefinition();
                    ColumnDefinition colDef3 = new ColumnDefinition { Width = new GridLength(20, GridUnitType.Pixel) };
                    ColumnDefinition colDef4 = new ColumnDefinition { Width = GridLength.Auto };
                    ColumnDefinition colDef5 = new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) };
                    ColumnDefinition colDef6 = new ColumnDefinition { MinWidth = 25, Width = GridLength.Auto };
                    ColumnDefinition colDef7 = new ColumnDefinition { Width = new GridLength(5, GridUnitType.Pixel) };
                    ColumnDefinition colDef8 = new ColumnDefinition { Width = GridLength.Auto };
                    ColumnDefinition colDef9 = new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) };
                    itemGridSell.ColumnDefinitions.Add(colDef1);
                    itemGridSell.ColumnDefinitions.Add(colDef2);
                    itemGridSell.ColumnDefinitions.Add(colDef3);
                    itemGridSell.ColumnDefinitions.Add(colDef4);
                    itemGridSell.ColumnDefinitions.Add(colDef5);
                    itemGridSell.ColumnDefinitions.Add(colDef6);
                    itemGridSell.ColumnDefinitions.Add(colDef7);
                    itemGridSell.ColumnDefinitions.Add(colDef8);
                    itemGridSell.ColumnDefinitions.Add(colDef9);

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
            MessageBox.Show(report, "Item Report", MessageBoxButton.OK);
        }

        public void btnLoadItem_Click(object sender, RoutedEventArgs e) {
<<<<<<< HEAD
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json file|*.json";
            if (openFileDialog.ShowDialog() == true) {
                List<Item> itemList;
                try {
                    itemList = inventory.LoadFromFile(openFileDialog.FileName);
                }
                catch (Exception exception) {
                    MessageBox.Show("File could not be read:\n" + exception.Message, "Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Successfully loaded information from " + openFileDialog.FileName, "Load successful");

                // Update MainWindow
                spItemList.Children.Clear();
                foreach (Item item in itemList) {
                    AddItemToWindow(item);
                }
                UpdateTotalValue();
                UpdateTotalRevenue();
                if (inventory.IsEmpty()) {
                    btnSellItem.IsEnabled = false;
                } else {
                    btnSellItem.IsEnabled = true;
                }
            }
=======
            // var serializer = new JavascriptSerializer();
            // Load file from specific directory, deserialize string to dict
            // Loop through JSON and add items to MainWindow
            throw new NotImplementedException("oof");
>>>>>>> 05e5a7e09a5729d9167c59ad78fe892e4b3b7b6e
        }

        public void btnSaveItem_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json file|*.json";
            if (saveFileDialog.ShowDialog() == true) {
<<<<<<< HEAD
                try {
                    inventory.SaveToFile(saveFileDialog.FileName);
                }
                catch (Exception exception) {
                    MessageBox.Show("File could not be written:\n" + exception.Message, "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Successfully saved information to " + saveFileDialog.FileName, "Save successful");
=======
                MessageBox.Show("Saved information to " + saveFileDialog.FileName);
                saveLocation = saveFileDialog.FileName;
            }
            SaveDataToFile();
            Close();
        }
        private void SaveDataToFile() {
            try {
                // var serializer = new JavaScriptSerializer();
                // File.WriteAllLines(serializer.Serialize(inventory.items));
            }
            catch (Exception e) {
                MessageBox.Show(e.Message, "Saving Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
>>>>>>> 05e5a7e09a5729d9167c59ad78fe892e4b3b7b6e
            }
        }

        private void spItemListChild_MouseDown(object sender, MouseEventArgs e) {
            Grid itemGrid = sender as Grid;
            Item item = inventory.GetItemFromID((int)itemGrid.Tag);

            Details detailsPage = new Details {
                Owner = this,
                Tag = item.ID,
                Title = "Details about " + item.Name,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
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

            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to delete " + item.Name + "?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) {
                inventory.DeleteItem(item);

                // Update visually
                spItemList.Children.Remove(itemGrid);
                UpdateItemListColorPattern();
                UpdateTotalValue();
                UpdateTotalRevenue();
            }
        }
    }
}
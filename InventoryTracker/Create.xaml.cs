﻿using System;
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

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window {
        MainWindow mainWindow;

        public Create(MainWindow mainWindow_) {
            mainWindow = mainWindow_;
            Owner = mainWindow;
            InitializeComponent();
            txtName.Text = "Item #" + Item.NewestID();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e) {
            // Validate fields and set item properties
            try {
                Item.CheckProperties(txtName.Text, txtCost.Text, txtOptimalQuantity.Text);
            }
            catch (Exception error) {
                new CustomMessageBox(this, error.Message, "Item Property Error", SystemIcons.Error, SystemSounds.Hand).ShowDialog();
                return;
            }
            Item item = new Item(txtName.Text, double.Parse(txtCost.Text), int.Parse(txtOptimalQuantity.Text), txtCategory.Text, txtSupplier.Text, txtLocation.Text);

            // Add to list
            mainWindow.inventory.CreateItem(item);
            mainWindow.AddItemToWindow(item);
            mainWindow.justSaved = false;

            Close();
        }
    }
}

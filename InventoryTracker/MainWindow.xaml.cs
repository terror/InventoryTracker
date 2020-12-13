using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InventoryTracker.Models;

namespace InventoryTracker {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public Inventory inventory = new Inventory();

        public MainWindow() {
            InitializeComponent();
            // Set Sort Combobox
            cmbSortOptions.ItemsSource = new string[] { "Name", "Quantity", "Cost", "Category", "Supplier" };
            cmbSortOptions.SelectedIndex = 0;
        }

        public void btn_CreateItemClick() {
            Create createPage = new Create();
            createPage.Owner = this;
            createPage.ShowDialog();
        }

        public void btn_SellItemClick() {
            Sell sellPage = new Sell();
            sellPage.Owner = this;
            sellPage.ShowDialog;
        }

        public void btn_LoadItemClick() {
            throw new NotImplementedException("oof");
        }

        public void btn_SaveItemClick() {
            throw new NotImplementedException("oof");
        }
   }
}

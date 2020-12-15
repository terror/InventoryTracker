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
            // check every sell qty. cannot be under 0 or over item qty
            // update quantities in main window
            // disable sell button in main if all item quantities are 0
            // close window when done or let user sell multiple times? if so, also update quantities in sell window
            throw new NotImplementedException();
        }
    }
}

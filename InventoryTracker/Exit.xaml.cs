using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for Exit.xaml
    /// </summary>
    public partial class Exit : Window {
        public bool clickedSave = false;
        public bool willClose = true;

        public Exit(Window window) {
            Owner = window;
            Icon = CustomMessageBox.ConvertIconToImage(SystemIcons.Warning);
            SystemSounds.Exclamation.Play();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            clickedSave = true;
            Close();
        }

        private void btnDontSave_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            willClose = false;
            Close();
        }
    }
}

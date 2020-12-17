using System;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventoryTracker {
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window {
        /*static Show() {
            new CustomMessageBox
        }*/
        
        public CustomMessageBox(Window window, string message, string title, bool isOK = true) {
            Owner = window;
            Title = title;
            InitializeComponent();
            txtMessage.Text = message;
            if (isOK) {
                btnOK.Visibility = Visibility.Visible;
            } else {
                btnYes.Visibility = Visibility.Visible;
                btnNo.Visibility = Visibility.Visible;
            }
        }

        public CustomMessageBox(Window window, string message, string title, Icon icon, SystemSound sound, bool isOK = true) {
            Owner = window;
            Title = title;
            Icon = ConvertIconToImage(icon);
            sound.Play();
            InitializeComponent();
            txtMessage.Text = message;
            if (isOK) {
                btnOK.Visibility = Visibility.Visible;
            } else {
                btnYes.Visibility = Visibility.Visible;
                btnNo.Visibility = Visibility.Visible;
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e) {
            
        }

        // Conversion code made by 'Kenan E. K.' from Stack Overflow
        private static ImageSource ConvertIconToImage(Icon icon) {
            Bitmap bitmap = icon.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();
            return Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}

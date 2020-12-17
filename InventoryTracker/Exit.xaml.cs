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
using System.Windows.Shapes;

namespace InventoryTracker {
    /// <summary>
    /// Interaction logic for Exit.xaml
    /// </summary>
    public partial class Exit : Window {
        public Exit() {
            InitializeComponent();
        }
    }

    /*
        public Error(MainWindow mainWindow_, string title, string message, params string[] options) {
            mainWindow = mainWindow_;
            Owner = mainWindow;
            Title = title;
            txtMessage.Text = message;
            for (int i = 0; i < options.Length; i++) {

                grdMain.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) });
                grdMain.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                Button btn = new Button { Content = options[i] };
                Grid.SetRow(btn, 3);
                Grid.SetColumn(btn, i * 2);
                grdMain.Children.Add(btn);

            }
            InitializeComponent();
            
        } 
        */
}

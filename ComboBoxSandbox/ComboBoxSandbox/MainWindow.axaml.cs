using System.Linq;

using Avalonia.Controls;

namespace ComboBoxSandbox
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

            var items = new ItemMVVM[] { new ItemMVVM("1", "One"), new ItemMVVM("2", "Two"), new ItemMVVM("3", "Three") };            

            myItems.ItemsSource = items;            

            myCombo2Context.DataContext = new FormMVVM();            
            myCombo2.ItemsSource = items;

            myCombo3Context.DataContext = new FormMVVM();
        }        
    }
}
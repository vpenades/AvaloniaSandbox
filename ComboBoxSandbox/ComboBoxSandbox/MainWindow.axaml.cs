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

            myCombo1Context.DataContext = new FormMVVM();
            myCombo1.ItemsSource = items;

            myCombo2Context.DataContext = new FormMVVM();            
            myCombo2.ItemsSource = items;

            myCombo3Context.DataContext = new FormMVVM();
        }

        private void myCombo1_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            if (myCombo1Context.DataContext is FormMVVM mvvm)
            {
                mvvm.CurrentSelection = e.AddedItems.OfType<ItemMVVM>().FirstOrDefault().ActualValueToBeSet ?? "NULL";
            }
        }
    }
}
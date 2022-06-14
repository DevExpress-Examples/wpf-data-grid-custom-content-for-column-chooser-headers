using DevExpress.Xpf.Grid;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFGrid_ColumnChooser {
    public partial class MainWindow : Window {
        public class Item {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public MainWindow() {
            InitializeComponent();

            ObservableCollection<Item> items = new ObservableCollection<Item>();
            for (int i = 1; i < 30; i++) {
                items.Add(new Item() { Id = i, Name = "Name" + i });
            }
            grid.ItemsSource = items;
            view.ShowColumnChooser();
        }
    }
    public class HeaderTemplateSelector : DataTemplateSelector {
        public DataTemplate ColumnChooserTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            if (ColumnBase.GetHeaderPresenterType(container) == HeaderPresenterType.ColumnChooser && (string)item == nameof(Item.Id))
                return ColumnChooserTemplate;
            return base.SelectTemplate(item, container);
        }
    }
}

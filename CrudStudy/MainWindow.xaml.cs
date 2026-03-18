using CrudStudy.ViewModel;
using System.Windows;

namespace CrudStudy;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}

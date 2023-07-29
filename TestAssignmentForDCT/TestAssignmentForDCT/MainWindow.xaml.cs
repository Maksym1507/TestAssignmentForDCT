using System.Windows;
using TestAssignmentForDCT.ViewModels;

namespace TestAssignmentForDCT
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }
    }
}

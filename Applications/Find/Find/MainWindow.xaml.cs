using FindViewModel;
using System.Windows;

namespace Find
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FindViewModel.FindViewModel findViewModel = new FindViewModel.FindViewModel();
            DataContext = findViewModel;
        }
    }
}

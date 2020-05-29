using SumIntervals_WPF_Application.ViewModel;
using System.Windows;

namespace SumIntervals_WPF_Application.View
{
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        private ResultsWindowViewModel resultViewModel = new ResultsWindowViewModel();
        public ResultsWindow()
        {
            InitializeComponent();
            DataContext = resultViewModel;
        }

        private void OKButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

using SumIntervals_WPF_Application.Model;
using SumIntervals_WPF_Application.ViewModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SumIntervals_WPF_Application.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal ObservableCollection<IntervalModel> Intervals = new ObservableCollection<IntervalModel>();
        private MainWindowViewModel sumIntervalsViewModel;

        public MainWindow()
        {
            ResultsWindow resultsWindow = new ResultsWindow();
            resultsWindow.ShowDialog();
            InitializeComponent();
            IntervalItemsControl.ItemsSource = Intervals;
            sumIntervalsViewModel = new MainWindowViewModel(Intervals);
            DataContext = sumIntervalsViewModel;
            Intervals.CollectionChanged += IntervalsCollectionChanged;
        }

        private void AddIntervalButtonClick(object sender, RoutedEventArgs e)
        {
            Intervals.Add(new IntervalModel());
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Intervals.Remove((sender as FrameworkElement).DataContext as IntervalModel);
        }

        private void ClearIntervalsButtonClick(object sender, RoutedEventArgs e)
        {
            Intervals.Clear();
        }

        private void TextboxPreviewInput(object sender, TextCompositionEventArgs e)
        {
            if ((sender as TextBox).SelectionStart == 0
                && e.Text == "-"
                || long.TryParse(e.Text, out _)) return;
            e.Handled = true;
        }

        private void IntervalsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            sumIntervalsViewModel.IsEnabledGetSumButton = Intervals.Count > 0;
        }
    }
}
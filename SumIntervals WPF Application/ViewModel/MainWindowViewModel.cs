using SumIntervals_WPF_Application.Model;
using SumIntervals_WPF_Application.ViewModel.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Task11Library;

namespace SumIntervals_WPF_Application.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields/Properties

        private ObservableCollection<IntervalModel> Intervals { get; set; }
        public GetSumIntervalsCommand GetSumIntervalsCommand { get; }

        private readonly IntervalModel _intervalmodel = new IntervalModel();

        private int _result = 0;

        public int Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public int FirstInterval
        {
            get => _intervalmodel.FirstInterval;
            set
            {
                _intervalmodel.FirstInterval = value;
                OnPropertyChanged("FirstInterval");
            }
        }

        public int SecondInterval
        {
            get => _intervalmodel.SecondInterval;
            set
            {
                _intervalmodel.SecondInterval = value;
                OnPropertyChanged("SecondInterval");
            }
        }

        private bool _isEnabledGetSumButton;

        public bool IsEnabledGetSumButton
        {
            get => _isEnabledGetSumButton;
            set
            {
                _isEnabledGetSumButton = value;
                OnPropertyChanged("IsEnabledGetSumButton");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Fields/Properties

        public MainWindowViewModel(ObservableCollection<IntervalModel> Intervals)
        {
            this.Intervals = Intervals;
            GetSumIntervalsCommand = new GetSumIntervalsCommand(this);
        }

        internal void GetSumIntervals(object parameter)
        {
            ValueTuple<int, int>[] intervals = new ValueTuple<int, int>[Intervals.Count];
            for (int i = 0; i < Intervals.Count; i++)
            {
                intervals[i].Item1 = Intervals[i].FirstInterval;
                intervals[i].Item2 = Intervals[i].SecondInterval;
            }
            Result = SumIntervals.GetSumInterval(intervals);
            SaveResult.Save(new SumInterval { Result = this.Result });
            MessageBox.Show("Result: " + Result + "\nSaved to database.", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
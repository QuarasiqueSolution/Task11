using System;
using System.ComponentModel;

namespace SumIntervals_WPF_Application.Model
{
    internal class IntervalModel
    {
        private int _firstInterval = 0;

        public int FirstInterval
        {
            get => _firstInterval;
            set
            {
                _firstInterval = value;
                OnPropertyChanged("FirstInterval");
            }
        }

        private int _secondInterval = 0;

        public int SecondInterval
        {
            get => _secondInterval;
            set
            {
                _secondInterval = value;
                OnPropertyChanged("SecondInterval");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

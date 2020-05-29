using System.Collections.Generic;
using System.ComponentModel;
using Task11Library;

namespace SumIntervals_WPF_Application.ViewModel
{
    class ResultsWindowViewModel : INotifyPropertyChanged
    {
        private List<SumInterval> _resultList = new List<SumInterval>();
        public List<SumInterval> ResultList 
        {
            get => _resultList;
            set
            {
                _resultList = value;
                OnPropertyChanged("ResultList");
            }
        }

        private string _resultLabel = "";
        public string ResultLabel
        {
            get => _resultLabel;
            set
            {
                _resultLabel = value;
                OnPropertyChanged("ResultLabel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ResultsWindowViewModel()
        {
            ResultList = GetLastResults.GetRows();
            ResultLabel = "Last " + ResultList.Count + " result(s) from database: ";
        }
    }
}

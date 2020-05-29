using System;
using System.Windows.Input;

namespace SumIntervals_WPF_Application.ViewModel.Commands
{
    internal class GetSumIntervalsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly MainWindowViewModel _sumIntervalsViewModel;

        public GetSumIntervalsCommand(MainWindowViewModel sumIntervalsViewModel)
        {
            _sumIntervalsViewModel = sumIntervalsViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _sumIntervalsViewModel.GetSumIntervals(parameter);
        }
    }
}
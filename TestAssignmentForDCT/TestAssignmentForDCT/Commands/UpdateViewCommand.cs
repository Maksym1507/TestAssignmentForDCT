using System;
using System.Windows.Input;
using TestAssignmentForDCT.Services.Abstractions;
using TestAssignmentForDCT.ViewModels;

namespace TestAssignmentForDCT.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel _viewModel;
        private readonly ICoinService _coinService;
        private readonly IDialogService _dialogService;

        public UpdateViewCommand(MainWindowViewModel viewModel, ICoinService coinService, IDialogService dialogService)
        {
            _viewModel = viewModel;
            _coinService = coinService;
            _dialogService = dialogService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter?.ToString() == "Home")
            {
                _viewModel.SelectedViewModel = new HomeViewModel();
            }
            else if (parameter?.ToString() == "CoinList")
            {
                _viewModel.SelectedViewModel = new CoinListViewModel(_coinService, _dialogService);
            }
        }
    }
}

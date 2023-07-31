using Microsoft.Extensions.Options;
using System;
using System.Windows.Input;
using TestAssignmentForDCT.Config;
using TestAssignmentForDCT.Services;
using TestAssignmentForDCT.Services.Abstractions;
using TestAssignmentForDCT.ViewModels;

namespace TestAssignmentForDCT.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel _viewModel;
        private readonly ICoinService _coinService;

        public UpdateViewCommand(MainWindowViewModel viewModel, ICoinService coinService)
        {
            _viewModel = viewModel;
            _coinService = coinService;
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
                _viewModel.SelectedViewModel = new CoinListViewModel(_coinService);
            }
        }
    }
}

using System.Windows.Input;
using TestAssignmentForDCT.Commands;
using TestAssignmentForDCT.Services.Abstractions;

namespace TestAssignmentForDCT.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ICoinService _coinService;
        private readonly IDialogService _dialogService;

        public MainWindowViewModel(ICoinService coinService, IDialogService dialogService)
        {
            _coinService = coinService;
            _dialogService = dialogService;
            UpdateViewCommand = new UpdateViewCommand(this, coinService, dialogService);
            _selectedViewModel = new CoinListViewModel(_coinService, _dialogService);
        }

        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set 
            { 
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
    }
}

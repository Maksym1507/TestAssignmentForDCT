using System.Windows.Input;
using TestAssignmentForDCT.Commands;
using TestAssignmentForDCT.Services.Abstractions;

namespace TestAssignmentForDCT.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICoinService CoinService { get; }

        public MainWindowViewModel(ICoinService coinService)
        {
            CoinService = coinService;
            UpdateViewCommand = new UpdateViewCommand(this, coinService);            
        }

        private ViewModelBase _selectedViewModel = new HomeViewModel();

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

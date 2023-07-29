using System.Collections.ObjectModel;
using TestAssignmentForDCT.Models;
using TestAssignmentForDCT.MVVM;
using TestAssignmentForDCT.Services.Abstractions;

namespace TestAssignmentForDCT.ViewModels
{
    public class MainWindowViewModel : ViewModalBase
    {
        private readonly ICoinService _coinService;

        public MainWindowViewModel(ICoinService coinService)
        {
            _coinService = coinService;
            var coinList = _coinService.GetCertainCoinsAsync(Quantity);
            Coins = new ObservableCollection<CoinModel>(coinList);
        }

        public ObservableCollection<CoinModel> Coins { get; set; }

        private int _quantity = 10;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using TestAssignmentForDCT.Commands;
using TestAssignmentForDCT.Models;
using TestAssignmentForDCT.Services.Abstractions;

namespace TestAssignmentForDCT.ViewModels
{
    public class CoinListViewModel : ViewModelBase
    {
        private readonly ICoinService _coinService;
        private readonly IDialogService _dialogService;
        private ICollectionView _coinCollection;

        private int _quantity = 10;
        private CoinModel _selectedCoin;
        private string _coinName = string.Empty;

        public CoinListViewModel(ICoinService coinService, IDialogService dialogService)
        {
            _coinService = coinService;
            _dialogService = dialogService;
            var coinList = _coinService.GetCertainCoins(Quantity);
            Coins = new ObservableCollection<CoinModel>(coinList);
            CoinCollection = CollectionViewSource.GetDefaultView(Coins);
        }

        public ObservableCollection<CoinModel> Coins { get; set; }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public CoinModel SelectedCoin
        {
            get { return _selectedCoin; }
            set
            {
                _selectedCoin = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView CoinCollection
        {
            get { return _coinCollection; }
            set
            {
                _coinCollection = value;
            }
        }

        public string CoinName
        {
            get { return _coinName; }
            set
            {
                _coinName = value;
                CoinCollection.Filter = Filter;
            }
        }

        public RelayCommand GetCertainCoinsCommand => new RelayCommand(obj =>
        {
            int? quantity = obj as int?;

            if (quantity != null && quantity > 0 && quantity <= 2000)
            {
                var coinList = _coinService.GetCertainCoins(quantity.Value);

                if (coinList != null && coinList.Length > 0)
                {
                    if (Coins != null)
                    {
                        Coins.Clear();

                        foreach (var coin in coinList)
                        {
                            Coins!.Add(coin);
                        }
                    }
                    else
                    {
                        Coins = new ObservableCollection<CoinModel>(coinList);
                    }

                    CoinCollection = CollectionViewSource.GetDefaultView(Coins);
                }
            }
        });

        public RelayCommand GetCoinInfoByIdCommand => new RelayCommand(obj =>
        {
            var coin = _coinService.GetCoinById(SelectedCoin.Id);

            if (coin != null)
            {
                var coinDetailsViewModel = new CoinDetailsViewModel
                {
                    Coin = coin
                };

                _dialogService.ShowDialog("CoinDetailsWindow", coinDetailsViewModel);
            }

        }, canExecute => SelectedCoin != null);

        private bool Filter(object c)
        {
            CoinModel coin = c as CoinModel;

            if (!string.IsNullOrEmpty(CoinName))
            {
                return coin.Name.Contains(CoinName);
            }

            return true;
        }
    }
}

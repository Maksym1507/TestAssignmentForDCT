﻿using System.Collections.ObjectModel;
using TestAssignmentForDCT.Commands;
using TestAssignmentForDCT.Models;
using TestAssignmentForDCT.Services.Abstractions;

namespace TestAssignmentForDCT.ViewModels
{
    public class CoinListViewModel : ViewModelBase
    {
        private readonly ICoinService _coinService;

        public CoinListViewModel(ICoinService coinService)
        {
            _coinService = coinService;
            var coinList = _coinService.GetCertainCoins(Quantity);
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

        public RelayCommand GetCertainCoinsCommand => new RelayCommand(obj =>
        {
            int? quantity = obj as int?;

            if (quantity != null && quantity > 0 && quantity <= 2000)
            {
                var coinList = _coinService.GetCertainCoins(quantity.Value);

                if (coinList != null && coinList.Length > 0)
                {
                    Coins.Clear();

                    foreach (var coin in coinList)
                    {
                        Coins.Add(coin);
                    }
                }
            }
        });
    }
}

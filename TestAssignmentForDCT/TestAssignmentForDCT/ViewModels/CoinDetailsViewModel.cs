using TestAssignmentForDCT.Models;

namespace TestAssignmentForDCT.ViewModels
{
    public class CoinDetailsViewModel: ViewModelBase
    {
		private CoinModel _coin;

		public CoinModel Coin
		{
			get { return _coin; }
			set
            {
				_coin = value;
                OnPropertyChanged();
            }
		}
	}
}

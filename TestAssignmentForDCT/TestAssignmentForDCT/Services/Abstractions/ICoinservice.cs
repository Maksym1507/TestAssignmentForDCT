using System.Threading.Tasks;
using TestAssignmentForDCT.Models;

namespace TestAssignmentForDCT.Services.Abstractions
{
    public interface ICoinService
    {
        CoinModel[] GetCertainCoins(int quantity);

        CoinModel GetCoinById(string id);
    }
}

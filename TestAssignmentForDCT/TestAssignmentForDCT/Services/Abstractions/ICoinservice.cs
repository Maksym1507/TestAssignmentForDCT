using System.Threading.Tasks;
using TestAssignmentForDCT.Models;

namespace TestAssignmentForDCT.Services.Abstractions
{
    public interface ICoinService
    {
        CoinModel[] GetCertainCoinsAsync(int quantity);
    }
}

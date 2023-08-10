using TestAssignmentForDCT.ViewModels;

namespace TestAssignmentForDCT.Services.Abstractions
{
    public interface IDialogService
    {
        void ShowDialog(string dialogWindowName, ViewModelBase viewModel);
    }
}

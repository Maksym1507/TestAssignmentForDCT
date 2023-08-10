using TestAssignmentForDCT.Views.DialogWindows;
using TestAssignmentForDCT.Services.Abstractions;
using TestAssignmentForDCT.ViewModels;
using System;
using System.Windows;

namespace TestAssignmentForDCT.Services
{
    public class DialogService : IDialogService
    {
        public void ShowDialog(string dialogWindowName, ViewModelBase viewModel)
        {
            var coinDetailsWindow = new CoinDetailsWindow();

            var type = Type.GetType($"TestAssignmentForDCT.Views.DialogWindows.{dialogWindowName}");

            if ( type != null )
            {
                coinDetailsWindow.Title = dialogWindowName;

                if (viewModel != null)
                {
                    coinDetailsWindow.DataContext = viewModel;
                }
            }

            coinDetailsWindow.ShowDialog();
        }
    }
}

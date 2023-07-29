using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestAssignmentForDCT.MVVM
{
    public class ViewModalBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

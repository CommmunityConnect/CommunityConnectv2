using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommunityConnect.ViewModel
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> UserTypes { get; } = new ObservableCollection<string>
        {
            "User",
            "Admin"
        };

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


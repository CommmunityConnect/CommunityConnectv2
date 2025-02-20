using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace CommunityConnect.ViewModel
{
    public class AnnouncementsViewModel : INotifyPropertyChanged
    {
        private string waterCrisisMessage;

        public string WaterCrisisMessage
        {
            get => waterCrisisMessage;
            set
            {
                if (waterCrisisMessage != value)
                {
                    waterCrisisMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AcknowledgeCommand { get; }

        public AnnouncementsViewModel()
        {
            WaterCrisisMessage = "Attention: Due to severe drought conditions, there is a critical water shortage in our community. Please conserve water and avoid unnecessary usage. Further updates will be provided as the situation develops.";
            AcknowledgeCommand = new Command(OnAcknowledge);
        }

        private async void OnAcknowledge()
        {
            await Application.Current.MainPage.DisplayAlert("Acknowledged", "Thank you for acknowledging the announcement.", "OK");

            // Navigate back to the previous page
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


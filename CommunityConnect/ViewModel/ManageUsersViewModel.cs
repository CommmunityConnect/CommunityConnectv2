using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommunityConnect.ViewModel
{
    public class ManageUsersViewModel : INotifyPropertyChanged
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

        public ManageUsersViewModel()
        {
            WaterCrisisMessage = "Attention: Due to severe drought conditions, there is a critical water shortage in our community. Please conserve water and avoid unnecessary usage. Further updates will be provided as the situation develops.";
            
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

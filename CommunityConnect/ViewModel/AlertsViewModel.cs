using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityConnect.model;

namespace CommunityConnect.ViewModel
{
        public class AlertsViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private ObservableCollection<Incident> _incidents;
            public ObservableCollection<Incident> Incidents
            {
                get => _incidents;
                set
                {
                    if (_incidents != value)
                    {
                        _incidents = value;
                        OnPropertyChanged();
                    }
                }
            }

            public AlertsViewModel()
            {
                Incidents = new ObservableCollection<Incident>
            {
                new Incident { Title = "Potholes", Severity = "moderate", Description = "Urgent attention required at the location. Stay clear of the area.", Icon = "municipal_services.png" },
                new Incident { Title = "Robbery", Severity = "moderate", Description = "Urgent attention required at the location. Stay clear of the area.", Icon = "local_police.png" },
                new Incident { Title = "Water Crisis", Severity = "moderate", Description = "Urgent attention required at the location. Stay clear of the area.", Icon = "municipal_services.png" },
                new Incident { Title = "Accident", Severity = "severe", Description = "Urgent attention required at the location. Stay clear of the area.", Icon = "ambulance.png" },
            };
            }

            protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


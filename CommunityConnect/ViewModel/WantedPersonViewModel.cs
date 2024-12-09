using CommunityConnect.Pages;
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
     
        public class WantedPersonsViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<WantedPerson> WantedPersons { get; set; }

            public WantedPersonsViewModel()
            {
                WantedPersons = new ObservableCollection<WantedPerson>
        {
            new WantedPerson
            {
                FullName = "Malikoba Rituba Rigoba",
                Description = "14 July 1980, Malikoba Rituba Rigoba, Mentz.",
                Details = "On November 15, 2024, the suspect robbed a store in Mankweng (Pep) at 19h24. He took money and cellphones and when the police came, they couldn’t catch him.",
                Reward = true
            },
            new WantedPerson
            {
                FullName = "Johannes Amos Maleka",
                Description = "20 December 1970, Johannes Amos Maleka, Ga-Matlala",
                Details = "On 13 July 2023, the suspect hijacked a blue BMW opposite Limpopo Mall, Church Street. The suspect is confirmed to be tall and dark-skinned.",
                Reward = true
            }
        };
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }


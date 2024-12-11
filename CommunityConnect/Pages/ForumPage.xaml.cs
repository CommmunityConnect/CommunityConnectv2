using Microsoft.Maui.Controls;
using CommunityConnect.Pages;
using CommunityConnect.model;
using CommunityConnect.ViewModel;
 

namespace CommunityConnect.Pages
{
    public partial class ForumPage : ContentPage
    {
        public ForumPage()
        {
            InitializeComponent();
            AddGestureRecognizers();
        }

        private void AddGestureRecognizers()
        {

            // General Discussions
            GeneralDiscussionsFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => NavigateToPage("GeneralDiscussions"))
            });

            // Announcements
            AnnouncementsFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => NavigateToPage("Announcements"))
            });

            // Missing Persons
            MissingPersonsFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => NavigateToPage("MissingPersons"))
            });

            // Wanted Persons
            WantedPersonsFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => NavigateToPage("WantedPersons"))
            });
        }


        private async void NavigateToPage(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}

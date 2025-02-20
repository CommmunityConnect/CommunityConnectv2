using CommunityConnect.Data;
using CommunityConnect.ViewModel;
using CommunityConnect.Services;

namespace CommunityConnect
{
    public partial class App : Application
    {
         
        public App()
        {
            InitializeComponent();
             
            MainPage = new AppShell();

        }
        
    }


}


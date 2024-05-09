
using MuaiApp.Pages;

namespace MuaiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new NewPage1());
        }
    }
}

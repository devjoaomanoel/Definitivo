using Definitivo.Services;
using Definitivo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Definitivo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        public async static Task NavigateToProfile(string mensagem)
        {
            await App.Current.MainPage.Navigation.PushAsync(new ItemsPage(mensagem));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

using Definitivo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Definitivo;
using Definitivo.Views;

namespace Definitivo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        public void btnLogin_Clicked(object sender, EventArgs e)        
        {
            string mensagem = "";
            Application.Current.MainPage = new NavigationPage(new ItemsPage(mensagem));
        }

        private void btnLoginSemFace_Clicked(object sender, EventArgs e)
        {
            string mensagem = "";
            Application.Current.MainPage = new NavigationPage(new ItemsPage(mensagem));
        }
    }
}
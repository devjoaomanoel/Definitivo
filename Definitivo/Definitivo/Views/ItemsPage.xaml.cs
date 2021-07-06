using Definitivo.Models;
using Definitivo.ViewModels;
using Definitivo.Views;
using Definitivo.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Definitivo.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        ServicoFilmesApi servicoApi = new ServicoFilmesApi();

        public ItemsPage(string mensagem)
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();

            this.lblMensagem.Text = mensagem;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
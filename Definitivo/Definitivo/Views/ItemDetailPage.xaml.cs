using Definitivo.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using Definitivo.Services;
using Definitivo.Models;
using System;

namespace Definitivo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ServicoFilmesApi servicoApi = new ServicoFilmesApi();
        public ItemDetailPage(FilmesApi filmes)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

            if (filmes == null)
            {
                throw new ArgumentNullException(nameof(filmes));
            }

            InitializeComponent();
            BindingContext = filmes;
        }
    }
}
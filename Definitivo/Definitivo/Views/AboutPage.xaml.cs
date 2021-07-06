using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Definitivo.Services;
using Definitivo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Definitivo.Views
{

    public partial class AboutPage : ContentPage
    {
        ServicoFilmesApi servicoApi = new ServicoFilmesApi();
        public AboutPage()
        {
            InitializeComponent();
        }
        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //verifica a quantidade de caracteres digitados
            if (e.NewTextValue.Length > 5)
            {

                if (await servicoApi.LocalizarFilmes(e.NewTextValue) == null || (await servicoApi.LocalizarFilmes(e.NewTextValue)).Count == 0)
                {
                    //esconde o listview e exibe o label
                    //exibe a mensagem no label
                    lvwMovies.IsVisible = false;
                    lblmsg.IsVisible = true;
                    lblmsg.Text = "Não foi possível retornar a lista de filmes";
                    lblmsg.TextColor = Color.Red;
                }
                else
                {
                    //exibe o listview e esconde o label 
                    //exibe a lista de filmes
                    lvwMovies.IsVisible = true;
                    lblmsg.IsVisible = false;
                    lvwMovies.ItemsSource = await servicoApi.LocalizarFilmes(e.NewTextValue);
                }
            }
            else
            {
                //esconde o listview e exibe o label coma mensagem
                lvwMovies.IsVisible = false;
                lblmsg.IsVisible = true;
                lblmsg.Text = "Digite pelo menos 6 caracteres.";
            }
        }

        private async void lvwMovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            //obtem o item selecionado
            var filme = e.SelectedItem as FilmesApi;

            //deseleciona o item do listview
            lvwMovies.SelectedItem = null;

            //chama a pagina MovieDetailsPage
            await Navigation.PushAsync(new ItemDetailPage(filme));
        }
    }
}
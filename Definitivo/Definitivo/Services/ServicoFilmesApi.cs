using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Definitivo.Services
{
    public class ServicoFilmesApi
    {
        private HttpClient _client = new HttpClient();
        private List<ServicoFilmesApi> _filmes;

        public async Task<List<ServicoFilmesApi>> LocalizarFilmes(string filme)
        {
            if (string.IsNullOrEmpty(filme))
            {
                return null;
            }
            else
            {
                string url = string.Format("https://api.themoviedb.org/3/movie/popular?api_key=6315ec628de0bba3d60e2889df25c176");
                var response = await _client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _filmes = new List<ServicoFilmesApi>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var movies = JsonConvert.DeserializeObject<List<ServicoFilmesApi>>(content);
                    _filmes = new List<ServicoFilmesApi>(movies);
                }
                return _filmes;
            }
        }
    }
}

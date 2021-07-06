using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Definitivo.Models
{
    public class FilmesApi
    {
        [JsonProperty("movie_id")]
        public int Movie_Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("primary_release_year")]
        public int PrimaryReleaseYear { get; set; }

        [JsonProperty("Images")]
        public string ImageUrl { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }
    }
}

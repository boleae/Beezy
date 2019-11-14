namespace BeezyTest.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using BeezyTest.Serializers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DiscoveredMovies
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        public static string FromModel(DiscoveredMovies model) => JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.None,
                                                               Converter.Settings);

        public static DiscoveredMovies ToModel(string model) => JsonConvert.DeserializeObject<DiscoveredMovies>(model);
    }

    public partial class Result
    {
        private DateTime _releaseDate;

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("genre_ids")]
        public List<long> GenreIds { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("vote_average")]
        public long VoteAverage { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate
        {
            get
            {
                return _releaseDate;
            }
            set
            {
                this._releaseDate = value;
            }
        }
    }

   
}

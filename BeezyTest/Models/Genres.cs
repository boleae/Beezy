namespace BeezyTest.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using BeezyTest.Serializers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Genres
    {
        [JsonProperty("genres")]
        public List<GenreData> GenresList { get; set; }

        public static string FromModel(Genres model) => JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.None,
                                                                Converter.Settings);

        public static Genres ToModel(string model) => JsonConvert.DeserializeObject<Genres>(model);
    }

    public class GenreData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

  

   
}

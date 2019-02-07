using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutomaticSerieTvDownloader
{
    public partial class Sottotitoli
    {
        [JsonProperty("id_serie")]
        public long IdSerie { get; set; }

        [JsonProperty("nome_serie")]
        public string NomeSerie { get; set; }

        [JsonProperty("ep_titolo")]
        public string EpTitolo { get; set; }

        [JsonProperty("num_stagione")]
        public long NumStagione { get; set; }

        [JsonProperty("num_episodio")]
        public long NumEpisodio { get; set; }

        [JsonProperty("immagine")]
        public string Immagine { get; set; }

        [JsonProperty("link_sottotitoli")]
        public string LinkSottotitoli { get; set; }

        [JsonProperty("link_serie")]
        public string LinkSerie { get; set; }

        [JsonProperty("link_file")]
        public string LinkFile { get; set; }

        [JsonProperty("descrizione")]
        public string Descrizione { get; set; }

        [JsonProperty("id_thetvdb")]
        public long IdThetvdb { get; set; }

        [JsonProperty("data_uscita")]
        public System.DateTimeOffset DataUscita { get; set; }

        [JsonProperty("grazie")]
        public long Grazie { get; set; }
    }

    public partial class Sottotitoli
    {
        public static List<Sottotitoli> FromJson(string json) => JsonConvert.DeserializeObject<List<Sottotitoli>>(json, ConverterSub.Settings);
    }

    public static class SerializeSub
    {
        public static string ToJson(this List<Sottotitoli> self) => JsonConvert.SerializeObject(self, ConverterSub.Settings);
    }

    internal class ConverterSub
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

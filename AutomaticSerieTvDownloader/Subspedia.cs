using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutomaticSerieTvDownloader
{
    public partial class Subspedia
    {
        [JsonProperty("id_serie")]
        public long IdSerie { get; set; }

        [JsonProperty("nome_serie")]
        public string NomeSerie { get; set; }

        [JsonProperty("link_serie")]
        public string LinkSerie { get; set; }

        [JsonProperty("id_thetvdb")]
        public long IdThetvdb { get; set; }

        [JsonProperty("stato")]
        public Stato Stato { get; set; }

        [JsonProperty("anno")]
        public long Anno { get; set; }
    }

    public enum Stato { Conclusa, InAttesa, InCorso, InPausa, Rinnovata };

    public partial class Subspedia
    {
        public static List<Subspedia> FromJson(string json) => JsonConvert.DeserializeObject<List<Subspedia>>(json, AutomaticSerieTvDownloader.Converter.Settings);
    }

    static class StatoExtensions
    {
        public static Stato? ValueForString(string str)
        {
            switch (str)
            {
                case "Conclusa": return Stato.Conclusa;
                case "In attesa": return Stato.InAttesa;
                case "In corso": return Stato.InCorso;
                case "In pausa": return Stato.InPausa;
                case "Rinnovata": return Stato.Rinnovata;
                default: return null;
            }
        }

        public static Stato ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Stato value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Stato.Conclusa: serializer.Serialize(writer, "Conclusa"); break;
                case Stato.InAttesa: serializer.Serialize(writer, "In attesa"); break;
                case Stato.InCorso: serializer.Serialize(writer, "In corso"); break;
                case Stato.InPausa: serializer.Serialize(writer, "In pausa"); break;
                case Stato.Rinnovata: serializer.Serialize(writer, "Rinnovata"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this List<Subspedia> self) => JsonConvert.SerializeObject(self, AutomaticSerieTvDownloader.Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Stato) || t == typeof(Stato?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(Stato))
                return StatoExtensions.ReadJson(reader, serializer);
            if (t == typeof(Stato?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return StatoExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(Stato))
            {
                ((Stato)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

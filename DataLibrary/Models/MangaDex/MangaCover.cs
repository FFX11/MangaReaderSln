using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLibrary.Models.MangaDex
{

    public class MangaCover
    {
        [JsonPropertyName("response")]
        public string Response { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public CoverDatum[] Data { get; set; } = Array.Empty<CoverDatum>();
    }

    public class CoverDatum
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("attributes")]
        public AttributesCover Attributes { get; set; } = new();
    }

    public class AttributesCover
    {
        [JsonPropertyName("volume")]
        public string Volume { get; set; } = string.Empty;

        [JsonPropertyName("fileName")]
        public string FileName { get; set; } = string.Empty;
    }

}

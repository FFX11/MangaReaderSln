using System.Text.Json.Serialization;

namespace DataLibrary.Models.MangaDex
{

    public class ChapterModel
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;

        [JsonPropertyName("response")]
        public string Response { get; set; } = string.Empty;

        [JsonPropertyName("baseUrl")]
        public string BaseUrl { get; set; } = string.Empty;

        [JsonPropertyName("chapter")]
        public Chapter Chapter { get; set; } = new();
    }

    public class Chapter
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public string[] Data { get; set; } = Array.Empty<string>();

        [JsonPropertyName("dataSaver")]
        public object[] DataSaver { get; set; } = Array.Empty<string>();
    }


}

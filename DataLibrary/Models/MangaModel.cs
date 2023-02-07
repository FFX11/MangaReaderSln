//using System.Text.Json.Serialization;

//namespace BlazorApp1.Data
//{
//    public class MangaModel
//    {
//        [JsonPropertyName("result")]
//        public string Result { get; set; } = string.Empty;

//        [JsonPropertyName("volumes")]
//        public Dictionary<string, VolumeData> Volumes { get; set; } = new();
//    }

//    public class VolumeData
//    {
//        [JsonPropertyName("volume")]
//        public string Volume { get; set; } = string.Empty;

//        [JsonPropertyName("count")]
//        public int Count { get; set; }

//        [JsonPropertyName("chapters")]
//        public Dictionary<string, ChapterData> Chapters { get; set; } = new();
//    }

//    public class ChapterData
//    {
//        [JsonPropertyName("chapter")]
//        public string Chapter { get; set; } = string.Empty;

//        [JsonPropertyName("id")]
//        public string Id { get; set; } = string.Empty;

//        [JsonPropertyName("others")]
//        public string[] Others { get; set; } = Array.Empty<string>();

//        [JsonPropertyName("count")]
//        public int Count { get; set; }
//    }

//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLibrary.Models.MangaDex
{
    public class MangaGridModel
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;
        [JsonPropertyName("response")]
        public string Response { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public Datum[] Data { get; set; } = Array.Empty<Datum>();

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class Datum
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("Type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("Attributes")]
        public Attributes Attributes { get; set; } = new();

        [JsonPropertyName("Relationships")]
        public Relationship[] Relationships { get; set; } = Array.Empty<Relationship>();
        public string FullImgPath { get; set; } = string.Empty;
    }

    public class Attributes
    {
        [JsonPropertyName("title")]
        public Title Title { get; set; } = new();

        [JsonPropertyName("description")]
        public Description Description { get; set; } = new();

        [JsonPropertyName("lastVolume")]
        public string LastVolume { get; set; } = string.Empty;

        [JsonPropertyName("lastChapter")]
        public string LastChapter { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("year")]
        public int? Year { get; set; }

        [JsonPropertyName("contentRating")]
        public string ContentRating { get; set; } = string.Empty;

        [JsonPropertyName("tags")]
        public Tag[] Tags { get; set; } = Array.Empty<Tag>();

        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("chapterNumbersResetOnNewVolume")]
        public bool ChapterNumbersResetOnNewVolume { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("availableTranslatedLanguages")]
        public string[] AvailableTranslatedLanguages { get; set; } = Array.Empty<string>();

        [JsonPropertyName("latestUploadedChapter")]
        public string LatestUploadedChapter { get; set; } = string.Empty;
    }

    public class Title
    {
        [JsonPropertyName("en")]
        public string En { get; set; } = string.Empty;
    }

    public class Description
    {
        [JsonPropertyName("en")]
        public string En { get; set; } = string.Empty;
    }

    public class Tag
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("attributes")]
        public Attributes1 Attributes { get; set; } = new();

        [JsonPropertyName("relationships")]
        public Relationship[] Relationships { get; set; } = Array.Empty<Relationship>();
    }

    public class Attributes1
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; } = new Name();

        [JsonPropertyName("description")]
        public Description1 Description { get; set; } = new();
    }

    public class Name
    {
        [JsonPropertyName("en")]
        public string En { get; set; } = string.Empty;
    }

    public class Description1
    {
    }

    public class Relationship
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("attributes")]
        public Attributes2 Attributes { get; set; } = new();
    }

    public class Attributes2
    {
        [JsonPropertyName("fileName")]
        public string FileName { get; set; } = string.Empty;
    }

}

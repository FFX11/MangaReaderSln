using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models.MangaDex
{
    public class GetChapters
    {
        public string result { get; set; }
        public string response { get; set; }
        public DatumC[] data { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int total { get; set; }
    }

    public class DatumC
    {
        public string id { get; set; }
        public string type { get; set; }
        public AttributesC attributes { get; set; }
        public RelationshipC[] relationships { get; set; }
    }

    public class AttributesC
    {
        public string fileName { get; set; }
        public string title { get; set; }
        public string volume { get; set; }
        public string chapter { get; set; }
        public int pages { get; set; }
        public string translatedLanguage { get; set; }
        public string uploader { get; set; }
        public string externalUrl { get; set; }
        public int version { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string publishAt { get; set; }
        public string readableAt { get; set; }
    }

    public class RelationshipC
    {
        public string id { get; set; }
        public string type { get; set; }
        public string related { get; set; }
        public Attributes1C attributes { get; set; }
    }

    public class Attributes1C
    {
    }

}

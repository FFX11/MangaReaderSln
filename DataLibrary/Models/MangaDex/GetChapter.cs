using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models.MangaDex
{
    public class GetChapter
    {
        public string result { get; set; }
        public string response { get; set; }
        public Datas data { get; set; }
    }

    public class Datas
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributess attributes { get; set; }
        public Relationships[] relationships { get; set; }
    }

    public class Attributess
    {
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

    public class Relationships
    {
        public string id { get; set; }
        public string type { get; set; }
        public string related { get; set; }
        public Attributes1s attributes { get; set; }
    }

    public class Attributes1s
    {
    }

}

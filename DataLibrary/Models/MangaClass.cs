using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class MangaClass
    {
        [Key]
        public int MangaClassId { get; set; }
        public int UserId { get; set; }
        public string? MangaName { get; set; }
    }
}

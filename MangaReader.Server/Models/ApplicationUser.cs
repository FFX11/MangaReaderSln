using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MangaReader.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserModelId { get; set; }
        public string PhotoPath { get; set; } = string.Empty;
    }
}
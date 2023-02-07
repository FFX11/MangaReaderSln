using DataLibrary.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class MyUserModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [EmailAddress]
        //[EmailDomainValidator(AllowedDomain = "Admin.com")]
        public string Email { get; set; } = string.Empty;
        [Compare("Email",
        ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; } = string.Empty;
        public string? PhotoPath { get; set; } = string.Empty;
        public List<MangaClass> Manga { get; set; } = new();
        public int MangaClassId { get; set; }
        //public bool IsAuthenticated { get; set; }
    }
}

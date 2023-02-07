using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models.UserModels
{
    public class MangaUsersModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [EmailAddress]
        //[EmailDomainValidator(AllowedDomain = "Admin.com")]
        public string Email { get; set; } = string.Empty;
        [Compare("Email",
        ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public MangaClass Department { get; set; } = new();
    }
}

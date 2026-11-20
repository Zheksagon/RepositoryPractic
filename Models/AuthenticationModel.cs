using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Zadacha1zhd.Models
{
    public class AuthenticationModel : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Patronymic { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public int Role { get; set; } = 0;

        [NotMapped]
        public string LoginEmailPhoneNumber { get; set; } = string.Empty;

        [NotMapped]
        public string PhoneNumberEmail { get; set; } = string.Empty;

        [NotMapped]
        public string Password { get; set; } = string.Empty;

        [NotMapped]
        public int PINcode { get; set; }

        public PinCodeModel? PinCodeRecord { get; set; }
    }
}

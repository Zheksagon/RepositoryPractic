using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadacha1zhd.Models
{
    public class PinCodeModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public AuthenticationModel? User { get; set; } 

        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string PinCode { get; set; } = string.Empty;
    }
}
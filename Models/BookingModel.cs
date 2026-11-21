using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadacha1zhd.Models
{
    public class BookingModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientId { get; set; } = string.Empty;

        [ForeignKey("ClientId")]
        public AuthenticationModel? Client { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public RentProductModel? Product { get; set; }

        public DateTime StartRent { get; set; }

        public DateTime EndRent { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Ожидает подтверждения";
    }
}
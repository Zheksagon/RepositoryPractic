using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadacha1zhd.Models
{
    public class RentProductModel
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal PricePerDay { get; set; }

        public decimal Deposit { get; set; }

        public string URLImage { get; set; } = string.Empty;

        public int TotalQuantity { get; set; } = 1;

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryModel? Category { get; set; }
    }
}
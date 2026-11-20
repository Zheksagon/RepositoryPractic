using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadacha1zhd.Models
{
    public class RentProductModel
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string PricePerDay { get; set; } = string.Empty;

        public string Deposit { get; set; } = string.Empty;

        public string URLPicture { get; set; } = string.Empty;
    }
}
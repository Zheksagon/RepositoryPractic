using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Zadacha1zhd.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<RentProductModel> Products { get; set; } = new();
    }
}
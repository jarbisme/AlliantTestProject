using System.ComponentModel.DataAnnotations;

namespace AlliantTestProject.Data.Models
{
    public class CustomerItem
    {
        [Key]
        public int CustomerItemId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The quantity can have only 2 decimal places. (0.00)")]
        [Range(0.01, 9999999999999999.99)]
        public double Quantity { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The price can have only 2 decimal places. (0.00)")]
        [Range(0.01, 9999999999999999.99)]
        public double Price { get; set; }

        public bool IsActive { get; set; } = true;

        public Customer Customer { get; set; } = null!;

        public Item Item { get; set; } = null!;
    }
}

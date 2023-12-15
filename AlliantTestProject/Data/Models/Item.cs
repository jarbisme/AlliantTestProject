using System.ComponentModel.DataAnnotations;

namespace AlliantTestProject.Data.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required, Range(1, 99999999999)]
        public int ItemNumber { get; set; }

        [Required, MinLength(2)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.01, 9999999999999999.99)]
        public double DefaultPrice { get; set; }

        [Required, MaxLength(1, ErrorMessage = "Please use a Category with only 1 letter.")]
        public string ItemCategory { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<CustomerItem> CustomerItems { get; set; } = new List<CustomerItem>();
    }
}

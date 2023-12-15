using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AlliantTestProject.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required, Range(1,99999999999)]
        public int CustomerNumber { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; } = string.Empty;

        [Phone, RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string? Phone { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public ICollection<CustomerItem> CustomerItems { get; set; } = new List<CustomerItem>();


        public string GetPhoneNumberFormatted()
        {
            return FormatPhoneNumber(Phone);
        }

        private static string FormatPhoneNumber(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            value = new System.Text.RegularExpressions.Regex(@"\D")
                .Replace(value, string.Empty);
            value = value.TrimStart('1');
            if (value.Length == 7)
                return Convert.ToInt64(value).ToString("###-####");
            if (value.Length == 10)
                return Convert.ToInt64(value).ToString("###-###-####");
            if (value.Length > 10)
                return Convert.ToInt64(value)
                    .ToString("###-###-#### " + new String('#', (value.Length - 10)));
            return value;
        }
    }
}

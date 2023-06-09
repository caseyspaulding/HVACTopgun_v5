using System.ComponentModel.DataAnnotations;

namespace HVACTopGun.UI.Models
{
    public class DisplayCustomerModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "First name cannot be longer than 15 characters.")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long.")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(15, ErrorMessage = "Last name cannot be longer than 15 characters.")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long.")]
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}

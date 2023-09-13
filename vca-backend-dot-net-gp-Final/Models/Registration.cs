using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VCA.Models
{
    [Table("registration")]
    public class Registration
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Password correction")]
        [Column("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Company name length must be between 3 and 100 characters")]
        [Column("comp_name")]
        public string company_name { get; set; }

        [Required(ErrorMessage = "Address line 1 is required")]
        [StringLength(100, ErrorMessage = "Address line 1 length must not exceed 100 characters")]
        [Column("address_line1")]
        public string AddressLine1 { get; set; }

        [StringLength(100, ErrorMessage = "Address line 2 length must not exceed 100 characters")]
        [Column("address_line2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City name length must not exceed 50 characters")]
        [Column("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State name length must not exceed 50 characters")]
        [Column("state")]
        public string State { get; set; }

        [Required(ErrorMessage = "PIN code is required")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "PIN code must be a 6-digit number")]
        [Column("pin_code")]
        public string PinCode { get; set; }

        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid phone number format")]
        [Column("telephone")]
        public string telephone { get; set; }

        [Required(ErrorMessage = "Authorized person name is required")]
        [StringLength(100, ErrorMessage = "Authorized person name length must not exceed 100 characters")]
        [Column("authorized_person_name")]
        public string AuthorizedPersonName { get; set; }

        [RegularExpression("^[0-9A-Z]{15}$", ErrorMessage = "Invalid GST number format")]
        [Column("gst_number")]
        public string GstNumber { get; set; }
    }
}

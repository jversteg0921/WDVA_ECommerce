using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDVA_ECommerce.Shared
{
	public class PersonalInfo
	{
        public int Id { get; set; }
        public int UserId { get; set; }
		[Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]

        public string Street { get; set; } = string.Empty;
        [Required]

        public string City { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        [MaxLength(5, ErrorMessage="Zip Code must be 5 digits.")]
		[Range(0, Int64.MaxValue, ErrorMessage = "Zip code should only contain numbers")]
		public string Zip { get; set; } = string.Empty;
		public string Country { get; set; } = string.Empty;
        [Phone]
        [RegularExpression(@"^(\([0-9]{3}\) |[0-9]{3}-)[0-9]{3}-[0-9]{4}$", ErrorMessage ="Incorrect Phone Number")]		
		public string Phone { get; set; }
        [Required]
        public DateTime DOB { get; set; } = DateTime.Now;
		public string Gender { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIntro.Models
{
    public class Student
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 2 and 50 characters ")]
        public string Name { get; set; }

		[Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
		public string Email { get; set; }
    }
}
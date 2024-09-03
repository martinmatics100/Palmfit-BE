using Palmfit.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Palmfit.Application.Dtos.User
{
    public class Register
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("PasswordHash", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You must accept the terms and conditions.")]
        public TermsAndCondition AcceptsTerms { get; set; }
    }
}

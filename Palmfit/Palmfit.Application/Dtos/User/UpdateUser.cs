

using Microsoft.AspNetCore.Http;
using Palmfit.Domain.Enums;
using Palmfit.Domain.Enums.Units;
using System.ComponentModel.DataAnnotations;

namespace Palmfit.Application.Dtos.User
{
    public class UpdateUser
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public double? Height { get; set; }
        public IFormFile? Image { get; set; }
        public HeightUnit? HeightUnit { get; set; }
        public double? Weight { get; set; }
        public WeightUnit? WeightUnit { get; set; }
        public ActivityLevel? ActivityLevel { get; set; }
        public FitnessLevel? FitnessLevel { get; set; }
        public WeightGoal? WeightGoal { get; set; }
        public Gender? Gender { get; set; }
    }
}



using Palmfit.Domain.Enums;
using Palmfit.Domain.Enums.Units;

namespace Palmfit.Application.Dtos.User
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Timezone { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public double Height { get; set; }
        public HeightUnit HeightUnit { get; set; }
        public double Weight { get; set; }
        public WeightUnit WeightUnit { get; set; }
        //public double BMI => Weight / (Height * Height);    //Body Mass Index.
        public ActivityLevel ActivityLevel { get; set; }
        public FitnessLevel FitnessLevel { get; set; }
        public WeightGoal WeightGoal { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public DateTime SubscriptionExpiry { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public OnlineStatus OnlineStatus { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}

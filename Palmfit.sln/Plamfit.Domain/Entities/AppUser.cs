
using Plamfit.Domain.Enums;

namespace Plamfit.Domain.Entities
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? PhoneNumber { get; set; }  
        public string? Address { get; set; }   
        public string? City { get; set; }
        public string? State { get; set; } 
        public string? Country { get; set; }            
        public string? PostalCode { get; set; }

        // Fitness and Health Information
        public double Height { get; set; }             
        public double Weight { get; set; }
        public double GoalWeight { get; set; }
        public double BodyFatPercentage { get; set; }
        public double BMI { get; set; }
        public ActivityLevel? ActivityLevel { get; set; }
        public FitnessLevel? FitnessLevel { get; set; }
        public WeightGoal? WeightGoal { get; set; }


        // Subscription and Account Information
        public SubscriptionPlan? SubscriptionPlan { get; set; }
        public DateTime SubscriptionExpiry { get; set; } 
        public AccountStatus? AccountStatus { get; set; }
        public DateTime LastLogin { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
    }
}

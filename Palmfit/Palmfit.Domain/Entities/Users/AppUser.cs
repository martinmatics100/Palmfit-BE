using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Meals;
using Palmfit.Domain.Entities.Others;
using Palmfit.Domain.Entities.Payment;
using Palmfit.Domain.Enums;
using Palmfit.Domain.Enums.Units;

namespace Palmfit.Domain.Entities.Users
{
    public class AppUser : BaseEntity
    {

        public string? UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public TermsAndCondition AcceptsTerms { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Timezone { get; set; }
        public Gender Gender { get; set; }
        public string? ImageUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public string? FullAddress
        {
            get
            {
                var addressParts = new[] { Street, City, State, PostalCode, Country }
                                    .Where(part => !string.IsNullOrEmpty(part))
                                    .ToArray();
                return string.Join(", ", addressParts);
            }
        }


        // Fitness and Health Information
        public double Height { get; set; }
        public HeightUnit HeightUnit { get; set; }
        public double Weight { get; set; }
        public WeightUnit WeightUnit { get; set; }
        public double BMI => Weight / (Height * Height);    //Body Mass Index.
        public ActivityLevel ActivityLevel { get; set; }
        public FitnessLevel FitnessLevel { get; set; }
        public WeightGoal WeightGoal { get; set; }


        // Subscription and Account Information
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public DateTime SubscriptionExpiry { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public OnlineStatus OnlineStatus { get; set; }
        public DateTime? LastLogin { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }virtual  
        public ICollection<Invite> Invities { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; }
    }
}

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Meals;
using Palmfit.Domain.Entities.Others;
using Palmfit.Domain.Entities.Payment;
using Palmfit.Domain.Enums;

namespace Palmfit.Domain.Entities.Users
{
    public class AppUser : BaseEntity
    {

        public string? UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Fitness and Health Information
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }   //Body Mass Index.
        public ActivityLevel ActivityLevel { get; set; }
        public FitnessLevel FitnessLevel { get; set; }
        public WeightGoal WeightGoal { get; set; }


        // Subscription and Account Information
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public DateTime SubscriptionExpiry { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public DateTime LastLogin { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<Invite> Invities { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; }
    }
}



using Palmfit.Application.Interfaces.IRepository;
using Palmfit.Domain.Entities.Foods;
using Palmfit.Domain.Entities.Health;
using Palmfit.Domain.Entities.Meals;
using Palmfit.Domain.Entities.Others;
using Palmfit.Domain.Entities.Payment;
using Palmfit.Domain.Entities.Users;

namespace Palmfit.Infrastructure.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public IBaseRepository<AppUser> AppUserRepository { get; }
        public IBaseRepository<UserRole> UserRoleRepository { get; }
        public IBaseRepository<SystemRole> SystemRoleRepository { get; }
        public IBaseRepository<RefreshTokenInfo> RefreshTokenRepository { get; }
        public IBaseRepository<Invite> InviteRepository { get; }
        public IBaseRepository<UserOtp> UserOtpRepository { get; }
        public IBaseRepository<Subscription> SubscriptionRepository { get; }
        public IBaseRepository<Notification> NotificationRepository { get; }
        public IBaseRepository<NotificationConfig> NotificationConfigRepository { get; }
        public IBaseRepository<Feedback> FeedbackRepository { get; }
        public IBaseRepository<UserMealPlan> UserMealPlanRepository { get; }
        public IBaseRepository<MealPlan> MealPlanRepository { get; }
        public IBaseRepository<MealFood> MealFoodRepository { get; }
        public IBaseRepository<MealDiary> MealDiaryRepository { get; }
        public IBaseRepository<Meal> MealRepository { get; }
        public IBaseRepository<LoggedMeal> LoggedMealRepository { get; }
        public IBaseRepository<Health> HealthRepository { get; }
        public IBaseRepository<FoodClass> FoodClassRepository { get; }
        public IBaseRepository<Food> FoodRepository { get; }

        public RepositoryWrapper(IBaseRepository<AppUser> appUserRepository,
                                 IBaseRepository<UserRole> userRoleRepository,
                                 IBaseRepository<SystemRole> systemRoleRepository,
                                 IBaseRepository<RefreshTokenInfo> refreshTokenRepository,
                                 IBaseRepository<Invite> inviteRepository,
                                 IBaseRepository<UserOtp> userOtpRepository,
                                 IBaseRepository<Subscription> subscriptionRepository,
                                 IBaseRepository<Notification> notificationRepository,
                                 IBaseRepository<NotificationConfig> notificationConfigRepository,
                                 IBaseRepository<Feedback> feedbackRepository,
                                 IBaseRepository<UserMealPlan> userMealPlanRepository,
                                 IBaseRepository<MealPlan> mealPlanRepository,
                                 IBaseRepository<MealFood> mealFoodRepository,
                                 IBaseRepository<MealDiary> mealDiaryRepository,
                                 IBaseRepository<Meal> mealRepository,
                                 IBaseRepository<LoggedMeal> loggedMealRepository,
                                 IBaseRepository<Health> healthRepository,
                                 IBaseRepository<FoodClass> foodClassRepository,
                                 IBaseRepository<Food> foodRepository)
        {
            AppUserRepository = appUserRepository ?? throw new ArgumentNullException(nameof(appUserRepository));
            UserRoleRepository = userRoleRepository ?? throw new ArgumentNullException(nameof(userRoleRepository));
            SystemRoleRepository = systemRoleRepository ?? throw new ArgumentNullException(nameof(systemRoleRepository));
            RefreshTokenRepository = refreshTokenRepository ?? throw new ArgumentNullException(nameof(refreshTokenRepository));
            InviteRepository = inviteRepository ?? throw new ArgumentNullException(nameof(inviteRepository));
            UserOtpRepository = userOtpRepository ?? throw new ArgumentNullException( nameof(userOtpRepository));
            SubscriptionRepository = subscriptionRepository ?? throw new ArgumentNullException(nameof(subscriptionRepository));
            NotificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
            NotificationConfigRepository = notificationConfigRepository ?? throw new ArgumentNullException(nameof(NotificationConfigRepository));
            FeedbackRepository = feedbackRepository ?? throw new ArgumentNullException(nameof(feedbackRepository));
            UserMealPlanRepository = userMealPlanRepository ?? throw new ArgumentNullException(nameof(userMealPlanRepository));
            MealPlanRepository = mealPlanRepository ?? throw new ArgumentNullException(nameof(mealPlanRepository));
            MealFoodRepository = mealFoodRepository ?? throw new ArgumentNullException(nameof(mealFoodRepository));
            MealDiaryRepository = mealDiaryRepository ?? throw new ArgumentNullException(nameof(mealDiaryRepository));
            MealRepository = mealRepository ?? throw new ArgumentNullException(nameof(mealRepository));
            LoggedMealRepository = loggedMealRepository ?? throw new ArgumentNullException(nameof(loggedMealRepository));
            HealthRepository = healthRepository ?? throw new ArgumentNullException(nameof(healthRepository));
            FoodClassRepository = foodClassRepository ?? throw new ArgumentNullException(nameof(foodClassRepository));
            FoodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));



        }
    }
}

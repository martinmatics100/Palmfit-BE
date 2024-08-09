

using Microsoft.EntityFrameworkCore;
using Plamfit.Domain.Entities.Foods;
using Plamfit.Domain.Entities.Health;
using Plamfit.Domain.Entities.Meals;
using Plamfit.Domain.Entities.Others;
using Plamfit.Domain.Entities.Payments;
using Plamfit.Domain.Entities.Users;

namespace PalmFit.Infrastructure.Context
{
    public class PalmfitDbContext : DbContext 
    {
        public PalmfitDbContext(DbContextOptions<PalmfitDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodClass> FoodClasses { get; set; }

        public DbSet<Health> Healths { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealPlan> MealPlans { get; set; }

        public DbSet<Notifications> Notifications { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<UserOtp> UserOtps { get; set; }
    }
}

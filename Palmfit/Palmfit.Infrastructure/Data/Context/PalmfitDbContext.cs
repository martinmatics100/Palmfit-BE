
using Microsoft.EntityFrameworkCore;
using Palmfit.Domain.Entities.Foods;
using Palmfit.Domain.Entities.Health;
using Palmfit.Domain.Entities.Meals;
using Palmfit.Domain.Entities.Others;
using Palmfit.Domain.Entities.Payment;
using Palmfit.Domain.Entities.Users;

namespace Palmfit.Infrastructure.Data.Context
{
    public class PalmfitDbContext : DbContext
    {
        public PalmfitDbContext(DbContextOptions<PalmfitDbContext> dbContextoptions) : base(dbContextoptions) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; } 
        public DbSet<RefreshTokenInfo> RefreshTokens { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<UserOtp> UserOtps { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationConfig> NotificationConfig { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<UserMealPlan> UserMealPlans { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<MealFood> MealFood { get; set; }
        public DbSet<MealDiary> MealDiary { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<LoggedMeal> LoggedMeals { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<FoodClass> FoodClasses { get; set; }
        public DbSet<Food> Foods { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure MealPlan and Meals relationship
        //    modelBuilder.Entity<MealPlan>()
        //        .HasMany(mp => mp.Meals)
        //        .WithOne()
        //        .HasForeignKey(m => m.Id);

        //    // Configure Meal and MealFood relationship
        //    modelBuilder.Entity<Meal>()
        //        .HasMany(m => m.MealFoods)
        //        .WithOne(mf => mf.Meal)
        //        .HasForeignKey(mf => mf.MealId);

        //    // Configure UserRole entity
        //    modelBuilder.Entity<UserRole>()
        //        .HasMany(ur => ur.Users)
        //        .WithOne(u => u.UserRole)
        //        .HasForeignKey(u => u.UserRoleId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Configure AppUser entity
        //    modelBuilder.Entity<AppUser>()
        //        .HasOne(u => u.UserRole)
        //        .WithMany(ur => ur.Users)
        //        .HasForeignKey(u => u.UserRoleId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Configure the enum storage
        //    modelBuilder.Entity<UserRole>()
        //        .Property(ur => ur.RoleType)
        //        .HasConversion(
        //            v => (int)v,
        //            v => (UserRoleType)v
        //        );

        //    modelBuilder.Entity<AppUser>()
        //        .Property(u => u.UserRoleType)
        //        .HasConversion(
        //            v => (int)v,
        //            v => (UserRoleType)v
        //        );

        //    base.OnModelCreating(modelBuilder);

        //    // Seed roles
        //    modelBuilder.Entity<UserRole>().HasData(
        //        new UserRole { Id = Guid.NewGuid(), RoleType = UserRoleType.Admin, Description = "Administrator" },
        //        new UserRole { Id = Guid.NewGuid(), RoleType = UserRoleType.User, Description = "Regular User" }
        //    );
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FriendlyFood.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FriendlyFood.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Cuisine> Cuisine { get; set; }

        public DbSet<DietType> DietType { get; set; }

        public DbSet<FavoriteMeal> FavoriteMeal { get; set; }

        public DbSet<FavoriteRestaurant> FavoritRestaurant { get; set; }

        public DbSet<Meal> Meal { get; set; }

        public DbSet<MealDiet> MealDiet { get; set; }

        public DbSet<MealImage> MealImage { get; set; }

        public DbSet<Restaurant> Restaurant { get; set; }

        public DbSet<RestaurantDiet> RestaurantDiet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        

        // Create a new user for Identity Framework
        ApplicationUser user = new ApplicationUser
        {
            FirstName = "admin",
            LastName = "admin",
            ZipCode = "37220",
            City = "Nashville",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
            Id = "00000000-ffff-ffff-ffff-ffffffffffff"
        };
        var passwordHash = new PasswordHasher<ApplicationUser>();
        user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
        modelBuilder.Entity<ApplicationUser>().HasData(user);

    }

    }
}


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

        //create some restaurants
            Restaurant restaurant1 = new Restaurant
            {
                Id = 1,
                RestaurantName = "Wild Cow",
                Address = "1100 Fatherland St SUITE 104",
                ZipCode = 37206,
                CuisineId = 1,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant1);

            Restaurant restaurant2 = new Restaurant
            {
                Id = 2,
                RestaurantName = "Graze",
                Address = "1888 Eastland Ave",
                ZipCode = 37206,
                CuisineId = 2,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant2);

            Restaurant restaurant3 = new Restaurant
            {
                Id = 3,
                RestaurantName = "Woodlands",
                Address = "3415 West End Ave",
                ZipCode = 37203,
                CuisineId = 3,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant3);

            Restaurant restaurant4 = new Restaurant
            {
                Id = 4,
                RestaurantName = "City House",
                Address = "1222 4th Ave N",
                ZipCode = 37208,
                CuisineId = 4,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant4);

            Restaurant restaurant5 = new Restaurant
            {
                Id = 5,
                RestaurantName = "Farm Burger",
                Address = "4013 Charlotte Ave",
                ZipCode = 37209,
                CuisineId = 5,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant5);

            Restaurant restaurant6 = new Restaurant
            {
                Id = 6,
                RestaurantName = "Love Peace & Pho",
                Address = "2112 8th Ave S",
                ZipCode = 37204,
                CuisineId = 6,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant6);

            Restaurant restaurant7 = new Restaurant
            {
                Id = 7,
                RestaurantName = "San Antonio Taco Co",
                Address = "416 21st Ave S",
                ZipCode = 37203,
                CuisineId = 7,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant7);

            Restaurant restaurant8 = new Restaurant
            {
                Id = 8,
                RestaurantName = "Two Boots Nashville",
                Address = "1925 Broadway",
                ZipCode = 37203,
                CuisineId = 8,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant8);
        }

    }
}


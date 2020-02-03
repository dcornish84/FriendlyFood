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
                City = "Nashville",
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
                City = "Nashville",
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
                City = "Nashville",
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
                City = "Nashville",
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
                City = "Nashville",
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
                City = "Nashville",
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
                City = "Nashville",
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
                City = "Nashville",
                ZipCode = 37203,
                CuisineId = 8,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant8);

            Restaurant restaurant9 = new Restaurant
            {
                Id = 9,
                RestaurantName = "Siam Cafe",
                Address = "316 Mccall St",
                City = "Nashville",
                ZipCode = 37211,
                CuisineId = 9,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant9);

            Restaurant restaurant10 = new Restaurant
            {
                Id = 10,
                RestaurantName = "Crema",
                Address = "15 Hermitage Ave",
                City = "Nashville",
                ZipCode = 37204,
                CuisineId = 10,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant10);

            Restaurant restaurant11 = new Restaurant
            {
                Id = 11,
                RestaurantName = "Korea House",
                Address = "6410 Charlotte Pike #108",
                City = "Nashville",
                ZipCode = 37209,
                CuisineId = 11,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant11);

            Restaurant restaurant12 = new Restaurant
            {
                Id = 12,
                RestaurantName = "Henrietta Red",
                Address = "1200 4th Ave N",
                City = "Nashville",
                ZipCode = 37208,
                CuisineId = 12,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant12);

            Restaurant restaurant13 = new Restaurant
            {
                Id = 13,
                RestaurantName = "Marché Artisan Foods",
                Address = "1000 Main St",
                City = "Nashville",
                ZipCode = 37206,
                CuisineId = 13,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Restaurant>().HasData(restaurant13);

            //create some cuisines 

            Cuisine cuisine1 = new Cuisine
            {
                Id = 1,
                CuisineName = "Vegetarian",
                RestaurantId = restaurant1.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine1);

            Cuisine cuisine2 = new Cuisine
            {
                Id = 2,
                CuisineName = "Vegan",
                RestaurantId = restaurant2.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine2);

            Cuisine cuisine3 = new Cuisine
            {
                Id = 3,
                CuisineName = "Indian",
                RestaurantId = restaurant3.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine3);

            Cuisine cuisine4 = new Cuisine
            {
                Id = 4,
                CuisineName = "Italian",
                RestaurantId = restaurant4.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine4);

            Cuisine cuisine5 = new Cuisine
            {
                Id = 5,
                CuisineName = "Burger",
                RestaurantId = restaurant5.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine5);

            Cuisine cuisine6 = new Cuisine
            {
                Id = 6,
                CuisineName = "Vietnamese",
                RestaurantId = restaurant6.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine6);

            Cuisine cuisine7 = new Cuisine
            {
                Id = 7,
                CuisineName = "Mexican",
                RestaurantId = restaurant7.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine7);

            Cuisine cuisine8 = new Cuisine
            {
                Id = 8,
                CuisineName = "Pizza",
                RestaurantId = restaurant8.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine8);

            Cuisine cuisine9 = new Cuisine
            {
                Id = 9,
                CuisineName = "Thai",
                RestaurantId = restaurant9.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine9);

            Cuisine cuisine10 = new Cuisine
            {
                Id = 10,
                CuisineName = "Coffee",
                RestaurantId = restaurant10.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine10);

            Cuisine cuisine11 = new Cuisine
            {
                Id = 11,
                CuisineName = "Korean",
                RestaurantId = restaurant11.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine11);

            Cuisine cuisine12 = new Cuisine
            {
                Id = 12,
                CuisineName = "American",
                RestaurantId = restaurant12.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine12);

            Cuisine cuisine13 = new Cuisine
            {
                Id = 13,
                CuisineName = "Breakfast",
                RestaurantId = restaurant13.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Cuisine>().HasData(cuisine13);

            //create some meals

            Meal meal1 = new Meal
            {
                Id = 1,
                MealName = "Wild Reuban",
                Description = "Your choice of marinated, grilled organic tofu or tempeh topped w/ sauerkraut, " +
                                "shredded carrots, 1000 Island, spicy mustard & your choice of vegan mozzarella or dairy swiss. Served on marble rye.",
                RestaurantId = restaurant1.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Meal>().HasData(meal1);

            Meal meal2 = new Meal
            {
                Id = 2,
                MealName = "Spaghetti and Wheatballs",
                Description = "Spaghetti topped with BE-Hive seitan wheatballs, house made marinara, cashew paremsan" +
                                "chopped basil, parsley; served with toasted garlic bread.",
                RestaurantId = restaurant2.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Meal>().HasData(meal2);

            Meal meal3 = new Meal
            {
                Id = 3,
                MealName = "Gobi Manchurian",
                Description = "Dry cauliflower fritters with corn flour cooked in spicy manchurian sauce.",
                RestaurantId = restaurant3.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Meal>().HasData(meal3);

            Meal meal4 = new Meal
            {
                Id = 4,
                MealName = "Pizza",
                Description = "Belly Ham, Mozzarella, Parm, Oregano, Chilies.",
                RestaurantId = restaurant4.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Meal>().HasData(meal4);

            //create some dietary tags

            DietType dietType1 = new DietType
            {
                Id = 1,
                DietName = "Vegetarian",
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<DietType>().HasData(dietType1);

            DietType dietType2 = new DietType
            {
                Id = 2,
                DietName = "Vegan",
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<DietType>().HasData(dietType2);

            DietType dietType3 = new DietType
            {
                Id = 3,
                DietName = "Dairy Free",
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<DietType>().HasData(dietType3);

            DietType dietType4 = new DietType
            {
                Id = 4,
                DietName = "Gluten Free",
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<DietType>().HasData(dietType4);

            //join table between restaurants and diet types

            RestaurantDiet restaurantDiet1 = new RestaurantDiet
            { 
                Id = 1,
                RestaurantId = restaurant1.Id,
                DietTypeId = dietType1.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<RestaurantDiet>().HasData(restaurantDiet1);

            RestaurantDiet restaurantDiet2 = new RestaurantDiet
            {
                Id = 2,
                RestaurantId = restaurant2.Id,
                DietTypeId = dietType2.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<RestaurantDiet>().HasData(restaurantDiet2);

            //join table between meals and diet types

            MealDiet mealDiet1 = new MealDiet
            {
                Id = 1,
                MealId = meal1.Id,
                DietTypeId = dietType1.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<MealDiet>().HasData(mealDiet1);

            MealDiet mealDiet2 = new MealDiet
            {
                Id = 2,
                MealId = meal2.Id,
                DietTypeId = dietType2.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<MealDiet>().HasData(mealDiet2);

            //favorite Restaurants

            FavoriteRestaurant favoriteRestaurant1 = new FavoriteRestaurant
            {
                Id = 1,
                RestaurantId = restaurant1.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<FavoriteRestaurant>().HasData(favoriteRestaurant1);

            FavoriteRestaurant favoriteRestaurant2 = new FavoriteRestaurant
            {
                Id = 2,
                RestaurantId = restaurant2.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<FavoriteRestaurant>().HasData(favoriteRestaurant2);

            //favorite Meals
            
            FavoriteMeal favoriteMeal1 = new FavoriteMeal
            {
                Id = 1,
                MealId = meal1.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<FavoriteMeal>().HasData(favoriteMeal1);

            FavoriteMeal favoriteMeal2 = new FavoriteMeal
            {
                Id = 2,
                MealId = meal2.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<FavoriteMeal>().HasData(favoriteMeal2);

        }
    }



}



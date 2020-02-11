using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealImage_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteMeal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteMeal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteMeal_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteRestaurant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteRestaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteRestaurant_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealDiet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(nullable: false),
                    DietTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealDiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealDiet_DietType_DietTypeId",
                        column: x => x.DietTypeId,
                        principalTable: "DietType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealDiet_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    CuisineId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    MealId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurant_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurant_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cuisine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineName = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuisine_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantDiet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietTypeId = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantDiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantDiet_DietType_DietTypeId",
                        column: x => x.DietTypeId,
                        principalTable: "DietType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantDiet_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "City", "FirstName", "LastName", "ZipCode" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "4299b0d9-c30a-49db-942b-2d051144f443", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBOxztx4ubfrKXXk2NQYuRvnfE+pS6aBx/STWBi2IprE7qq0d3kVSOZBkY5qTRSqdA==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com", "Nashville", "admin", "admin", "37220" });

            migrationBuilder.InsertData(
                table: "Cuisine",
                columns: new[] { "Id", "CuisineName", "RestaurantId" },
                values: new object[,]
                {
                    { 13, "Breakfast", null },
                    { 12, "American", null },
                    { 11, "Korean", null },
                    { 10, "Coffee", null },
                    { 9, "Thai", null },
                    { 7, "Mexican", null },
                    { 8, "Pizza", null },
                    { 5, "Burger", null },
                    { 4, "Italian", null },
                    { 3, "Indian", null },
                    { 2, "Vegan", null },
                    { 1, "Vegetarian", null },
                    { 6, "Vietnamese", null }
                });

            migrationBuilder.InsertData(
                table: "DietType",
                columns: new[] { "Id", "DietName" },
                values: new object[,]
                {
                    { 3, "Dairy Free" },
                    { 1, "Vegetarian" },
                    { 2, "Vegan" },
                    { 4, "Gluten Free" }
                });

            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "Id", "Address", "ApplicationUserId", "City", "CuisineId", "MealId", "RestaurantName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "1100 Fatherland St SUITE 104", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 1, null, "Wild Cow", 37206 },
                    { 2, "1888 Eastland Ave", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 2, null, "Graze", 37206 },
                    { 3, "3415 West End Ave", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 3, null, "Woodlands", 37203 },
                    { 4, "1222 4th Ave N", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 4, null, "City House", 37208 },
                    { 5, "4013 Charlotte Ave", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 5, null, "Farm Burger", 37209 },
                    { 6, "2112 8th Ave S", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 6, null, "Love Peace & Pho", 37204 },
                    { 7, "416 21st Ave S", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 7, null, "San Antonio Taco Co", 37203 },
                    { 8, "1925 Broadway", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 8, null, "Two Boots Nashville", 37203 },
                    { 9, "316 Mccall St", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 9, null, "Siam Cafe", 37211 },
                    { 10, "15 Hermitage Ave", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 10, null, "Crema", 37204 },
                    { 11, "6410 Charlotte Pike #108", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 11, null, "Korea House", 37209 },
                    { 12, "1200 4th Ave N", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 12, null, "Henrietta Red", 37208 },
                    { 13, "1000 Main St", "00000000-ffff-ffff-ffff-ffffffffffff", "Nashville", 13, null, "Marché Artisan Foods", 37206 }
                });

            migrationBuilder.InsertData(
                table: "FavoriteRestaurant",
                columns: new[] { "Id", "ApplicationUserId", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "00000000-ffff-ffff-ffff-ffffffffffff", 1 },
                    { 2, "00000000-ffff-ffff-ffff-ffffffffffff", 2 }
                });

            migrationBuilder.InsertData(
                table: "Meal",
                columns: new[] { "Id", "ApplicationUserId", "Description", "MealName", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "00000000-ffff-ffff-ffff-ffffffffffff", "Your choice of marinated, grilled organic tofu or tempeh topped w/ sauerkraut, shredded carrots, 1000 Island, spicy mustard & your choice of vegan mozzarella or dairy swiss. Served on marble rye.", "Wild Reuban", 1 },
                    { 2, "00000000-ffff-ffff-ffff-ffffffffffff", "Spaghetti topped with BE-Hive seitan wheatballs, house made marinara, cashew paremsanchopped basil, parsley; served with toasted garlic bread.", "Spaghetti and Wheatballs", 2 },
                    { 3, "00000000-ffff-ffff-ffff-ffffffffffff", "Dry cauliflower fritters with corn flour cooked in spicy manchurian sauce.", "Gobi Manchurian", 3 },
                    { 4, "00000000-ffff-ffff-ffff-ffffffffffff", "Belly Ham, Mozzarella, Parm, Oregano, Chilies.", "Pizza", 4 }
                });

            migrationBuilder.InsertData(
                table: "RestaurantDiet",
                columns: new[] { "Id", "DietTypeId", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "FavoriteMeal",
                columns: new[] { "Id", "ApplicationUserId", "MealId" },
                values: new object[,]
                {
                    { 1, "00000000-ffff-ffff-ffff-ffffffffffff", 1 },
                    { 2, "00000000-ffff-ffff-ffff-ffffffffffff", 2 }
                });

            migrationBuilder.InsertData(
                table: "MealDiet",
                columns: new[] { "Id", "DietTypeId", "MealId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cuisine_RestaurantId",
                table: "Cuisine",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMeal_ApplicationUserId",
                table: "FavoriteMeal",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMeal_MealId",
                table: "FavoriteMeal",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteRestaurant_ApplicationUserId",
                table: "FavoriteRestaurant",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteRestaurant_RestaurantId",
                table: "FavoriteRestaurant",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_ApplicationUserId",
                table: "Meal",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_RestaurantId",
                table: "Meal",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MealDiet_DietTypeId",
                table: "MealDiet",
                column: "DietTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealDiet_MealId",
                table: "MealDiet",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealImage_ApplicationUserId",
                table: "MealImage",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ApplicationUserId",
                table: "Restaurant",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_CuisineId",
                table: "Restaurant",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_MealId",
                table: "Restaurant",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDiet_DietTypeId",
                table: "RestaurantDiet",
                column: "DietTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDiet_RestaurantId",
                table: "RestaurantDiet",
                column: "RestaurantId"
               );

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteMeal_Meal_MealId",
                table: "FavoriteMeal",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteRestaurant_Restaurant_RestaurantId",
                table: "FavoriteRestaurant",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Restaurant_RestaurantId",
                table: "Meal",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Cuisine_CuisineId",
                table: "Restaurant",
                column: "CuisineId",
                principalTable: "Cuisine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_AspNetUsers_ApplicationUserId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_AspNetUsers_ApplicationUserId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuisine_Restaurant_RestaurantId",
                table: "Cuisine");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Restaurant_RestaurantId",
                table: "Meal");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FavoriteMeal");

            migrationBuilder.DropTable(
                name: "FavoriteRestaurant");

            migrationBuilder.DropTable(
                name: "MealDiet");

            migrationBuilder.DropTable(
                name: "MealImage");

            migrationBuilder.DropTable(
                name: "RestaurantDiet");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DietType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Cuisine");

            migrationBuilder.DropTable(
                name: "Meal");
        }
    }
}

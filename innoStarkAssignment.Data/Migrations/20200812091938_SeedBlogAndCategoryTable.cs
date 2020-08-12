using Microsoft.EntityFrameworkCore.Migrations;

namespace innoStarkAssignment.Data.Migrations
{
    public partial class SeedBlogAndCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Categories (Name) Values ('News')");
            migrationBuilder
                .Sql("INSERT INTO Categories (Name) Values ('Technology')");
            migrationBuilder
                .Sql("INSERT INTO Categories (Name) Values ('Sports')");
            migrationBuilder
                .Sql("INSERT INTO Categories (Name) Values ('Politics')");

            migrationBuilder
                .Sql("INSERT INTO Blogs (Name, CategoryId) Values ('New Zealand free virus', (SELECT Id FROM Categories WHERE Name = 'News'))");
            migrationBuilder
                .Sql("INSERT INTO Blogs (Name, CategoryId) Values ('UK officially in recession.', (SELECT Id FROM Categories WHERE Name = 'News'))");

            migrationBuilder
                .Sql("INSERT INTO Blogs (Name, CategoryId) Values ('Missing Cryptoqueen', (SELECT Id FROM Categories WHERE Name = 'Technology'))");
            migrationBuilder
                .Sql("INSERT INTO Blogs (Name, CategoryId) Values ('Xbox brings blockbuster games to smartphones', (SELECT Id FROM Categories WHERE Name = 'Technology'))");
            migrationBuilder
                .Sql("INSERT INTO Blogs (Name, CategoryId) Values ('Police force facial recognition', (SELECT Id FROM Categories WHERE Name = 'Technology'))");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Blogs");

            migrationBuilder
                .Sql("DELETE FROM Categories");
        }
    }
}

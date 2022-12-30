using Kitab.Data.Static;
using Kitab.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Kitab.Data
{
    public static class KitabDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            KitabDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<KitabDbContext>();

            context.Database.EnsureCreated();

            //Categories
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new List<Category>()
                {
                    new Category()
                    {
                        Name = "Sales"
                    },
                    new Category()
                    {
                        Name = "Marketing"
                    },
                    new Category()
                    {
                        Name = "Business"
                    },
                    new Category()
                    {
                        Name = "Drama"
                    },
                    new Category()
                    {
                        Name = "Thriller"
                    },
                });
                context.SaveChanges();
            }

            //Author
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(new List<Author>()
                {
                    new Author()
                    {
                        FullName = "Dan Brown",
                        Bio = "This is the Bio of the Dan Brown",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                    },
                    new Author()
                    {
                        FullName = "Mark Strong",
                        Bio = "This is the Bio of the Mark Strong",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                    },
                    new Author()
                    {
                        FullName = "Manish Chaulagain",
                        Bio = "This is the Bio of the Manish Chaulagain",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                    },
                    new Author()
                    {
                        FullName = "Laxmi Prasad Devkota",
                        Bio = "This is the Bio of the Laxmi Prasad Devkota",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                    },
                    new Author()
                    {
                        FullName = "Phillip Kotler",
                        Bio = "This is the Bio of the Phillip Kotler",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                    }
                });
                context.SaveChanges();
            }

            //Publishers
            if (!context.Publishers.Any())
            {
                context.Publishers.AddRange(new List<Publisher>()
                {
                    new Publisher()
                    {
                        Name = "Scholastic",
                        Description = "This is the description of the Scholastic",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg"

                    },
                    new Publisher()
                    {
                        Name = "McGrawHill",
                        Description = "This is the description of the McGrawHill",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg"
                    },
                    new Publisher()
                    {
                        Name = "Simon & Schuster",
                        Description = "This is the description of the Simon & Schuster",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg"
                    },
                    new Publisher()
                    {
                        Name = "HarperCollins",
                        Description = "This is the Bio of the HarperCollins",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg"
                    },
                    new Publisher()
                    {
                        Name = "Penguin Books",
                        Description = "This is the Bio of the Penguin Books",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg"
                    }
                });
                context.SaveChanges();
            }

            //Books
            if (!context.Books.Any())
            {
                context.Books.AddRange(new List<Book>()
                {
                    new Book()
                    {
                        Title = "Kitchen Confidential",
                        Description = "This is the Kitchen Confidential book description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                        PublishedDate = DateTime.Now.AddDays(-10),
                        PublisherId = 3
                    },
                    new Book()
                    {
                        Title = "Cold Sales",
                        Description = "This is the Cold Sales book description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-2.jpeg",
                        PublishedDate = DateTime.Now.AddDays(-40),
                        PublisherId = 1
                    },
                    new Book()
                    {
                        Title = "Sapiens",
                        Description = "This is the Sapiens book description",
                        Price = 39.50,
                        ImageURL = "https://demork.cloudpub.in/Content/Uploadfiles/Title/97818/4655/8245/CoverPage/CoverLowResolution/9781846558245.png",
                        PublishedDate = DateTime.Now.AddDays(-120),
                        PublisherId = 2
                    },
                    new Book()
                    {
                        Title = "Principles of Marketing",
                        Description = "This is the Principle of Marketing book description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                        PublishedDate = DateTime.Now.AddDays(-50),
                        PublisherId = 5
                    },
                    new Book()
                    {
                        Title = "The Martian",
                        Description = "This is the Sharp Objects book description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                        PublishedDate = DateTime.Now.AddDays(-100),
                        PublisherId = 4
                    },
                    new Book()
                    {
                        Title = "The Republic",
                        Description = "This is the The Republic book description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-5.jpeg",
                        PublishedDate = DateTime.Now.AddDays(-90),
                        PublisherId = 3
                    }
                });
                context.SaveChanges();
            }

            //Authors & Books
            if (!context.Authors_Books.Any())
            {
                context.Authors_Books.AddRange(new List<Author_Book>()
                {
                    new Author_Book()
                    {
                        AuthorId = 1,
                        BookId = 1
                    },
                    new Author_Book()
                    {
                        AuthorId = 3,
                        BookId = 1
                    },
                    new Author_Book()
                    {
                        AuthorId = 1,
                        BookId = 2
                    },
                    new Author_Book()
                    {
                        AuthorId = 4,
                        BookId = 2
                    },
                    new Author_Book()
                    {
                        AuthorId = 1,
                        BookId = 3
                    },
                    new Author_Book()
                    {
                        AuthorId = 2,
                        BookId = 3
                    },
                    new Author_Book()
                    {
                        AuthorId = 5,
                        BookId = 3
                    },
                    new Author_Book()
                    {
                        AuthorId = 2,
                        BookId = 4
                    },
                    new Author_Book()
                    {
                        AuthorId = 3,
                        BookId = 4
                    },
                    new Author_Book()
                    {
                        AuthorId = 4,
                        BookId = 4
                    },
                    new Author_Book()
                    {
                        AuthorId = 2,
                        BookId = 5
                    },
                    new Author_Book()
                    {
                        AuthorId = 3,
                        BookId = 5
                    },
                    new Author_Book()
                    {
                        AuthorId = 4,
                        BookId = 5
                    },
                    new Author_Book()
                    {
                        AuthorId = 5,
                        BookId = 5
                    },
                    new Author_Book()
                    {
                        AuthorId = 3,
                        BookId = 6
                    },
                    new Author_Book()
                    {
                        AuthorId = 4,
                        BookId = 6
                    },
                    new Author_Book()
                    {
                        AuthorId = 5,
                        BookId = 6
                    },
                });
                context.SaveChanges();
            }

            //Categories & Books
            if (!context.Categories_Books.Any())
            {
                context.Categories_Books.AddRange(new List<Category_Book>()
                {
                    new Category_Book()
                    {
                        CategoryId = 1,
                        BookId = 1
                    },
                    new Category_Book()
                    {
                        CategoryId = 3,
                        BookId = 1
                    },
                    new Category_Book()
                    {
                        CategoryId = 1,
                        BookId = 2
                    },
                    new Category_Book()
                    {
                        CategoryId = 4,
                        BookId = 2
                    },
                    new Category_Book()
                    {
                        CategoryId = 1,
                        BookId = 3
                    },
                    new Category_Book()
                    {
                        CategoryId = 2,
                        BookId = 3
                    },
                    new Category_Book()
                    {
                        CategoryId = 5,
                        BookId = 3
                    },
                    new Category_Book()
                    {
                        CategoryId = 2,
                        BookId = 4
                    },
                    new Category_Book()
                    {
                        CategoryId = 3,
                        BookId = 4
                    },
                    new Category_Book()
                    {
                        CategoryId = 4,
                        BookId = 4
                    },
                    new Category_Book()
                    {
                        CategoryId = 2,
                        BookId = 5
                    },
                    new Category_Book()
                    {
                        CategoryId = 3,
                        BookId = 5
                    },
                    new Category_Book()
                    {
                        CategoryId = 4,
                        BookId = 5
                    },
                    new Category_Book()
                    {
                        CategoryId = 5,
                        BookId = 5
                    },
                    new Category_Book()
                    {
                        CategoryId = 3,
                        BookId = 6
                    },
                    new Category_Book()
                    {
                        CategoryId = 4,
                        BookId = 6
                    },
                    new Category_Book()
                    {
                        CategoryId = 5,
                        BookId = 6
                    },
                });
                context.SaveChanges();
            } 
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@kitab.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@kitab.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

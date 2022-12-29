using Microsoft.EntityFrameworkCore;
using Kitab.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kitab.Data
{
    public class KitabDbContext: IdentityDbContext<ApplicationUser>
    {
        public KitabDbContext(DbContextOptions<KitabDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            /*modelBuilder.Entity<Category_Book>().HasKey(am => new
            {
                am.CategoryId,
                am.BookId
            });*/

            modelBuilder.Entity<Category_Book>().HasOne(m => m.Book).WithMany(am => am.Categories_Books).HasForeignKey(m => m.BookId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Category_Book>().HasOne(m => m.Category).WithMany(am => am.Categories_Books).HasForeignKey(m => m.CategoryId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Author_Book>().HasOne(m => m.Book).WithMany(am => am.Authors_Books).HasForeignKey(m => m.BookId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Author_Book>().HasOne(m => m.Author).WithMany(am => am.Authors_Books).HasForeignKey(m => m.AuthorId).OnDelete(DeleteBehavior.Cascade);

            /*modelBuilder.Entity<Category_Book>()
                .HasRequired(c => c.Categories_Books)
                .WithMany()
                .WillCascadeOnDelete(false);*/

            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category_Book> Categories_Books { get; set; } = null!;
        public DbSet<Author_Book> Authors_Books { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;

        //Orders related tables
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

    }
}

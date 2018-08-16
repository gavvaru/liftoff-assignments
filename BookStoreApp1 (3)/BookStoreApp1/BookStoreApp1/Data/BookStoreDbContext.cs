using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp1.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookStoreApp1.Data
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BookModel> Books { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        { }

        public DbSet<BookStoreApp1.Models.BookModel> BookModel { get; set; }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
    {
        public BookStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<BookStoreDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new BookStoreDbContext(builder.Options);
        }
    }
}

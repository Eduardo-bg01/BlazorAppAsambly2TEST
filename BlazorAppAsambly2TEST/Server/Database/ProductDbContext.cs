using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlazorAppAsambly2TEST.Shared;
using BlazorAppAsambly2TEST.Client.Shared;

namespace BlazorAppAsambly2TEST.Server.Database
{
    public class ProductDbContext :DbContext
    {
        public ProductDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source = Products.db");
        }

        #region Constructor
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public propierties
        public DbSet<Product> Product { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Private methods
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1001, Name = "Laptop", Price = 20.02, Quantity = 10, Description ="This is a best gaming laptop"},
                new Product { Id = 1002, Name = "Microsoft Office", Price = 20.99, Quantity = 50, Description ="This is a Office Application"},
                new Product { Id = 1003, Name = "Lazer Mouse", Price = 12.02, Quantity = 20, Description ="The mouse that works on all surface"},
                new Product { Id = 1004, Name = "USB Storage", Price = 5.00, Quantity = 20, Description ="To store 256GB of data"}
            };
        }
        #endregion
    }
}
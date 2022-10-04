using BlazorAppAsambly2TEST.Client.Shared;
using BlazorAppAsambly2TEST.Server.Database;
using BlazorAppAsambly2TEST.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploAssemblyAppNet.Server.Service
{
    public class ProductServices
    {
        #region Private members
        private ProductDbContext dbContext;
        #endregion

        #region Constructor
        public ProductServices()
        {
            this.dbContext = new ProductDbContext();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// This method returns the list of product
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetProductAsync()
        {
            return await dbContext.Product.ToListAsync();
        }

        public async Task<Product> GetProductAsync(Product toFind)
        {
            return await dbContext.Product.FindAsync(toFind.Id);
        }

        /// <summary>
        /// This method add a new product to the DbContext and saves it
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                dbContext.Product.Add(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        /// <summary>
        /// This method update and existing product and saves the changes
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                var productExist = dbContext.Product.FirstOrDefault(p => p.Id == product.Id);
                if (productExist != null)
                {
                    dbContext.Update(product);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        /// <summary>
        /// This method removes and existing product from the DbContext and saves it
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(Product product)
        {
            try
            {
                dbContext.Product.Remove(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }

}
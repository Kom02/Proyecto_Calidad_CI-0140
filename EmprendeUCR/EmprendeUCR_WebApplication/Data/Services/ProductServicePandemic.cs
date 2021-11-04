using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR_WebApplication.Data;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class ProductServicePandemic : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlDbContextPandemic _context;

        public ProductServicePandemic(EmprendeUCR_WebApplication.Data.Contexts.SqlDbContextPandemic context)
        {
            _context = context;
        }

        public async Task<IList<Product>> GetAsync()    // Enlista productos
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<bool> InsertProductAsync(Product product) // Agrega productos
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> UpdateProductAsync(Product product) // Update productos
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> DeleteProductAsync(Product product) // Eliminar productos
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<Product> GetProductAsync(int Id)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(c => c.Code_ID.Equals(Id));
            return product;
        }


        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Product.ToListAsync();        // Listado 2
        }

        public async Task<IList<Product>> GetProductsEntrepreneurAsync(string email)
        {
            return await _context.Product.Where(c => String.Equals(c.Entrepreneur_Email, email)).ToListAsync();

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {

            return await _context.Product.Select(product => new Product { Code_ID = product.Code_ID, Product_Name = product.Product_Name, Price = product.Price }).ToListAsync();

        }

        public int GetProductsQuantity()
        {
            /*var parameterQuantity = new Microsoft.Data.SqlClient.SqlParameter
            {
                ParameterName = "quantity",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
            _context.Product.FromSqlRaw("EXECUTE GetQuantityProducts @quantity OUTPUT", parameterQuantity);
            return (int)parameterQuantity.Value;*/
            return _context.Product.Count();

        }

        public IList<Is_Able_To> getUserPermissions(string email)
        {
            return _context.Is_Able_To.Filter(o => o.Email.Equals(email)).ToArray();
        }
    }
}
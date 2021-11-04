using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class Product_ServiceService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public Product_ServiceService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Product_Service>> GetAsync()    // Enlista productos
        {
            return await _context.Product_Service.ToListAsync();
        }

        public async Task<int> InsertProductServiceAsync(Product_Service product_service) // Agrega productos
        {
            Console.WriteLine(product_service);
            Product_Service obj = product_service;
            await _context.Product_Service.AddAsync(obj);
            await _context.SaveChangesAsync();
            Console.WriteLine(obj);
            return obj.Code_ID;
        }



        public async Task<bool> UpdateProductServiceAsync(Product_Service product_service) // Update productos
        {
            _context.Product_Service.Update(product_service);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> DeleteProductServiceAsync(Product_Service product_service) // Eliminar productos
        {
            _context.Product_Service.Remove(product_service);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductServiceByIdAsync(int codeId) // Eliminar productos
        {
            try
            {
                Product_Service prod = _context.Product_Service.First(p => p.Code_ID == codeId);
                _context.Product_Service.Remove(prod);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
            
            
        }

        public async Task<Product_Service> GetProductServiceAsync(int Id)
        {
            Product_Service product_service = await _context.Product_Service.FirstOrDefaultAsync(c => c.Code_ID.Equals(Id));
            return product_service;
        }


        public async Task<List<Product_Service>> GetAllProductsServicesAsync()
        {
            return await _context.Product_Service.ToListAsync();        // Listado 2
        }

        public async Task<IList<Product_Service>> GetProductsServicesEntrepreneurAsync(string email)
        {
            return await _context.Product_Service.Where(c => String.Equals(c.Entrepreneur_Email, email)).ToListAsync();

        }


        public async Task<IList<Product_Service>> GetProductsByCategoryAsync(string email, int category_id)
        {
            return await _context.Product_Service.Where(product => String.Equals(product.Entrepreneur_Email, email) && product.Category_ID == category_id).ToListAsync();

        }


        public IList<Product_Service> GetList(string product)
        {
            return _context.Product_Service.FromSqlRaw("exec GetProducts @product =\"" + product + "\"").ToArray();
        }
    }

}


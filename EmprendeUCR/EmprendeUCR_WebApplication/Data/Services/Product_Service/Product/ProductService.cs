using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR_WebApplication.Data;
using EmprendeUCR_WebApplication.Data.Entities.ContextShop;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class ProductService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public ProductService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
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


        public async Task<bool> InsertProductTransactionAsync(Product product) // Agrega productos con transaccion
        {
            bool answer = false;

            using var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {

                if ((product.Price < 0) || (product.Category_ID < 0) || (product.Product_Name.Length() < 80 && product.Product_Name.Length() > 0))
                {
                    await transaction.RollbackAsync();
                }
                else
                {
                    await _context.Product.AddAsync(product);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    answer = true;
                }
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
            }
            return answer;


        }



        public async Task<bool> UpdateProductAsync(Product product) // Update productos
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }

  
        public async Task<IList<Product>> getProducts_By_Supplies(List<Product> product, List<HasSupplies> my_supplies)
        {

            List<Product> produ = new List<Product>();
            foreach (var prod in product)
            {
                bool valid_Product = my_supplies.FindAll(c => c.Supplie_ID == prod.Category_ID).Count() > 0;
                if (valid_Product)
                {


                    produ.Add(prod);


                }


            }

            return produ;


        }





        public async Task<bool> DeleteProductAsync(Product product) // Eliminar productos
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Product>> GetProductsByCategoryAsync(string email, int category_id)
        {
            return await _context.Product.Where(product => String.Equals(product.Entrepreneur_Email, email) && product.Category_ID == category_id).ToListAsync();

        }

        public async Task<Product> GetProductAsync(int Id)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(c => c.Code_ID.Equals(Id));
            return product;
        }

        public Product GetProduct(string Id)
        {
            return  _context.Product.FirstOrDefault(c => String.Equals(c.Code_ID.ToString(), Id));
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Product.ToListAsync();        // Listado 2
        }

        public async Task<IList<Product>> GetProductsEntrepreneurAsync(string email)
        {
            return await _context.Product.Where(c => String.Equals(c.Entrepreneur_Email, email)).ToListAsync();

        }

        public  IList<Product> GetProductsEntrepreneur(string email)
        {
            return _context.Product.Where(c => String.Equals(c.Entrepreneur_Email, email)).ToList();

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.Select(product => new Product { Code_ID = product.Code_ID, Product_Name = product.Product_Name, Price = product.Price }).ToListAsync();
        }
        public async Task<PagedList<Product>> GetProducts(ShopParameters shopParameters)
        {
            var products = await _context.Product.ToListAsync();
            return PagedList<Product>.ToPagedList(products, shopParameters.PageNumber, shopParameters.PageSize);
        }
        public async Task RemoveProduct(int Id)
        {
            Product ProductToRemove = await _context.Product.FindAsync(Id);
            _context.Product.Remove(ProductToRemove);
            await _context.SaveChangesAsync();
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

        public IList<Product> GetList(string product)
        {
            return _context.Product.FromSqlRaw("exec GetProducts \"" + product + "\"").ToArray();
        }

        public IList<Product> GetListByCategory(int categoryID)
        {
            return _context.Product.FromSqlRaw("exec GetProductsByCategory " + categoryID  ).ToArray();
        }


  
        public IList<Product> GetListRestricted(string product,int categoryID)
        {
            return _context.Product.FromSqlRaw("exec GetProductsRestricted \"" + product + "\","+  categoryID).ToArray();
        }

        public IList<Product> GetNewProducts()
        {
            return _context.Product.FromSqlRaw("exec getNewProducts").ToArray();
        }
        public IList<Product> GetOfferProducts()
        {
            return _context.Product.FromSqlRaw("exec getOfferProducts").ToArray();
        }
        public IList<Product> GetRecommendedProducts(string userEmail)
        {
            return _context.Product.FromSqlRaw("exec getRecommendedProducts \"" + userEmail + "\"").ToArray();
        }

        public Product GetProduct(int Id)
        {
            Product product =  _context.Product.FirstOrDefault(c => c.Code_ID.Equals(Id));
            return product;
        }
        public Service GetService(int Id)
        {
            Service service = _context.Service.FirstOrDefault(c => c.Code_ID.Equals(Id));
            return service;
        }
    }
}

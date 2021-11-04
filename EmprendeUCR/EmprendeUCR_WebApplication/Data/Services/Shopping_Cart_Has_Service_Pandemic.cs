using Dapper;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace EmprendeUCR_WebApplication.Data.Services
{
    public class Shopping_Cart_Has_Service_Pandemic: PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlDbContextPandemic _context;

        public Shopping_Cart_Has_Service_Pandemic(EmprendeUCR_WebApplication.Data.Contexts.SqlDbContextPandemic context)
        {
            _context = context;
        }

        public bool searchProduct(string email, int idProduct)
        {
            Shopping_Cart_Has existing = _context.Shopping_Cart_Has.FirstOrDefault(c => c.Email.Equals(email) && c.Code_ID == idProduct);
            if (existing != null)
            {
                return true;
            }
            return false;
        }

        public void addProduct(Shopping_Cart_Has product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public int GetProductsQuantity(string userEmail)
        {
            return _context.Shopping_Cart_Has.AsNoTracking().Where(sc => sc.Email == userEmail).Count();
        }
    }
}

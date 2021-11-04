using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace EmprendeUCR_WebApplication.Data.Services
{
    public class HasSuppliesService:PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public HasSuppliesService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }
        public async Task<IList<HasSupplies>> GetAsync()    // Enlista Ofertas
        {
            return await _context.HasSupplies.ToListAsync();
        }
        public async Task<bool> InsertHasSuppliesrAsync(HasSupplies supply) // Agrega Ofertas
        {
            await _context.HasSupplies.AddAsync(supply);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> InsertListOfHasSupplie(IList<HasSupplies> HasSuppliesList,int Code_ID,
        int Category_ID,string Entrepreneur_Email ) // Agrega Ofertas
        {
            try
            {
                foreach (var supply in HasSuppliesList)
                {
                    supply.Category_ID = Category_ID;
                    supply.Entrepreneur_Email = Entrepreneur_Email;
                    supply.Code_ID = Code_ID;
                    await InsertHasSuppliesrAsync(supply);
                }
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {

            }

            return true;
        }
        public async Task<List<HasSupplies>> GetAllHasSuppliesAsync()
        {
            return await _context.HasSupplies.ToListAsync();        // Listado 2
        }

        public List<HasSupplies> loadSuppliesByID(int Code_ID)
        {
            return _context.HasSupplies.Where(p => p.Code_ID == Code_ID).ToList();
        }

        public async Task<List<HasSupplies>> GetAllHasSuppliesEntrepreneurAsync(string entrepreneurEmail)
        {
            return await _context.HasSupplies.Where(h => h.Entrepreneur_Email == entrepreneurEmail).ToListAsync();  
        }

    }
}

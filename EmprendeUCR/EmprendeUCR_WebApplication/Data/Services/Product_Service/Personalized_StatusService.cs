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
    public class Personalized_StatusService
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public Personalized_StatusService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Personalized_Status>> GetAsync()    // Enlista estados
        {
            return await _context.Personalized_Status.ToListAsync();
        }
        public async Task<bool> InsertStatusAsync(Personalized_Status status) // Agrega estados
        {
            await _context.Personalized_Status.AddAsync(status);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> InsertListOfStatus(IList<Personalized_Status> status_List) // Agrega estados en lista
        {
            try
            {
                foreach (var status in status_List)
                {
                    await InsertStatusAsync(status);
                }
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {

            }

            return true;
        }


        public async Task<List<Personalized_Status>> GetAllStatusAsync()
        {
            return await _context.Personalized_Status.ToListAsync();        // Listado 2
        }
    }
}

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
    public class Has_StatusService
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public Has_StatusService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Has_Status>> GetAsync()    // Enlista estados
        {
            return await _context.Has_Status.ToListAsync();
        }
        public async Task<bool> InsertHas_StatusAsync(Has_Status status) // Agrega estados
        {
            await _context.Has_Status.AddAsync(status);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> InsertListOfHas_Status(IList<Has_Status> Has_Status_List) // Agrega estados en lista
        {
            try
            {
                for (int i = 0; i < Has_Status_List.Count(); i++)
                {
                    var has_status = Has_Status_List.ElementAt(i);

                    var statusExists = _context.Status.Exists(pred: s => s.Name == has_status.Name);
                    if (!statusExists)
                    {
                        var status = new Status();
                        status.Name = has_status.Name;
                        status.Previous_State_Name = null;
                        await _context.Status.AddAsync(status);
                        await _context.SaveChangesAsync();
                    }
                    var personalizedStatusExists = _context.Personalized_Status.Exists(s => s.Name == has_status.Name);
                    if (!personalizedStatusExists)
                    {
                        var personalizedStatus = new Personalized_Status();
                        personalizedStatus.Name = has_status.Name;
                        await _context.Personalized_Status.AddAsync(personalizedStatus);
                        await _context.SaveChangesAsync();
                    }

                    await InsertHas_StatusAsync(has_status);
                }
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {

            }

            return true;
        }
        public async Task<List<Has_Status>> GetAllHas_StatusAsync()
        {
            
            return await _context.Has_Status.ToListAsync();        // Listado 2
        }

        public List<Has_Status> loadStatusesByID(int Code_ID)
        {
            return _context.Has_Status.Where(p => p.Code_ID == Code_ID).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class ServiceService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public ServiceService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Service>> GetAsync()    // Enlista productos
        {
            return await _context.Service.ToListAsync();
        }

        public async Task<bool> InsertServiceAsync(Service service) // Agrega servicio
        {
            await _context.Service.AddAsync(service);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> InsertServiceTransactioAsync(Service service) // Agrega servicio con transaccion
        {
            bool answer = false;

            using var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {

                if ((service.Price_per_hour >=0) || (service.Category_ID < 0) || (service.Service_Name.Length() < 80 && service.Service_Name.Length() > 0))
                {
                    await transaction.RollbackAsync();
                }
                else
                {
                    await _context.Service.AddAsync(service);
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




        public async Task<bool> UpdateServiceAsync(Service service) // Update productos
        {
            _context.Service.Update(service);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> DeleteServiceAsync(Service service) // Eliminar productos
        {
            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<Service> GetServiceAsync(int Id)
        {
            Service service = await _context.Service.FirstOrDefaultAsync(c => c.Code_ID.Equals(Id));
            return service;
        }

        public Service GetService(string Id)
        {
            return _context.Service.FirstOrDefault(c => String.Equals(c.Code_ID.ToString(), Id));
        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await _context.Service.ToListAsync();        // Listado 2
        }

        public async Task<IList<Service>> GetServicesEntrepreneurAsync(string email)
        {
            return await _context.Service.Where(c => String.Equals(c.Entrepreneur_Email, email)).ToListAsync();

        }

        public IList<Service> GetServicesEntrepreneur(string email)
        {
            return _context.Service.Where(c => String.Equals(c.Entrepreneur_Email, email)).ToList();

        }

        public async Task<IList<Service>> GetServicesByCategoryAsync(string email, int category_id)
        {
            return await _context.Service.Where(service => String.Equals(service.Entrepreneur_Email, email) && service.Category_ID == category_id).ToListAsync();

        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            return await _context.Service.Select(service => new Service { Code_ID = service.Code_ID, Service_Name = service.Service_Name, Price_per_hour = service.Price_per_hour }).ToListAsync();
        }

        public int GetServicesQuantity()
        {
            return _context.Service.Count();
        }
    }
}

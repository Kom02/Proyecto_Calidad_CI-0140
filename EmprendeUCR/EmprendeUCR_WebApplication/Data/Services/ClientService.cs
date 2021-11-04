using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace EmprendeUCR_WebApplication.Data.Services
{
    public class ClientService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public ClientService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Client>> GetAsync()
        {
            return await _context.Client.ToListAsync();
        }

        public void AddClient(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public async Task<Client> GetByEmailAsync(string email)
        {
            return (await _context.Client.FindAsync(email));
        }

        public async Task<bool> Update(Client client)
        {
            _context.Client.Update(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

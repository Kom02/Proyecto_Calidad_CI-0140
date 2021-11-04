using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System;
using System.Linq;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class CredentialsService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public static string key = "@emprende_password";

        public CredentialsService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Credentials>> GetAsync()
        {
            return await _context.Credentials.ToListAsync();
        }

        public void AddCredentials(Credentials credentials)
        {
            _context.Credentials.Add(credentials);
            _context.SaveChanges();
        }

        public void updateCredentials(Credentials _credentials)
        {
            Credentials credentials = _context.Credentials.FirstOrDefault(c => c.User_Email.Equals(_credentials.User_Email));
            if (credentials != null)
            {
                credentials.User_Email = _credentials.User_Email;
                credentials.Password = _credentials.Password;
                _context.Update(credentials);
                _context.SaveChanges();

            }
        }

        public Credentials getCredentials(string email) {
            Credentials getCredentials = null;
            Credentials credentials = _context.Credentials.FirstOrDefault(c => c.User_Email.Equals(email));
            if (credentials!=null) {
                getCredentials = credentials;
            }
            return getCredentials;
        }

        public async Task<string> GetPasswordAsync(string Email)
        {
            Credentials credentials = await _context.Credentials.FirstOrDefaultAsync(c => c.User_Email.Equals(Email));
            if (credentials == null)
            {

                return "";
            }
            else
            {
                return credentials.Password.ToString();
            }
        }
    }
}

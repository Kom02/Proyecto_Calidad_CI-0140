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
    public class PhonesService
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public PhonesService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public void addPhone(Phones phones)
        {
            _context.Phones.Add(phones);
            _context.SaveChanges();
        }

        public async Task<Phones> getByEmailAsync(string email)
        {
            return await _context.Phones.FindAsync(email);
        }

        public Phones GetPhoneByEmail(string email)
        {
            return _context.Phones.FirstOrDefault(c => c.User_Email.Equals(email));
        }

        public void UpdatePhone(string email, string phone)
        {
            Phones UserPhone = _context.Phones.FirstOrDefault(c => c.User_Email.Equals(email));
            if(UserPhone != null)
            {
                UserPhone.Phone_Number = phone;
                _context.Phones.Update(UserPhone);
                _context.SaveChanges();
            }
        }
    }
}
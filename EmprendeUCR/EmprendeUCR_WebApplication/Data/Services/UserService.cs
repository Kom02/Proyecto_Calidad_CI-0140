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
    public class UserService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public UserService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }


        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User _user)
        {
            User user = _context.User.FirstOrDefault(c => c.Email.Equals(_user.Email));
            if (user!=null)
            {
                user.Province_Name = _user.Province_Name;
                user.Canton_Name = _user.Canton_Name;
                user.District_Name = _user.District_Name;

                user.Photo = _user.Photo;

                user.Name = _user.Name;
                user.F_Last_Name = _user.F_Last_Name;
                user.S_Last_Name = _user.S_Last_Name;

                user.Birth_Date = _user.Birth_Date;
                user.Email_Confirmation = _user.Email_Confirmation;

                _context.Update(user);
                _context.SaveChanges();
            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool getConfirmEmail(string email) {
            bool confirmado = false;
            User user = _context.User.FirstOrDefault(c => c.Email.Equals(email));
            if (user != null) 
            {
                confirmado = (bool)user.Email_Confirmation;
            }
            return confirmado;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return (await _context.User.FindAsync(email));
        }
    }
}

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
    public class UserServicePandemic : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlDbContextPandemic _context;
        //private readonly EmprendeUCR_WebApplication.Data.Context.AppDbContext _context;

        public UserServicePandemic(EmprendeUCR_WebApplication.Data.Contexts.SqlDbContextPandemic context)
        {
            _context = context;
        }

        public async Task<IList<User>> GetAsync() // Enlista Emprendedores
        {
            return await _context.User.ToListAsync();
        }

        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User _user)
        {
            User user = _context.User.FirstOrDefault(c => c.Email.Equals(_user.Email));
            if (user != null)
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

        public bool getConfirmEmail(string email)
        {
            bool confirmado = false;
            User user = _context.User.FirstOrDefault(c => c.Email.Equals(email));
            if (user != null)
            {
                confirmado = (bool)user.Email_Confirmation;
            }
            return confirmado;
        }

        public async Task<User> getUser(string email)
        {
            User _user = new User();

            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string sSQL = "SELECT * FROM [User] WHERE 1=1 ";

                if (!string.IsNullOrEmpty(email)) sSQL += " AND Email='" + email + "'";

                var oUser = (await con.QueryAsync<User>(sSQL)).ToList();

                if (oUser != null && oUser.Count > 0)
                {

                    _user = oUser.SingleOrDefault();
                }
                else
                {
                    return null;
                }

                return _user;
            }
        }

        public IList<User> getPhoto(string email)
        {
            return _context.User.FromSqlRaw("SELECT * FROM [User] WHERE [User].Email = " + email).ToArray();
        }


        public User GetUserByEmail(string email)
        {
            var a = _context.User.Find(email);
            return a;
        }
    }
}
